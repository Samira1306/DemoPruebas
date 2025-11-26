using DemoPruebas.Domain.Models;
using MediatR;

namespace DemoPruebas.Application.Interfaces.RequestIntefaces;

public interface ICommand : IRequest<Response>
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}
