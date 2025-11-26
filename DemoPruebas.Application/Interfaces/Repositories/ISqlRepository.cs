using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoPruebas.Application.Interfaces.Repositories
{
    public interface ISqlRepository<T, TKey> where TKey : notnull
    {
        IQueryable<T> GetQueryablel();
        Task CreateAsync(T entity);
    }
}
