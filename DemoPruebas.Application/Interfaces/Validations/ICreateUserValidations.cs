using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPruebas.Application.Interfaces.Validations
{
    public interface ICreateUserValidations
    {
        Task ValidAsync(string name, string email, string number);
    }
}
