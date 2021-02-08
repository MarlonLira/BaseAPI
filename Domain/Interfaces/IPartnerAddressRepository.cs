using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPartnerAddressRepository
    {
        Task<PartnerAddress> GetById(int id);
        Task<IEnumerable<PartnerAddress>> GetByPartnerId(int id);
        Task<int> Save(PartnerAddress entity);
        Task<int> Update(PartnerAddress entity);
        Task<int> Delete(PartnerAddress entity);
    }
}
