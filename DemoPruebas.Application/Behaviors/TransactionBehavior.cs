using DemoPruebas.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DemoPruebas.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ITransactionScope _transactionScope;

        public TransactionBehavior(ITransactionScope transactionScope)
        {
            _transactionScope = transactionScope;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request!.GetType().Name.Contains("Command"))
            {
                try
                {
                    _transactionScope.BeginTransaction();

                    var response = await next();

                    _transactionScope.Commit();

                    return response;
                }
                catch (Exception)
                {
                    _transactionScope.Rollback();
                    throw;
                }
                finally
                {
                    _transactionScope.Dispose();
                }
            }
            else
            {
                _transactionScope.BeginTransaction();

                var response = await next();

                _transactionScope.Dispose();

                return response;
            }
        }
    }
}
