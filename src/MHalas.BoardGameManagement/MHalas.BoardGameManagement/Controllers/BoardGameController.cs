using MHalas.BGM.Base.Enum;
using MHalas.BGM.Base.Exceptions;
using MHalas.BGM.Base.Repository;
using MHalas.BGM.EntityFramework;
using MHalas.BoardGameManagement.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MHalas.BoardGameManagement.Controllers
{
    public class BoardGameController : Controller
    {
        private IBoardGameRepository _boardGameRepository;
        private IBoardGameLogRepository _boardGameLogRepository;

        public BoardGameController(IBoardGameRepository boardGameRepository,
            IBoardGameLogRepository boardGameLogRepository)
        {
            _boardGameRepository = boardGameRepository;
            _boardGameLogRepository = boardGameLogRepository;
        }

        public ActionResult Index()
        {
            var boardGames = _boardGameRepository.Retrieve(isDeleted:false);

            var modelList = boardGames.Select(x => new BoardGameViewModel()
            {
                Id = x.Id,
                Author = x.Author,
                Description = x.Description,
                IsDeleted = x.IsDeleted,
                Name = x.Name,
                PlayerMinimalAge = x.PlayerMinimalAge
            });

            return View(modelList);
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                BoardGame boardGame = _boardGameRepository.RetrieveByID(id.Value);
                var model = MapToModel(new BoardGameViewModel(), boardGame);

                _boardGameLogRepository.Create(new BoardGameLog()
                {
                    BoardGameId = boardGame.Id,
                    Date = DateTime.Now,
                    Source = (int)ESource.WWW,
                });

                model.BoardGameLogs = _boardGameLogRepository.GetBoardGameTopLogs(id.Value).Select(x=> new BoardGameLogViewModel()
                {
                    Date = x.Date,
                    Source = (ESource)x.Source
                });

                return View(model);
            }
            catch (NotFoundInDatabaseException ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoardGameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var boardGame = MapFromModel(new BoardGame(), model);
                    _boardGameRepository.Create(boardGame);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                BoardGame boardGame = _boardGameRepository.RetrieveByID(id.Value);

                if (boardGame == null)
                    return HttpNotFound();


                var model = MapToModel(new BoardGameViewModel(), boardGame);
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoardGameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var boardGame = _boardGameRepository.RetrieveByID(model.Id);
                    boardGame = MapFromModel(boardGame, model);
                    _boardGameRepository.Update(boardGame);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                BoardGame boardGame = _boardGameRepository.RetrieveByID(id.Value);

                if (boardGame == null)
                    return HttpNotFound();

                var model = MapToModel(new BoardGameViewModel(), boardGame);
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _boardGameRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private BoardGameViewModel MapToModel(BoardGameViewModel model, BoardGame boardGame)
        {
            model.Id = boardGame.Id;
            model.Author = boardGame.Author;
            model.Description = boardGame.Description;
            model.IsDeleted = boardGame.IsDeleted;
            model.Name = boardGame.Name;
            model.PlayerMinimalAge = boardGame.PlayerMinimalAge;

            return model;
        }

        private BoardGame MapFromModel(BoardGame boardGame, BoardGameViewModel model)
        {
            boardGame.Id = model.Id;
            boardGame.Author = model.Author;
            boardGame.Description = model.Description;
            boardGame.IsDeleted = model.IsDeleted;
            boardGame.Name = model.Name;
            boardGame.PlayerMinimalAge = model.PlayerMinimalAge;

            return boardGame;
        }
    }
}
