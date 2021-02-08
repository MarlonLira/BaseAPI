using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPartnerRepository
    {
        Task<Partner> GetById(int id);
        Task<Partner> GetByRegistryCode(string registryCode);
        Task<int> Save(Partner entity);
        Task<int> Update(Partner entity);
        Task<int> Delete(Partner entity);
    }
}
