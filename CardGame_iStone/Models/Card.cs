using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame_iStone.Models
{
    public class Card
    {
        public int Number { get; set; }
        public string ImageUrl { get; set; }
       public Suits.SuitType SuitType { get; set; }
    }
}