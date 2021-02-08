using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class PartnerAddressRepository : Repository<PartnerAddress>, IPartnerAddressRepository
    {
        public PartnerAddressRepository(BaseAPIContext context) : base(context) { }

        public async Task<int> Delete(PartnerAddress entity)
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

        public async Task<IEnumerable<PartnerAddress>> GetByPartnerId(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.PartnerId == id)
                    .ToListAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
        public async Task<PartnerAddress> GetById(int id)
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
        public async Task<int> Save(PartnerAddress entity)
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

        public async Task<int> Update(PartnerAddress entity)
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
