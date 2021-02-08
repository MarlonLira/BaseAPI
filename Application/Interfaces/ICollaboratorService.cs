using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<Response> GetByClientId(int id);
        Task<Response> GetById(int id);
        Task<Response> Save(CollaboratorViewModel model);
        Task<Response> Update(CollaboratorViewModel model);
        Task<Response> Delete(int id);
        Task<Response> SignIn(CollaboratorViewModel model);
    }
}
