using Domain.Entities;
using System;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
    }
}
