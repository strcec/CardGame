using CardGame_iStone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace CardGame_iStone.Controllers
{
    public class HomeController : Controller
    {
        private const string ImageDirectory = "/Content/CardImages/";


        public ActionResult Index()
        {
            return View(CreateDeck());
        }

        private IEnumerable<string> GetImageUrl()
        {
            return Directory.GetFiles(HttpContext.Server.MapPath("~" + ImageDirectory)).Select(s => new Uri(s).Segments.Last()).ToArray();
        }

        private Deck CreateDeck()
        {
            var urlToImages = GetImageUrl();
            var deck = new Deck {Cards = new List<Card>()};

            foreach (var card in urlToImages)
            {
                var c = new Card
                {
                    ImageUrl = ImageDirectory + card,
                    Number = Convert.ToInt32(string.Format("{0}{1}", card[2], card[3])),
                    SuitType = (Suits.SuitType)Convert.ToInt32(card.Split('-').ElementAt(0))
                };
                deck.Cards.Add(c);
            }
            return deck;
        }
        [HttpPost]
        public ActionResult ShuffleCards(List<Card> sortedDeck)
        {
            
            var rand = new Random();
            var deck = CreateDeck().Cards.OrderBy(c => rand.Next()).Select(c => c).ToList();
            return Json(deck, JsonRequestBehavior.AllowGet);
        }

        public Deck SortCards(Deck unsortedDeck)
        {
            return new Deck
            {
                Cards = unsortedDeck.Cards.OrderBy(t => t.SuitType).ThenBy(t => t.Number).ToList()
            };
        }


        /* private string[] GetServerImageUrl()
         {
             var directory = ServerImageDirectory();
             return Directory.GetFiles(directory).OrderBy(s => s).Select(s => ImageDirectory + new Uri(s).Segments.Last()).ToArray();

         }*/
        //var deck = OrderCardsBySuits().Suitses.OrderBy(t=>t.Suit);
        /*            var clubsPrefix = (int)Suits.SuitType.Clubs;
                        var spadesPrefix = (int)Suits.SuitType.Spades;
                        var heartsPrefix = (int)Suits.SuitType.Hearts;
                        var diamondPrefix = (int)Suits.SuitType.Diamonds;

                        var clubs = urlToImages.Where(s => s.StartsWith(clubsPrefix.ToString())).ToArray();
                        var spades = urlToImages.Where(s => s.StartsWith(spadesPrefix.ToString())).ToArray();
                        var hearts = urlToImages.Where(s => s.StartsWith(heartsPrefix.ToString())).ToArray();
                        var diamonds = urlToImages.Where(s => s.StartsWith(diamondPrefix.ToString())).ToArray();

                        var cardsInClubs = clubs.Select(c => Convert.ToInt32(string.Format("{0}{1}", c[2], c[3]))).Select(newNumber => new Card
                        {
                            Number = newNumber
                        }).ToList();

                        var suitsOfClubs = new Suits
                        {
                            Suit = Suits.SuitType.Clubs,
                            Cards = cardsInClubs
                        };

                        var cardsInSpades = spades.Select(s => Convert.ToInt32(string.Format("{0}{1}", s[2], s[3]))).Select(newNumber => new Card
                        {
                            Number = newNumber
                        }).ToList();


                        var suitsOfSpades = new Suits
                        {
                            Suit = Suits.SuitType.Spades,
                            Cards = cardsInSpades
                        };

                        var cardsInHearts = hearts.Select(h => Convert.ToInt32(string.Format("{0}{1}", h[2], h[3]))).Select(newNumber => new Card
                        {
                            Number = newNumber
                        }).ToList();

                        var suitsOfHearts = new Suits
                        {
                            Suit = Suits.SuitType.Hearts,
                            Cards = cardsInHearts
                        };

                        var cardsInDiamonds = diamonds.Select(d => Convert.ToInt32(string.Format("{0}{1}", d[2], d[3]))).Select(newNumber => new Card
                        {
                            Number = newNumber
                        }).ToList();

                        var suitsOfDiamond = new Suits
                        {
                            Suit = Suits.SuitType.Diamonds,
                            Cards = cardsInDiamonds
                        };


                        var deck = new Deck
                        {
                            Suitses = new List<Suits>
                            {
                                suitsOfClubs,
                                suitsOfSpades,
                                suitsOfHearts,
                                suitsOfDiamond
                            }
                        };
        }
                        */


    }
}