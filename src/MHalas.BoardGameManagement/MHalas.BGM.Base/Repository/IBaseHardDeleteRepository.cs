using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;

namespace MHalas.BGM.Base.Repository
{
    public interface IBaseHardDeleteRepository<TModel> : IBaseRepository<TModel>
        where TModel : class, IEntity
    {
        IEnumerable<TModel> Retrieve(int? count = null);
    }
}
