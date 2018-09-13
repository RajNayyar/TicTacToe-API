using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Controllers
{

    [Produces("application/json")]
    [Route("api/GameSession")]
  
    public class GameSessionController : Controller
    {
        Game game = new Game();
        [Authorize]
        [Logging]
        [Exception]
        [HttpPut]
        public string InGame([FromBody]int move)
        {
           string result = game.game(HttpContext.Request.Headers["AccessToken"].ToString(), move);
           return result;
        }
    }
}