using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;

namespace MHalas.BGM.Base.Repository
{
    public interface IBaseRepository<TModel>
        where TModel: class, IEntity
    {
        void Create(TModel model);
        TModel RetrieveByID(int id);
        IEnumerable<TModel> RetrieveByIDs(List<int> ids);
        void Update(TModel model);
        void Delete(int id);
    }
}
