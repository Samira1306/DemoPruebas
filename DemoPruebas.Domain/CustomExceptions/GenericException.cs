namespace DemoPruebas.Domain.CustomExceptions;

public class GenericException(string message, string errorCode) : ApplicationException(message ?? "")
{
    public string ErrorCode { get; set; } = errorCode;
}
