using CardGame_iStone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public JsonResult ShuffleCards(IEnumerable<Card> sortedDeck)
        {
            var random = new Random();
            return Json(sortedDeck.OrderBy(c => random.Next()).Select(c => c).ToList(), JsonRequestBehavior.AllowGet);                                
        }

        public JsonResult SortCards(IEnumerable<Card> unsortedDeck)
        {
            return Json(unsortedDeck.OrderBy(t => t.SuitType).ThenBy(t => t.Number).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}