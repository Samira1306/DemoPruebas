using DemoPruebas.Application.Interfaces.Repositories;
using DemoPruebas.Application.Interfaces.Validations;
using DemoPruebas.Domain.Models;
using MediatR;

namespace DemoPruebas.Application.Commands.Handlers
{
    public class CreateUserCommandHandler(ISqlRepository<Users, string> repository,
        ICreateUserValidations createUserValidations) : IRequestHandler<CreateUserCommand, Response<Users>>
    {
        private readonly ISqlRepository<Users, string> _repository = repository;
        private readonly ICreateUserValidations _createUserValidations = createUserValidations;

        public async Task<Response<Users>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            Users user = new() { Name = command.Name, Phone = command.Number, Email = command.Email, Status_Id = 1 };

            await _createUserValidations.ValidAsync(command.Name, command.Email, command.Number);
            user.Id = Guid.NewGuid().ToString();
            await _repository.CreateAsync(user);

            Response<Users> response = new() { Success = true, Message = "Error", Data = user };
            return response;
        }
    }
}
