using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<Response> GetById(int id);
        Task<Response> Save(ClientViewModel model);
        Task<Response> Update(ClientViewModel model);
        Task<Response> Delete(int id);
    }
}
