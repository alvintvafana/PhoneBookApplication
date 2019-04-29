using Microsoft.AspNetCore.Mvc;
using PhoneBookApplication.Api.Dtos;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Controllers
{
    [Route("api/phone-book")]
    public class PhoneBookController : Controller
    {
        private readonly Messages _messages;
        public PhoneBookController(Messages messages)
        {
            _messages = messages;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePhoneBookDto createPhoneBookDto)
        {
            var command = new CreatePhoneBookCommand
            {
                Name = createPhoneBookDto.Name
            };

            await _messages.DispatchAsync(command);

            return Ok();
        }

        [HttpGet("/phonebooks")]
        public async Task<IEnumerable> GetPhoneBooksAsync()
        {
            var query = new GetPhoneBooksQuery();
            var result = await _messages.DispatchAsync(query);
            return result;
        }
       

    }
}
