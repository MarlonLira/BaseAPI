using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRuleService
    {
        Task<Response> GetById(int id);
        Task<Response> Save(RuleViewModel model);
        Task<Response> Update(RuleViewModel model);
        Task<Response> Delete(int id);
    }
}
