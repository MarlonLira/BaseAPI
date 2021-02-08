using Application.Commons;
using Application.Commons.Enums;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : Service<IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper, ILogService logService) : base(repository, mapper, logService) { }

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

        public async Task<Response> GetByClientId(int id)
        {
            try
            {
                return Ok(this._mapper.Map<IEnumerable<UserViewModel>>(await this._repository.GetByClientId(id)));
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
                return Ok(this._mapper.Map<UserViewModel>(await this._repository.GetById(id)));
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> Save(UserViewModel model)
        {
            try
            {
                Encoded _encoded = !string.IsNullOrEmpty(model.Password) ? Crypto.EncryptPassword(model.Password) : null;
                var _entity = new User(model);

                _entity.SetActive(true);
                _entity.SetCreatedAt(DateTime.UtcNow.AddHours(-3));

                if (_encoded != null)
                {
                    _entity.SetPassword(_encoded.Encrypted);
                }

                if (_entity.IsValid())
                {
                    var _isExist = await this._repository.GetByEmailAndRegistryCode(_entity.Email, _entity.RegistryCode) == null ? false : true;

                    if (!_isExist)
                    {
                        await this._repository.Save(_entity);
                        var _auth = (await this.SignIn(model)).Value;
                        return Ok(_auth, HttpMessage.Saved_Successfully);
                    }
                    else
                    {
                        return AlreadyExists();
                    }
                }
                else
                {
                    return await ParametersNotProvided(_entity.GetValidationResults());
                }
            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> SignIn(UserViewModel model)
        {
            try
            {
                User _user = null;
                if (!string.IsNullOrEmpty(model.Email))
                {
                    _user = await this._repository.GetByEmail(model.Email);
                }

                if (_user != null)
                {

                    bool authorized = Crypto.ComparePassword(model.Password, new Encoded(_user.Password));

                    if (authorized)
                    {
                        var _model = this._mapper.Map<UserViewModel>(_user);
                        var _auth = new Auth<UserViewModel>(Jwt.CreateToken(model.Email), _model);
                        return Ok(_auth, HttpMessage.Login_Authorized);
                    }
                    else
                    {
                        return Unauthorized("A conta informada é inválida!");
                    }
                }
                else
                {
                    return Unauthorized("A conta informada é inválida!");
                }

            }
            catch (Exception except)
            {
                return await InternalServerError(except.Message);
            }
        }

        public async Task<Response> Update(UserViewModel model)
        {
            try
            {
                Encoded _encoded = !string.IsNullOrEmpty(model.Password) ? Crypto.EncryptPassword(model.Password) : null;
                var _entity = new User(model);
                _entity.SetActive(true);
                _entity.SetUpdatedAt(DateTime.UtcNow.AddHours(-3));

                if (_encoded != null)
                {
                    _entity.SetPassword(_encoded.Encrypted);
                }

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
