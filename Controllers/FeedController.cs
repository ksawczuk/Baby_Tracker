using Baby_Tracker.Data;
using Baby_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> StartFeedAsync(Guid id, [Bind("BabyId,IsDreamFeed")] Feed feed)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                feed.FeedId = Guid.NewGuid();
                feed.BabyId = id;
                feed.StartTime = DateTime.Now;
            

                _db.Add(feed);
                await _db.SaveChangesAsync();

                return RedirectToAction("FeedLanding", "Feed", new RouteValueDictionary(
                    new { controller = "Feed", action = "FeedLanding", id = feed.FeedId }));

                //new { id = feed.FeedId }
            }

            return View();
        }

        // GET for FeedLanding
        [HttpGet]
        public async Task<IActionResult> FeedLanding(Guid id)
        {
            Feed feed = await _db.Feed.FindAsync(id);
            return View(feed);
        }

        // POST For FeedLanding. User updates Feed details and ends feed.
        [HttpPost, ActionName("FeedLanding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FeedLandingPost(Guid? id, [Bind(include: "LatchQuality,ChinEngagement,Alertness,Fussiness")] Feed feed)

        {
            if (id == null)
            {
                return NotFound();
            }
            var feedToUpdate = await _db.Feed.FirstOrDefaultAsync(f => f.FeedId == id);

            feedToUpdate.EndTime = DateTime.Now;
            feedToUpdate.LatchQuality = feed.LatchQuality;
            feedToUpdate.ChinEngagement = feed.ChinEngagement;
            feedToUpdate.Alertness = feed.Alertness;
            feedToUpdate.Fussiness = feed.Fussiness;

            if (await TryUpdateModelAsync<Feed>(
                feedToUpdate,
                "LatchQuality,ChinEngagement,Alertness,Fussiness",
                f => f.LatchQuality, f => f.ChinEngagement, f => f.Alertness, f => f.Fussiness))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction("BabyLanding", "Baby", new { id = feedToUpdate.BabyId });
                }
                catch (DbUpdateException /* ex */)
                {
                    // Log the error (uncomment ex variable and write a log entry.)

                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                } 
            }
            return View(feedToUpdate);
        }
    }
}
