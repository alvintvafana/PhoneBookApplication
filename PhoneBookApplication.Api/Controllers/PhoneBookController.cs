using Microsoft.AspNetCore.Mvc;
using PhoneBookApplication.Api.Dtos;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Queries;
using System.Collections;
using System.Threading.Tasks;

namespace PhoneBookApplication.Api.Controllers
{
    [Route("api/phone-book")]
    public class PhoneBookController : Controller
    {
        private readonly IMediator _mediator;
        public PhoneBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/CreatePhoneBookCommand")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePhoneBookDto createPhoneBookDto)
        {
            var command = new CreatePhoneBookCommand
            {
                Name = createPhoneBookDto.Name
            };

            await _mediator.DispatchAsync(command);

            return Ok();
        }

        [HttpGet("/GetPhoneBooksQuery")]
        public async Task<IEnumerable> GetPhoneBooksAsync()
        {
            var query = new GetPhoneBooksQuery();
            var result = await _mediator.DispatchAsync(query);
            return result;
        }
       

    }
}
