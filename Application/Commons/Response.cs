using System.Net;

namespace Application.Commons
{
    public class Response
    {
        public HttpStatusCode HttpCode { get; private set; }
        public string Message { get; private set; }
        public object Value { get; private set; }
        public Error Error { get; private set; }

        public Response(HttpStatusCode httpCode)
        {
            this.HttpCode = httpCode;
        }

        public Response(HttpStatusCode httpCode, object value)
        {
            this.HttpCode = httpCode;
            this.Value = value;
        }

        public Response(HttpStatusCode httpCode, object value, string message)
        {
            this.HttpCode = httpCode;
            this.Value = value;
            this.Message = message;
        }

        public Response(HttpStatusCode httpCode, Error error)
        {
            this.HttpCode = httpCode;
            this.Error = error;
        }

        public void SetError(string message, object source)
        {
            this.Error = new Error(message, source);
        }
    }
}
