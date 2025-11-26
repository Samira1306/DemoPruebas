using DemoPruebas.Domain.Models;
using MediatR;

namespace DemoPruebas.Application.Interfaces.RequestIntefaces
{
    public interface IQuery<TResponse> : IRequest<Response<TResponse>>
    {
    }
}
