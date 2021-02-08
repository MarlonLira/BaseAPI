using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetById(int id);
        Task<Client> GetByRegistryCode(string registryCode);
        Task<int> Save(Client entity);
        Task<int> Update(Client entity);
        Task<int> Delete(Client entity);
    }
}
