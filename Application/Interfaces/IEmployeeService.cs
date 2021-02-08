using Application.Commons;
using Application.Models;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<Response> GetById(int id);
        Task<Response> GetByPartnerId(int id);
        Task<Response> GetByRegistryCode(string registryCode);
        Task<Response> GetByEmail(string email);
        Task<Response> Save(EmployeeViewModel model);
        Task<Response> Update(EmployeeViewModel model);
        Task<Response> Delete(int id);
    }
}
