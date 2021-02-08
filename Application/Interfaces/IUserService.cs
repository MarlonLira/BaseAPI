using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Response> GetByClientId(int id);
        Task<Response> GetById(int id);
        Task<Response> Save(UserViewModel model);
        Task<Response> Update(UserViewModel model);
        Task<Response> Delete(int id);
        Task<Response> SignIn(UserViewModel model);
    }
}
