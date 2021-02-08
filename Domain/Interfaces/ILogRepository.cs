using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILogRepository
    {
        Task<Log> GetById(int id);
        Task<int> Save(Log entity);
        Task<int> Update(Log entity);
        Task<int> Delete(Log entity);
    }
}
