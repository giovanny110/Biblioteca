using System.Net;

namespace Biblioteca.DTOs.Commons;

public class MessageResult<T>
{
    protected internal MessageResult(T data, string message, HttpStatusCode status, bool isSuccess, UInt16 code)
    {
        Data = data;
        Message = message;
        Status = status;
        IsSuccess = isSuccess;
        Code = code;
    }

    public bool IsSuccess { get; set; }

    public UInt16 Code { get; set; }

    public string Message { get; set; } = string.Empty;

    public HttpStatusCode Status { get; set; }

    public T Data { get; set; }

    #region Metodos Publicos
    public static MessageResult<T> Create<T>(T data, string message, HttpStatusCode statusCode, bool isSuccess = true, UInt16 code = 1) => new(data, message, statusCode, isSuccess, code);
    #endregion
}