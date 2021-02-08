using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPartnerService
    {
        Task<Response> GetById(int id);
        Task<Response> Save(PartnerViewModel model);
        Task<Response> Update(PartnerViewModel model);
        Task<Response> Delete(int id);
    }
}
