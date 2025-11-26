using DemoPruebas.Domain.Models;

namespace DemoPruebas.Application.Interfaces.Repositories
{
    public interface IUserService
    {
        void CreateUser(Users users);
    }
}
