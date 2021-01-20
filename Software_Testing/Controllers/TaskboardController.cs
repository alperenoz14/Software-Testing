using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            return View();
        }

        public IActionResult Card()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(Card card)
        {
            //geçen süre hesaplanacak...
            //
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
    }
}