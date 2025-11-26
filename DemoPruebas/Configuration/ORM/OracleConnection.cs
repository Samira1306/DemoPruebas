using DemoPruebas.Domain.Resources.Constants;
using DemoPruebas.Infraestructure.Data.AdoDbContext;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace DemoPruebas.Configuration.ORM
{
    public static class OracleDbConfiguration
	{
		public static IServiceCollection OracleConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<OracleConnection>(provider =>
			{
				string connectionString = configuration.GetConnectionString(DomainConstants.ORACLE_CONNECTION)!;
				OracleConnection connection = new(connectionString);
				return connection;
			});

			services.AddScoped<OracleDataContext>(provider =>
			{
                OracleConnection oracleConnection = provider.GetRequiredService<OracleConnection>();
				return new OracleDataContext(oracleConnection);
			});

            return services;
		}

	}
}
