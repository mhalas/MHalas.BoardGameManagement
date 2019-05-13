using MHalas.BGM.EntityFramework.Base;
using System.Collections.Generic;

namespace MHalas.BGM.Base.Repository
{
    public interface IBaseSoftDeleteRepository<TModel>: IBaseRepository<TModel>
        where TModel: class, IEntity, IIsDeleted
    {
        IEnumerable<TModel> Retrieve(int? count = null, bool? isDeleted = null);
    }
}
