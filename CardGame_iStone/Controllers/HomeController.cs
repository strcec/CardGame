using CardGame_iStone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace CardGame_iStone.Controllers
{
    public class HomeController : Controller
    {
        private const string ImageDirectory = "/Content/CardImages/";

        public ActionResult Index()
        {
            if (GetImageUrl() == null || !GetImageUrl().Count().Equals(52)) return View();
            return View(new Deck(GetImageUrl()));
        }

        private IEnumerable<string> GetImageUrl()
        {
            try
            {
                return Directory.GetFiles(HttpContext.Server.MapPath("~" + ImageDirectory), "*.png")
                        .Select(s => new Uri(s).Segments.Last())
                        .ToArray();
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("Directory not found: " + dirEx.Message);
                return null;
            }
        }

        [HttpPost]
        public JsonResult ShuffleCards(Deck sortedDeck)
        {
            var random = new Random();
            return Json(sortedDeck.Cards.OrderBy(c => random.Next()).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SortCards(Deck unsortedDeck)
        {
            return Json(unsortedDeck.Cards.OrderBy(t => t.SuitType).ThenBy(t => t.Number).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}