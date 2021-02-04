using Baby_Tracker.Data;
using Baby_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Controllers
{
    public class FeedController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FeedController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        // GET
        public IActionResult StartFeed()
        {
            return View();
        }
        

        // POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartFeed(Guid id)
        {
            if (ModelState.IsValid)
            {
                Feed feed = new Feed()
                {
                    FeedId = Guid.NewGuid(),
                    BabyId = id,
                    StartTime = DateTime.Now
                };

                _db.Feed.Add(feed);
                _db.SaveChanges();
            }

            return RedirectToAction("FeedLanding", "Feed");
        }

        public IActionResult FeedLanding()
        {
            return View();
        }
    }
}
