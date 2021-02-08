namespace Application.Commons
{
    public class Auth<T>
    {
        public string Token { get; private set; }
        public T Obj { get; private set; }

        public Auth(string token, T obj)
        {
            this.Token = token;
            this.Obj = obj;
        }
    }
}
