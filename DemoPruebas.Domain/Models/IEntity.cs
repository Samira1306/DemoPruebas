namespace DemoPruebas.Domain.Models;

public interface IEntity<TKey> where TKey : notnull
{
    TKey Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime? UpdateDate { get; set; }
}
