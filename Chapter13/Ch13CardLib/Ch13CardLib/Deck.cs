using System;

namespace Ch13CardLib
{
    public delegate void LastCardDrawnHandler(Deck currentDeck);
    public class Deck : ICloneable
    {
        public event LastCardDrawnHandler LastCardDrawn;

        private Cards cards = new Cards();

        public Deck()
        {
            InsertAllCards();
            //for (int suitVal = 0; suitVal < 4; suitVal++)
            //{
            //    for (int rankVal = 1; rankVal < 14; rankVal++)
            //    {
            //        cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
            //    }
            //}
        }
        protected Deck(Cards newCards)
        {
            cards = newCards;
        }
        public int CardsInDeck
        {
            get { return cards.Count; }
        }

        ///// <summary>
        ///// Nondefault constructor. Allows aces to be set high.
        ///// </summary>
        ///// <param name="isAceHigh">If set to <c>true</c> is ace high.</param>
        //public Deck(bool isAceHigh) : this()
        //{
        //    Card.isAceHigh = isAceHigh;
        //}

        ///// <summary>
        ///// Nondefault constructor. Allows a trump suit to be used.
        ///// </summary>
        ///// <param name="useTrumps">If set to <c>true</c> use trumps.</param>
        ///// <param name="trump">Trump.</param>
        //public Deck(bool useTrumps, Suit trump) : this()
        //{
        //    Card.useTrumps = useTrumps;
        //    Card.trump = trump;
        //}

        ///// <summary>
        ///// Nondefault constructor. Allows aces to be set high and a trump suit
        ///// to be used.
        ///// </summary>
        ///// <param name="isAceHigh">If set to <c>true</c> is ace high.</param>
        ///// <param name="useTrumps">If set to <c>true</c> use trumps.</param>
        ///// <param name="trump">Trump.</param>
        //public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        //{
        //    Card.isAceHigh = isAceHigh;
        //    Card.useTrumps = useTrumps;
        //    Card.trump = trump;
        //}

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException(cards.Clone() as Cards);
        }

        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }

        private Deck(Cards newCards)
        {
            cards = newCards;
        }

        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
    }
}