namespace api_software_documentation.Src.Application.Errors;

public class ErrorResponse
{
    public string message { get; }
    public int statusCode { get; }
    public ErrorResponse(string _message = "Erro no servidor", int _statusCode = 500)
    {
        statusCode = _statusCode;
        message = _message;
    }
}
