using DemoPruebas.Application.Interfaces.Repositories;
using DemoPruebas.Domain.Models;
using DemoPruebas.Infraestructure.Data.EFDbContext;
using Microsoft.EntityFrameworkCore;

namespace DemoPruebas.Infraestructure.Repository;

public class SqlGenericRepository<T, TKey> : ISqlRepository<T, TKey>
    where T : class, IEntity<TKey>, new()
    where TKey : notnull
{
    private readonly AppDbContext _efContext;
    private readonly DbSet<T> _dbSet;

    public SqlGenericRepository(AppDbContext efContext)
    {
        _efContext = efContext;
        _dbSet = _efContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.UpdateDate = null;
        await _dbSet.AddAsync(entity);
        await _efContext.SaveChangesAsync();
    }
    public IQueryable<T> GetQueryablel()
    {
        return _dbSet;
    }
   
}
