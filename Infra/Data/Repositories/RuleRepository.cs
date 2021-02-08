using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class RuleRepository : Repository<Rule>, IRuleRepository
    {
        public RuleRepository(BaseAPIContext context) : base(context) { }

        public async Task<int> Delete(Rule entity)
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
        public async Task<Rule> GetById(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Id == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
        public async Task<int> Save(Rule entity)
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

        public async Task<int> Update(Rule entity)
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
