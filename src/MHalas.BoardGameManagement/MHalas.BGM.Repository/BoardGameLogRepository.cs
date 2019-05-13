using System.Collections.Generic;
using System.Linq;
using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;

namespace MHalas.BGM.Repository
{
    public class BoardGameLogRepository : BaseHardDeleteRepository<BoardGameLog>, IBoardGameLogRepository
    {
        public BoardGameLogRepository(BoardGameManagementEntities entities) 
            : base(entities)
        {
        }

        public IEnumerable<BoardGameLog> GetBoardGameTopLogs(int boardGameID, int count = 10)
        {
            return DbSet.OrderByDescending(x => x.Id).Where(x => x.BoardGameId == boardGameID).Take(count);
        }
    }
}
