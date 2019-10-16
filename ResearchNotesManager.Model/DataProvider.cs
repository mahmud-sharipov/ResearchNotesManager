using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.Model
{
    public class DataProvider : IDisposable
    {
        public DataProvider()
        {
            Context = new EntityContext();
        }

        EntityContext Context { get; set; }

        public IQueryable<TEntity> GetEntities<TEntity>() where TEntity : EntityBase
        {
            return Context.GetEntities<TEntity>();
        }

        public TEntity Add<TEntity>() where TEntity : EntityBase, new()
        {
            var newEntity = new TEntity();
            newEntity.AddToContext(Context);
            newEntity.CreatedAt = DateTime.Now;
            return newEntity;
        }

        public void Add(EntityBase entity)
        {
            entity.AddToContext(Context);
            entity.CreatedAt = DateTime.Now;
        }

        public void Delete(EntityBase entity)
        {
            Context.Delete(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void DiscardChanges(EntityBase entity) => Context.DiscardChanges(entity);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
