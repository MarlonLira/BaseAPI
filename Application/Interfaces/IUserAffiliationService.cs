using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserAffiliationService
    {
        Task<Response> GetById(int id);
        Task<Response> Save(UserAffiliationViewModel model);
        Task<Response> Accept(UserAffiliationViewModel model);
        Task<Response> Delete(int id);
    }
}
