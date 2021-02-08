using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseAPIContext context) : base(context) { }

        public async Task<int> Delete(User entity)
        {
            try
            {
                var _result = this.OnUpdate(entity);
                await this.Db.SaveChangesAsync();
                return _result.Id;
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<IEnumerable<User>> GetByClientId(int id)
        {
            try
            {
                //var _result = await this.DbSet.AsNoTracking()
                //    .IncludeFilter(x => x.UserAffiliations.Where(o => o.ClientId.Equals(id) && o.Status.Equals("P")))
                //    .Include(x => x.UserAffiliations)
                //    .Where(x => x.Active)
                //    .ToListAsync();

                var _result = await (from user in Db.User
                                     join userAffiliation in Db.UserAffiliation.Where(o => o.ClientId.Equals(id) && o.Status.Equals("P"))
                                      on user.Id equals userAffiliation.UserId
                                     where user.Active
                                     select user)
                                     .Include(x => x.UserAffiliations)
                                     .ToListAsync();

                return _result;
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Email.Equals(email))
                    .Include(x => x.UserAffiliations)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Id == id)
                    .Include(x => x.UserAffiliations)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<User> GetByRegistryCode(string registryCode)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                        .Where(x => x.Active && x.RegistryCode.Equals(registryCode))
                        .Include(x => x.UserAffiliations)
                        .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<User> GetByEmailAndRegistryCode(string email, string registryCode)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && (x.Email.Equals(email) || x.RegistryCode.Equals(registryCode)))
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<int> Save(User entity)
        {
            try
            {
                var _result = this.DbSet.Add(entity);
                await this.Db.SaveChangesAsync();
                return _result.Id;
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<int> Update(User entity)
        {
            try
            {
                var _result = this.OnUpdate(entity);
                await this.Db.SaveChangesAsync();
                return _result.Id;
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
    }
}
