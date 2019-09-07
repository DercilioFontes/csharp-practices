using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ch17Ex01b.Controllers
{
    [Route("api/[controller]")]
    public class HandOfCardsController : Controller
    {
        // GET: api/handofcards/{playerName}
        // Exampple call: https://ch17ex01-b.azurewebsites.net/api/handofcards/Dercilio
        [HttpGet("{playerName}")]
        public IEnumerable<Card> GetHandOfCards(string playerName)
        {
            Player[] players = new Player[1];
            players[0] = new Player(playerName);
            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();
            var handOfCards = players[0].PlayHand;
            return handOfCards;
        }
    }
}
