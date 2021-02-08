using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRuleRepository
    {
        Task<Rule> GetById(int id);
        Task<int> Save(Rule entity);
        Task<int> Update(Rule entity);
        Task<int> Delete(Rule entity);
    }
}
