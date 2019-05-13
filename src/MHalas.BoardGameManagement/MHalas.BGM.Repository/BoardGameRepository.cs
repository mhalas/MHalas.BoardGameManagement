using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;

namespace MHalas.BGM.Repository
{
    public class BoardGameRepository : BaseSoftDeleteRepository<BoardGame>, IBoardGameRepository
    {
        public BoardGameRepository(BoardGameManagementEntities entities) 
            : base(entities)
        {
        }
    }
}
