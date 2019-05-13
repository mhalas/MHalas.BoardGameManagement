using MHalas.BGM.Base.Exceptions;
using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;
using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;
using System.Linq;

namespace MHalas.BGM.Repository
{
    public abstract class BaseSoftDeleteRepository<TModel> : BaseRepository<TModel>, IBaseSoftDeleteRepository<TModel>
        where TModel : class, IEntity, IIsDeleted
    {
        public BaseSoftDeleteRepository(BoardGameManagementEntities entities) : base(entities)
        {
        }

        public IEnumerable<TModel> Retrieve(int? count = null, bool? isDeleted = null)
        {
            var query = DbSet.OrderByDescending(x=>x.Id).AsQueryable();

            if (isDeleted.HasValue)
                query = query.Where(x => x.IsDeleted == isDeleted);

            if (count.HasValue)
                return query.Take(count.Value).AsEnumerable();

            return query.AsEnumerable();
        }

        public override void Delete(int id)
        {
            var element = RetrieveByID(id);

            element.IsDeleted = true;
            Entities.SaveChanges();
        }

        public override TModel RetrieveByID(int id)
        {
            var element = DbSet.Where(x=>x.IsDeleted == false).SingleOrDefault(x => x.Id == id);

            if (element == null)
                throw new NotFoundInDatabaseException();

            return element;
        }

        public override IEnumerable<TModel> RetrieveByIDs(List<int> ids)
        {
            if (ids == null || !ids.Any())
                return new List<TModel>();

            return DbSet.Where(x=>x.IsDeleted == false).Where(x => ids.Contains(x.Id));
        }
    }
}
