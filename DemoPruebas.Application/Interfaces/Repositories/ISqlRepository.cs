namespace DemoPruebas.Application.Interfaces.Repositories
{
    public interface ISqlRepository<T, TKey> where TKey : notnull
    {
        IQueryable<T> GetQueryablel();
        Task CreateAsync(T entity);
    }
}
