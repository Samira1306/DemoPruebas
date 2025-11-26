using DemoPruebas.Application.Interfaces.RequestIntefaces;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPruebas.Application.Commands
{
    public class CreateUserCommand : ICommand<Response<Users>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty.ToString();
        public int Status_Id { get; set; }
    }
}
