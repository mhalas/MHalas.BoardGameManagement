using MHalas.BGM.Base.Exceptions;
using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;
using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MHalas.BGM.Repository
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : class, IEntity
    {
        protected BoardGameManagementEntities Entities;
        protected DbSet<TModel> DbSet;

        public BaseRepository(BoardGameManagementEntities entities)
        {
            Entities = entities;
            DbSet = entities.Set<TModel>();
        }

        public void Create(TModel model)
        {
            DbSet.Add(model);
            Entities.SaveChanges();
        }

        public abstract void Delete(int id);

        public virtual TModel RetrieveByID(int id)
        {
            var element = DbSet.SingleOrDefault(x => x.Id == id);

            if (element == null)
                throw new NotFoundInDatabaseException();

            return element;
        }

        public virtual IEnumerable<TModel> RetrieveByIDs(List<int> ids)
        {
            if (ids == null || !ids.Any())
                return new List<TModel>();

            return DbSet.Where(x => ids.Contains(x.Id));
        }

        public void Update(TModel model)
        {
            Entities.Entry(model).State = EntityState.Modified;
            Entities.SaveChanges();
        }
    }
}
