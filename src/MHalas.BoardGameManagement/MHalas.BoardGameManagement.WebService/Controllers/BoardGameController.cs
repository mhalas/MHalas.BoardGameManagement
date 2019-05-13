using MHalas.BGM.Base.Enum;
using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;
using MHalas.BoardGameManagement.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MHalas.BoardGameManagement.WebService.Controllers
{
    [RoutePrefix("api/BoardGame")]
    public class BoardGameController : ApiController
    {
        private readonly IBoardGameRepository _boardGameRepository;
        private readonly IBoardGameLogRepository _boardGameLogRepository;

        public BoardGameController(IBoardGameRepository boardGameRepository,
            IBoardGameLogRepository boardGameLogRepository)
        {
            _boardGameRepository = boardGameRepository;
            _boardGameLogRepository = boardGameLogRepository;
        }

        [HttpGet]
        [Route("GetDetails/{id:int}")]
        [ResponseType(typeof(BoardGameDTO))]
        public IHttpActionResult GetDetails(int id)
        {
            try
            {
                var boardGame = _boardGameRepository.RetrieveByID(id);

                _boardGameLogRepository.Create(new BoardGameLog()
                {
                    BoardGameId = boardGame.Id,
                    Date = DateTime.Now,
                    Source = (int)ESource.WebService,
                });

                var dto = Map(new BoardGameDTO(), boardGame);
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpGet]
        [Route("GetAll/{count:int?}")]
        public IEnumerable<BoardGameDTO> GetAll(int? count = null)
        {
            return _boardGameRepository.Retrieve(count, false).Select(x => Map(new BoardGameDTO(), x));
        }

        private BoardGameDTO Map(BoardGameDTO dto, BoardGame boardGame)
        {
            dto.Name = boardGame.Name;
            dto.PlayerMinimalAge = boardGame.PlayerMinimalAge;
            dto.Description = boardGame.Description;
            dto.Author = boardGame.Author;
            return dto;
        }
    }
}
