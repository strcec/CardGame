using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame_iStone.Models
{
    public class Suits : Deck
    {
  
            public SuitType Suit;
            public List<Card> Cards;
  
        public enum SuitType
        {
            Clubs = 1,
            Spades,
            Hearts,
            Diamonds
        };
    }
}