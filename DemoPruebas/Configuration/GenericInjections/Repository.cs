using DemoPruebas.Application.Behaviors;
using DemoPruebas.Application.Interfaces;
using DemoPruebas.Application.Interfaces.Repositories;
using DemoPruebas.Infraestructure.Data.AdoDbContext;
using DemoPruebas.Infraestructure.Repository;
using MediatR;

namespace DemoPruebas.Configuration.GenericInjections;

public static class Repository
{
	public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
    {
        services.AddScoped(typeof(ISqlRepository<,>), typeof(SqlGenericRepository<,>));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
        services.AddScoped(typeof(IAdoRepository<,>), typeof(AdoGenericRepository<,>));
        services.AddScoped(typeof(ITransactionScope), typeof(OracleDataContext));

        return services;
    }
}
