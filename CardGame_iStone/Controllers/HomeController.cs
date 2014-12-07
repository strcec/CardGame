using CardGame_iStone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;


namespace CardGame_iStone.Controllers
{
    public class HomeController : Controller
    {
        string imageDirectory = "/Content/CardImages/";


        public ActionResult Index()
        {
            //utvide til å kunne sende inn usortert, få ut sortert
            var deck = OrderCardsBySuits().Suitses.OrderBy(t=>t.Suit);

            // var handCards = Directory.GetFiles(directory).Select(Image.FromFile).ToList();
            return View(new Test { kort = GetServerImageUrl() });
        }

        private string[] GetImageUrl()
        {
            var directory = ServerImageDirectory();
            return Directory.GetFiles(directory).Select(s => new Uri(s).Segments.Last()).ToArray();
        }

        private string[] GetServerImageUrl()
        {
            var directory = ServerImageDirectory();
            return Directory.GetFiles(directory).OrderBy(s => s).Select(s => imageDirectory + new Uri(s).Segments.Last()).ToArray();

        }

        private string ServerImageDirectory()
        {
            return HttpContext.Server.MapPath("~" + imageDirectory);
        }

        private Deck OrderCardsBySuits()
        {
            var urlToImages = GetImageUrl();

            // url.ToString().Split('-').ElementAt(0); ==> returns "1"


            var clubsPrefix = (int) Suits.SuitType.Clubs;
            var spadesPrefix = (int) Suits.SuitType.Spades;
            var heartsPrefix = (int) Suits.SuitType.Hearts;
            var diamondPrefix = (int) Suits.SuitType.Diamonds;

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

            return deck;
        }

        public string[] ShuffleCard()
        {
            var rand = new Random();
            return GetServerImageUrl().OrderBy(c => rand.Next()).Select(c => c).ToArray();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}