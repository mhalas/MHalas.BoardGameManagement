using MHalas.BGM.EntityFramework;
using System.Collections.Generic;

namespace MHalas.BGM.Base.Repository
{
    public interface IBoardGameLogRepository : IBaseHardDeleteRepository<BoardGameLog>
    {
        IEnumerable<BoardGameLog> GetBoardGameTopLogs(int boardGameID, int count = 10);
    }
}
