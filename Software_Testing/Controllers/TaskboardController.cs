using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Testing.Context;
using Software_Testing.Models;

namespace Software_Testing.Controllers
{
    public class TaskboardController : Controller
    {
        private readonly DBContext _dbcontext;
        public TaskboardController(DBContext dBContext)
        {
            _dbcontext = dBContext;
        }
        public IActionResult Board()
        {
            var cards = _dbcontext.Cards.OrderByDescending(x=>x.ID).ToList();
            return View(cards);
        }

        public IActionResult Card()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(Card card)
        {
            //geçen süre hesaplanacak...
            string s = card.description;            //açıklamadaki kelime sayısına göre süre tahminlemesi yapılır...
            string[] coutn = s.ToString().Split(' ');
            int i = coutn.Count();
            if (i<=20)
            {
                card.guessedTime = "1-3 Gün";
            }
            else if(20<i && i<=40)
            {
                card.guessedTime = "3-5 Gün";
            }
            else if (40<i)
            {
                card.guessedTime = "5-7 Gün";
            }
            card.dateTime = DateTime.Now;
            _dbcontext.Add(card);
            _dbcontext.SaveChanges();
            return RedirectToAction("Board","Taskboard");
        }

        public IActionResult Detail(int id)
        {
            var cardDetail =  _dbcontext.Cards.Where(card => card.ID == id).ToList();
            return View(cardDetail);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            HttpContext.Session.SetInt32("cardId", id);
            var cardUpdate = _dbcontext.Cards.Where(card => card.ID == id).ToList();
            var model = cardUpdate[0];
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Card card)
        {
            var updatedCard = _dbcontext.Cards.Find(card.ID);
            updatedCard.name = card.name;
            updatedCard.expertName = card.expertName;
            updatedCard.description = card.description;
            updatedCard.notes = card.notes;
            _dbcontext.SaveChanges();
            return RedirectToAction("Board", "Taskboard");
        }
    }
}