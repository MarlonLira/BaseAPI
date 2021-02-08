using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetByClientId(int id);
        Task<Collaborator> GetById(int id);
        Task<Collaborator> GetByEmail(string email);
        Task<Collaborator> GetByRegistryCode(string registryCode);
        Task<Collaborator> GetByEmailAndRegistryCode(string email, string registryCode);
        Task<int> Save(Collaborator entity);
        Task<int> Update(Collaborator entity);
        Task<int> Delete(Collaborator entity);
    }
}
