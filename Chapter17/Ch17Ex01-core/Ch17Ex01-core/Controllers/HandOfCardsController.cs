using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ch17Ex01_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandOfCardsController : ControllerBase
    {
        [HttpGet("{playerName}")]
        public string GetHandOfCards(string playerName)
        {
            Player[] players = new Player[1];
            players[0] = new Player(playerName);
            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();
            var handOfCards = players[0].PlayHand;
            return JsonConvert.SerializeObject(handOfCards);
        }
    }
}