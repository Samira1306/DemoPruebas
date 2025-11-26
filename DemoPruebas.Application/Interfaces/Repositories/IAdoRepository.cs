using DemoPruebas.Domain.ValueObjects;

namespace DemoPruebas.Application.Interfaces.Repositories
{
    public interface IAdoRepository<T,TKey> where TKey : notnull
    {
        Task CreateAsync(T entity, DatabaseType type);
    }
}
