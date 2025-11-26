using DemoPruebas.Application.Commands;
using DemoPruebas.Application.Commands.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoPruebas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator, CreateUserCommandHandler commandHandler) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly CreateUserCommandHandler _commandHandler = commandHandler;

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
        {
            //var response = await _mediator.Send(command);
            var response = await _commandHandler.Handle(command, cancellationToken);

            return Ok(response);
        }
    }
}
