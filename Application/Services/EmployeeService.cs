using Application.Commons;
using Application.Commons.Enums;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService : Service<IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository, IMapper mapper, ILogService logService) : base(repository, mapper, logService) { }


        public async Task<Response> Delete(int id)
        {
            try
            {
                var _entity = await this._repository.GetById(id);
                _entity.SetUpdatedAt(DateTime.UtcNow.AddHours(-3));
                _entity.SetActive(false);

                if (_entity.IsValid())
                {
                    return Ok(await this._repository.Delete(_entity), HttpMessage.Deleted_Successfully);
                }
                else
                {
                    return BadRequest(_entity.GetValidationResults());
                }
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> GetByEmail(string email)
        {
            try
            {
                return Ok(this._mapper.Map<EmployeeViewModel>(await this._repository.GetByEmail(email)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                return Ok(this._mapper.Map<EmployeeViewModel>(await this._repository.GetById(id)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> GetByPartnerId(int id)
        {
            try
            {
                return Ok(this._mapper.Map<EmployeeViewModel>(await this._repository.GetByPartnerId(id)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> GetByRegistryCode(string registryCode)
        {
            try
            {
                return Ok(this._mapper.Map<EmployeeViewModel>(await this._repository.GetByRegistryCode(registryCode)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> Save(EmployeeViewModel model)
        {
            try
            {
                var _entity = new Employee(model);
                _entity.SetCreatedAt(DateTime.UtcNow.AddHours(-3));
                _entity.SetActive(true);

                if (_entity.IsValid())
                {
                    var _isExist = await this._repository.GetByEmailAndRegistryCode(_entity.Email, _entity.RegistryCode) == null ? false : true;

                    if (!_isExist)
                    {
                        return Ok(await this._repository.Save(_entity), HttpMessage.Saved_Successfully);
                    }
                    else
                    {
                        return AlreadyExists();
                    }
                }
                else
                {
                    return BadRequest(_entity.GetValidationResults());
                }
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> Update(EmployeeViewModel model)
        {
            try
            {
                var _entity = new Employee(model);
                _entity.SetUpdatedAt(DateTime.UtcNow.AddHours(-3));
                _entity.SetActive(true);

                if (_entity.IsValid())
                {
                    return Ok(await this._repository.Update(_entity), HttpMessage.Saved_Successfully);
                }
                else
                {
                    return BadRequest(_entity.GetValidationResults());
                }
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }

        }

    }
}
