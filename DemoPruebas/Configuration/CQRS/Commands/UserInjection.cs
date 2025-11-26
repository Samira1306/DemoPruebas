using DemoPruebas.Application.Commands;
using DemoPruebas.Application.Commands.Handlers;
using DemoPruebas.Application.Interfaces.Validations;
using DemoPruebas.Application.Validations;

namespace DemoPruebas.Configuration.CQRS.Commands
{
    public static class UserInjection
    {
        public static IServiceCollection AddUsersDependency(this IServiceCollection services)
        {
            services.AddScoped<CreateUserCommandHandler>();
            services.AddTransient<ICreateUserValidations, CreateUserValidations>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>());
            return services;
        }
    }
}
