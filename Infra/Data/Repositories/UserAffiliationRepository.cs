using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserAffiliationRepository : Repository<UserAffiliation>, IUserAffiliationRepository
    {
        public UserAffiliationRepository(BaseAPIContext context) : base(context) { }

        public async Task<int> Delete(UserAffiliation entity)
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

        public async Task<UserAffiliation> GetById(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Id.Equals(id))
                    .Include(x => x.Client)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<UserAffiliation> GetByUserId(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.UserId.Equals(id) && (x.Status.Equals("P") || x.Status.Equals("A")))
                    .Include(x => x.Client)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<UserAffiliation> GetByUserIdAndStatus(int id, string status)
        {
            try
            {
                var _result = await this.DbSet.AsNoTracking()
                    .Where(x => x.UserId.Equals(id) && x.Status.Equals(status))
                    .Include(x => x.Client)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync();

                return _result;
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<int> Save(UserAffiliation entity)
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

        public async Task<int> Update(UserAffiliation entity)
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
