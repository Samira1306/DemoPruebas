using DemoPruebas.Test.Infraestructure;
using DemoPruebas.TestSupport;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace DemoPruebas.Test.ApiTests
{
    public class UserTest (GenericWebApplicationFactory<ProgramTest> factory) : IClassFixture<GenericWebApplicationFactory<ProgramTest>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Crear_Usuarios_DeberiaRetornar200()
        {
            var id = Guid.Parse("44197386-3893-4505-869d-04ea2187d293");

            var userJson = new { Id = id, Name = "Oscar Test", Email = "Test@hotmail.com", Number = "3212246801" };

            var response = await _client.PostAsJsonAsync("/api/User/Create", userJson);
           
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(content);
        }
    }
}
