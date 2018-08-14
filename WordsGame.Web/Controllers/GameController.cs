using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordsGame.Data.Roles;
using WordsGame.Services.Interfaces;

namespace WordsGame.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        // GET: Game
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.UserRole))
                return View("GameView");

            var model = this._gameService.GetLastRoundForUserRole();
             
            return View("GameRecords", model);
        }
    }
}