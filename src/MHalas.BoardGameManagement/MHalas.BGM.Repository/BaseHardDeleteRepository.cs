using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;
using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;
using System.Linq;

namespace MHalas.BGM.Repository
{
    public abstract class BaseHardDeleteRepository<TModel> : BaseRepository<TModel>, IBaseHardDeleteRepository<TModel>
        where TModel : class, IEntity
    {
        public BaseHardDeleteRepository(BoardGameManagementEntities entities) : base(entities)
        {
        }

        public IEnumerable<TModel> Retrieve(int? count = null)
        {
            if (count.HasValue)
                return DbSet.Take(count.Value).AsEnumerable();

            return DbSet.AsEnumerable();
        }

        public override void Delete(int id)
        {
            var element = RetrieveByID(id);

            DbSet.Remove(element);
            Entities.SaveChanges();
        }
    }
}
