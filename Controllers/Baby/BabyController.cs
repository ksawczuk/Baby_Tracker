using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Controllers.Babies
{
    public class BabyController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
