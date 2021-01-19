using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Software_Testing.Controllers
{
    public class TaskboardController : Controller
    {
        public IActionResult Board()
        {

            return View();
        }
    }
}