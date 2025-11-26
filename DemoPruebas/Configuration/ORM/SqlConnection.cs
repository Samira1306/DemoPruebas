using DemoPruebas.Domain.Resources.Constants;
using DemoPruebas.Infraestructure.Data.EFDbContext;
using Microsoft.EntityFrameworkCore;

namespace DemoPruebas.Configuration.ORM;

public static class SqlConnection
{
    public static IServiceCollection SqlConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString(DomainConstants.SQL_CONNECTION)));
        return services;
    }
}
