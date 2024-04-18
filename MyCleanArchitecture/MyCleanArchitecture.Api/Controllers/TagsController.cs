using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyCleanArchitecture.Application.TagItems.Commands.CreateTagItem;
using MyCleanArchitecture.Application.Common.Models;

namespace MyCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> CreateTagItemAsync(CreateTagItemCommand command)
        {
            Result<int> result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(key: error.Key, errorMessage: error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
        }
    }
}
