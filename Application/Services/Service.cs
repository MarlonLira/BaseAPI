using Application.Commons;
using Application.Commons.Enums;
using Application.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Service<IRepository>
    {
        protected readonly IRepository _repository;
        protected readonly IMapper _mapper;
        protected readonly ILogService _log;

        public Service(IRepository repository, IMapper mapper, ILogService logService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._log = logService;
        }

        protected Response Ok(object value)
        {
            return new Response(HttpStatusCode.OK, value);
        }

        protected Response Ok(object value, string message)
        {
            return new Response(HttpStatusCode.OK, value, message);
        }

        protected Response BadRequest(object value)
        {
            return new Response(HttpStatusCode.BadRequest, value);
        }

        protected async Task<Response> ParametersNotProvided<T>(List<T> value)
        {
            return await this._log.Warn<T>(HttpStatusCode.BadRequest, HttpMessage.Parameters_Not_Provided, value);
        }

        protected Response Unauthorized(string value)
        {
            return new Response(HttpStatusCode.Unauthorized, new Error(value, null));
        }

        protected Response AlreadyExists()
        {
            return new Response(HttpStatusCode.BadRequest, new Error(HttpMessage.Already_Exists, null));
        }

        protected async Task<Response> InternalServerError(string value)
        {
            return await this._log.Crit(HttpStatusCode.InternalServerError, HttpMessage.Unknown_Error, value);
        }
    }
}
