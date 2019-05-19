using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch11CardLib
{
    public class Card : ICloneable
    {
        private readonly Rank rank;
        private readonly Suit suit;

        private Card()
        {
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        public object Clone() => MemberwiseClone();
    }
}