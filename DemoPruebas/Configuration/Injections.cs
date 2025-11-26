using DemoPruebas.Configuration.CQRS.Commands;
using DemoPruebas.Configuration.GenericInjections;
using DemoPruebas.Configuration.ORM;

namespace DemoPruebas.Configuration
{
    public static class Injections
	{
		public static void Inject(this WebApplicationBuilder webApplicationBuilder)
		{
			webApplicationBuilder.Services.SqlConfiguration(webApplicationBuilder.Configuration);
			webApplicationBuilder.Services.OracleConfiguration(webApplicationBuilder.Configuration);
			webApplicationBuilder.Services.AddRepositoryDependency();
			webApplicationBuilder.Services.AddUsersDependency();
			webApplicationBuilder.Services.AddControllers();
			webApplicationBuilder.Services.AddEndpointsApiExplorer();
			webApplicationBuilder.Services.AddSwaggerGen();
		}
	}
}
