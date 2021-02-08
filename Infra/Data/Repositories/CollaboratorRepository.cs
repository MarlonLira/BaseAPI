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
    public class CollaboratorRepository : Repository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(GymTimeContext context) : base(context) { }

        public async Task<int> Delete(Collaborator entity)
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

        public async Task<IEnumerable<Collaborator>> GetByClientId(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.ClientId == id)
                    .ToListAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Collaborator> GetByEmail(string email)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Email.Equals(email))
                    .Include(x => x.Client)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Collaborator> GetByEmailAndRegistryCode(string email, string registryCode)
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

        public async Task<Collaborator> GetById(int id)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.Id == id)
                    .Include(x => x.Client)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<Collaborator> GetByRegistryCode(string registryCode)
        {
            try
            {
                return await this.DbSet.AsNoTracking()
                    .Where(x => x.Active && x.RegistryCode.Equals(registryCode))
                    .Include(x => x.Client)
                    .FirstOrDefaultAsync();
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public async Task<int> Save(Collaborator entity)
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

        public async Task<int> Update(Collaborator entity)
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
