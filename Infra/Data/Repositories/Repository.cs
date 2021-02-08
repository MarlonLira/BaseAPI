using Domain.Entities;
using Infra.Data.Context;
using System;
using System.Data.Entity;

namespace Infra.Data.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        protected BaseAPIContext Db;
        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(BaseAPIContext baseAPIContext)
        {
            this.Db = baseAPIContext;
            this.DbSet = Db.Set<TEntity>();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public TEntity OnUpdate(TEntity entity)
        {
            var _entity = this.DbSet.Add(entity);
            this.Db.Entry(entity).State = EntityState.Modified;
            this.SetNullPropertyToUnmodified(entity);
            return _entity;
        }

        public void SetNullPropertyToUnmodified(TEntity entity)
        {
            try
            {
                var _properties = entity.GetType().GetProperties();

                foreach (var property in _properties)
                {
                    var isEntity = false;
                    var isCollection = false;
                    if (property.PropertyType.BaseType != null)
                    {
                        isEntity = property.PropertyType.BaseType.Name == "Entity";
                    }
                    else
                    {
                        isCollection = true;
                    }

                    if (property.GetValue(entity) == null && !isEntity && !isCollection)
                    {
                        this.Db.Entry(entity).Property(property.Name).IsModified = false;
                    }
                }
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }
    }
}
