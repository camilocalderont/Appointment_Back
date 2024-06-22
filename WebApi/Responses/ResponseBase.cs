using System.Net;

namespace Appointment_Back.Responses;

public class ResponseBase<T, E>
{
    public ResponseBase()
    {
        ResponseTime = DateTime.UtcNow;
    }

    public ResponseBase(HttpStatusCode code = HttpStatusCode.OK, string message = null, T data = default, int count = 0)
        : this()
    {
        Code = (int)code;
        Message = message;
        Data = data;
        Count = count;
    }

    public ResponseBase(int code = (int)HttpStatusCode.OK, string message = null, T data = default, int count = 0)
        : this()
    {
        Code = code;
        Message = message;
        Data = data;
        Count = count;
    }

    public ResponseBase(T data, string message = "Solicitud OK.", int count = 0)
        : this((int)HttpStatusCode.OK, message, data, count)
    {
        if (data is IEnumerable<T> enumerableData && count == 0)
        {
            Count = enumerableData is ICollection<T> collection ? collection.Count : throw new ArgumentException("Data must implement ICollection<T> to count items.");
        }
    }

    public ResponseBase(HttpStatusCode code = HttpStatusCode.InternalServerError, string message = "Error en el servidor!")
        : this(code, message, default(T), 0)
    {
    }

    public ResponseBase(HttpStatusCode code = HttpStatusCode.InternalServerError, string message = "Error en el servidor!", E errors = default)
        : this(code, message, default(T), 0)
    {
        Errors = errors;
    }

    public string Message { get; set; }

    public int Count { get; set; }

    public DateTime ResponseTime { get; private set; }

    public T Data { get; set; }

    public int Code { get; set; }

    public E Errors { get; set; }
}