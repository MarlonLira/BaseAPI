using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserAffiliationRepository
    {
        Task<UserAffiliation> GetById(int id);
        Task<UserAffiliation> GetByUserId(int id);
        Task<UserAffiliation> GetByUserIdAndStatus(int id, string status);
        Task<int> Save(UserAffiliation entity);
        Task<int> Update(UserAffiliation entity);
        Task<int> Delete(UserAffiliation entity);
    }
}
