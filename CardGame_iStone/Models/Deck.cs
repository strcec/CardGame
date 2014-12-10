using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame_iStone.Models
{
    public class Deck
    {
        private const string ImageDirectory = "/Content/CardImages/";

        public Deck()
        {
            
        }
        public Deck(IEnumerable<string> imageUrl)
        {
            Cards = new List<Card>();
            foreach (var c in imageUrl.Select(card => new Card
            {
                ImageUrl = ImageDirectory + card,
                Number = Convert.ToInt32(string.Format("{0}{1}", card[2], card[3])),
                SuitType = (Suit.Type)Convert.ToInt32(card.Split('-').ElementAt(0))
            }))
            {
                Cards.Add(c);
            }
        }

        public List<Card> Cards { get; set; }
    }
}