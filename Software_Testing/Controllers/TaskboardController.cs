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


        public TaskboardController(DBContext dBContext)             //db bağlantısı için oluşturulan contextin dependency injection işlemi...
        {
            _dbcontext = dBContext;
        }
        public IActionResult Board()                                //Kartların taskboarda getirildiği metod...
        {
            var cards = _dbcontext.Cards.OrderByDescending(x => x.ID).ToList();
            return View(cards);
        }

        public IActionResult Card()                             //Kart ekleme ekranı get methodu...
        {
            return View();
        }

        [HttpPost]
        public IActionResult Card(Card card)                    //Yeni kart eklenme işleminin yapıldığı psot metodu...
        {
            var service = new GuessService();
            card.guessedTime = service.Guess(card.description);     //iş süresi tahminini methodunun çağırılması...
            card.dateTime = DateTime.Now;                           //kart ekleme tarihinin eklenmesi
            _dbcontext.Add(card);
            _dbcontext.SaveChanges();
            return RedirectToAction("Board", "Taskboard");          //Board sayfasına yönlendirme
        }

        public IActionResult Detail(int id)
        {
            var cardDetail = _dbcontext.Cards.Where(card => card.ID == id).ToList();
            return View(cardDetail);
        }

        [HttpGet]
        public IActionResult Update(int id)                 //güncellenecek kartın getirildiği metod...
        {
            HttpContext.Session.SetInt32("cardId", id);
            var cardUpdate = _dbcontext.Cards.Where(card => card.ID == id).ToList();
            var model = cardUpdate[0];
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Card card)              //kart bilgilerini güncelleme işlemini yapan post metodu...
        {
            var updatedCard = _dbcontext.Cards.Find(card.ID);
            updatedCard.name = card.name;
            updatedCard.expertName = card.expertName;
            updatedCard.description = card.description;
            updatedCard.notes = card.notes;
            _dbcontext.SaveChanges();
            return RedirectToAction("Board", "Taskboard");          //Board sayfasına yönlendirme...
        }

    }
    public class GuessService
    {
        public string Guess(string desc)
        {
            string s = desc;                //açıklamadaki kelime sayısı hesaplanması...
            string[] coutn = s.ToString().Split(' ');
            int i = coutn.Count();
            if (i <= 20)                        //açıklamadaki kelime sayısına göre iş süresi tahmini yapılır...
            {                                       
                return "1-3 Gün";               
            }
            else if (20 < i && i <= 40)
            {
                return "3-5 Gün";
            }
            else if (40 < i)
            {
                return "5-7 Gün";
            }
            return "";        }

    }
}