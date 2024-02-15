using System.Net;

namespace PruebaPactia.Entities.PruebaEntity
{
    public class EntityResult<T>
    {
        public HttpStatusCode HttpCode { get; set; }
        public bool Success { get; set; }
        public bool HasData { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> ErrorList { get; set; }

        public static EntityResult<T> SuccessResult(bool hasData, HttpStatusCode code, T data, string message) => new() { Success = true, HasData = hasData, HttpCode = code, Data = data, Message = message };

        public static EntityResult<T> WrongResult(HttpStatusCode code, List<string> errorList) => new() { Success = false, HasData = false, HttpCode = code, ErrorList = errorList };

    }
}

