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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BaseAPIContext context) : base(context) { }

        public async Task<int> Delete(Employee entity)
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

        public async Task<IEnumerable<Employee>> GetByPartnerId(int id)
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

        public async Task<Employee> GetByEmail(string email)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Email.Equals(email))
                    .Include(x => x.Partner)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Id == id)
                    .Include(x => x.Partner)
                    .Include(x => x.Rule)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Employee> GetByRegistryCode(string registryCode)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.RegistryCode.Contains(registryCode))
                    .Include(x => x.Partner)
                    .Include(x => x.Rule)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<int> Save(Employee entity)
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

        public async Task<int> Update(Employee entity)
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

        public async Task<Employee> GetByEmailAndRegistryCode(string email, string registryCode)
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
    }
}
