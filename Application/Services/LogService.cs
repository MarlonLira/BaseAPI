using Application.Commons;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LogService : ILogService
    {
        protected readonly ILogRepository _repository;
        protected readonly IMapper _mapper;

        public LogService(ILogRepository repository, IMapper mapper) : base()
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> Crit(HttpStatusCode httpCode, string message, string source)
        {
            try
            {
                var _log = new Log();
                _log.SetCode($"{Convert.ToInt32(httpCode)}");
                _log.SetLevel("Critical");
                _log.SetMessage(message);
                _log.SetSource(source);
                _log.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                await this._repository.Save(_log);
                return new Response(httpCode, new Error(_log.Message, source));
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Response> Crit(HttpStatusCode httpCode, string message, object source)
        {
            try
            {
                var _log = new Log();
                _log.SetCode($"{Convert.ToInt32(httpCode)}");
                _log.SetLevel("Critical");
                _log.SetMessage(message);
                _log.SetSource(source.ToString());
                _log.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                await this._repository.Save(_log);
                return new Response(httpCode, new Error(_log.Message, source));
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public Task<Response> Crit<T>(HttpStatusCode httpCode, string message, List<T> source)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetById(int id)
        {
            return new Response(HttpStatusCode.OK, this._mapper.Map<LogViewModel>(await this._repository.GetById(id)));
        }


        public async Task<Response> Warn(HttpStatusCode httpCode, string message, string source)
        {
            try
            {
                var _log = new Log();
                _log.SetCode($"{Convert.ToInt32(httpCode)}");
                _log.SetLevel("Critical");
                _log.SetMessage(message);
                _log.SetSource(source);
                _log.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                await this._repository.Save(_log);
                return new Response(httpCode, new Error(_log.Message, source));
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Response> Warn(HttpStatusCode httpCode, string message, object source)
        {
            try
            {
                var _log = new Log();
                _log.SetCode($"{Convert.ToInt32(httpCode)}");
                _log.SetLevel("Critical");
                _log.SetMessage(message);
                _log.SetSource(source.ToString());
                _log.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                await this._repository.Save(_log);
                return new Response(httpCode, new Error(_log.Message, source));
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Response> Warn<T>(HttpStatusCode httpCode, string message, List<T> source)
        {
            try
            {
                var _log = new Log();
                _log.SetCode($"{Convert.ToInt32(httpCode)}");
                _log.SetLevel("Critical");
                _log.SetMessage(message);
                _log.SetSource(string.Join(",", source));
                _log.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                await this._repository.Save(_log);
                return new Response(httpCode, new Error(_log.Message, source));
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
    }
}


