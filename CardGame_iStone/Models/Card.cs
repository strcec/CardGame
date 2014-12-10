using CardGame_iStone.Models.Suit;

namespace CardGame_iStone.Models
{
    public class Card
    {
        public int Number { get; set; }
        public string ImageUrl { get; set; }
        public Type SuitType { get; set; }
    }
}