using Application.Commons;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILogService
    {
        Task<Response> GetById(int id);

        Task<Response> Crit(HttpStatusCode httpCode, string message, string source);
        Task<Response> Crit(HttpStatusCode httpCode, string message, object source);
        Task<Response> Crit<T>(HttpStatusCode httpCode, string message, List<T> source);
        Task<Response> Warn(HttpStatusCode httpCode, string message, string source);
        Task<Response> Warn(HttpStatusCode httpCode, string message, object source);
        Task<Response> Warn<T>(HttpStatusCode httpCode, string message, List<T> source);
    }
}
