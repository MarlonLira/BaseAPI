namespace Application.Commons
{
    public class Error
    {
        public string Message { get; private set; }
        public object Source { get; private set; }

        public Error(string message, object source)
        {
            Message = message;
            Source = source;
        }
    }
}
