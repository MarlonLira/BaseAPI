using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetByClientId(int id);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<User> GetByRegistryCode(string registryCode);
        Task<User> GetByEmailAndRegistryCode(string email, string registryCode);
        Task<int> Save(User entity);
        Task<int> Update(User entity);
        Task<int> Delete(User entity);
    }
}
