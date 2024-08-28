

namespace Fashion.Domain.ApiResult
{
    public class ApiResult
    {
        public int StatusCode { get; set; }
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public ApiResult(bool isSucceeded, string message, int statusCode)
        {
            Message = message;
            IsSucceeded = isSucceeded;
            StatusCode = statusCode;
        }
    }
}
