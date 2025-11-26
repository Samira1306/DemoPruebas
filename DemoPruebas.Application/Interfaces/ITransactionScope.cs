namespace DemoPruebas.Application.Interfaces;

public interface ITransactionScope
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    void Dispose();
}
