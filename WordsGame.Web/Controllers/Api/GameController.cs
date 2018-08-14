using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordsGame.Entities;
using WordsGame.Services.Interfaces;
using Microsoft.AspNet.Identity;
using WordsGame.Web.Core;
using Newtonsoft.Json;

namespace WordsGame.Web.Controllers.Api
{
    [WebAPIAuthorizeAttribute]
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        // POST /api/game/{id}
        [HttpGet]
        public IHttpActionResult GetGameData(int id)
        {
            Round round = this._gameService.GetRoundById(id);

            return Ok<Round>(round);
        }

        // POST /api/game
        [HttpPost]
        public IHttpActionResult CreateGame()
        {
            Round round = this._gameService.CreateGame(User.Identity.GetUserId());

            return Created<Round>(new Uri(String.Format("{0}/{1}", Request.RequestUri, round.Id)), round);
        }

        // PUT /api/game
        [HttpPut]
        public IHttpActionResult SaveGame(int id, [FromBody] List<string> words)
        {
            
            Round round = this._gameService.GetRoundById(id);                        
            round.RoundInfo = JsonConvert.SerializeObject(words);

            this._gameService.FinishGame(round);

            return Ok();
        }
    }
}
