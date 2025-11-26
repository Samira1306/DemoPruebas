using DemoPruebas.Application.Interfaces.Repositories;
using DemoPruebas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPruebas.Application.Services
{
    public class ExceptionErrorPersistence(ISqlRepository<ErrorLog, Guid> repository)
    {
        private readonly ISqlRepository<ErrorLog, Guid> _repository = repository;

        public async Task ErrorPersintanceService(ErrorLog log)
        {
            await _repository.CreateAsync(log);
        }
    }
}
