using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPartnerAddressService
    {
        Task<Response> GetById(int id);
        Task<Response> GetByPartnerId(int id);
        Task<Response> Save(PartnerAddressViewModel model);
        Task<Response> Update(PartnerAddressViewModel model);
        Task<Response> Delete(int id);
    }
}
