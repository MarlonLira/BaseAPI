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
    public class PartnerService : Service<IPartnerRepository>, IPartnerService
    {
        public PartnerService(IPartnerRepository repository, IMapper mapper, ILogService logService) : base(repository, mapper, logService) { }

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

        public async Task<Response> GetById(int id)
        {
            try
            {
                return Ok(this._mapper.Map<PartnerViewModel>(await this._repository.GetById(id)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> Save(PartnerViewModel model)
        {
            try
            {
                var _entity = new Partner(model);
                _entity.SetActive(true);
                _entity.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                if (_entity.IsValid())
                {
                    var _isExist = await this._repository.GetByRegistryCode(_entity.RegistryCode) == null ? false : true;

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

        public async Task<Response> Update(PartnerViewModel model)
        {
            try
            {
                var _entity = new Partner(model);
                _entity.SetActive(true);
                _entity.SetUpdatedAt(DateTime.UtcNow.AddHours(-3));

                if (_entity.IsValid())
                {
                    return Ok(await this._repository.Update(_entity), HttpMessage.Updated_Successfully);
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


