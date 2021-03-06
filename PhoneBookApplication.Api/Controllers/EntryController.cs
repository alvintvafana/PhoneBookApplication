﻿using Microsoft.AspNetCore.Mvc;
using PhoneBookApplication.Api.Dtos;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EntryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/SearchPhoneBookQuery")]
        public async Task<IEnumerable> SearchPhoneBookAsync(Guid phoneBookId, string name)
        {
            var query = new SearchPhoneBookQuery
            {
                PhoneBookId = phoneBookId,
                Name=name
            };
            var result = await _mediator.DispatchAsync(query);
            return result;
        }

        [HttpPost("/InsertEntryCommand")]
        public async Task<IActionResult> InsectEntryAsync([FromBody] InsertEntryDto insertEntryDto)
        {
            var command = new InsertEntryCommand
            {
                PhoneBookId = insertEntryDto.PhoneBookId,
                PhoneNumber = insertEntryDto.PhoneNumber,
                Name = insertEntryDto.Name
            };

            await _mediator.DispatchAsync(command);

            return Ok();
        }

        [HttpPost("/UpdateEntryCommand")]
        public async Task<IActionResult> UpdateEntryAsync([FromBody] UpdateEntryDto updateEntryDto)
        {
            var command = new UpdateEntryCommand
            {
                PhoneBookId = updateEntryDto.PhoneBookId,
                EntryId = updateEntryDto.EntryId,
                PhoneNumber = updateEntryDto.PhoneNumber,
                Name = updateEntryDto.Name
            };

            await _mediator.DispatchAsync(command);

            return Ok();
        }

        [HttpPost("/DeleteEntryCommand")]
        public async Task<IActionResult> DeleteEntryAsync([FromBody] DeleteEntryDto deleteEntryDto)
        {
            var command = new DeleteEntryCommand
            {
                PhoneBookId = deleteEntryDto.PhoneBookId,
                EntryId = deleteEntryDto.EntryId
            };

            await _mediator.DispatchAsync(command);

            return Ok();
        }

    }
}
