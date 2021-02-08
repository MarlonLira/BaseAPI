using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetByPartnerId(int id);
        Task<Employee> GetByRegistryCode(string registryCode);
        Task<Employee> GetByEmail(string email);
        Task<Employee> GetByEmailAndRegistryCode(string email, string registryCode);
        Task<int> Save(Employee entity);
        Task<int> Update(Employee entity);
        Task<int> Delete(Employee entity);
    }
}
