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
                
        // GET Start Feed event.
        public IActionResult StartFeed(Guid babyId, Guid? sleepId)
        {
            
            if(sleepId != null)
            {
                return RedirectToAction("StartFeedPost", "Feed", new RouteValueDictionary(
                    new {controller="Feed", action="StartFeedPost", babyId = babyId, sleepId=sleepId }));
            }
            

            return View();
        }
        
        // POST Feed event.
        [HttpPost, ActionName("StartFeedPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartFeedAsync(Guid babyId, Guid? sleepId, [Bind("BabyId,IsDreamFeed")] Feed feed)
        {
            
            if (babyId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                feed.FeedId = babyId;
                feed.StartTime = DateTime.Now;

                if (sleepId != null)
                {
                    feed.IsDreamFeed = true;
                    feed.SleepId = sleepId;
                }
            

                _db.Add(feed);
                await _db.SaveChangesAsync();

                if (feed.IsDreamFeed)
                {
                    return RedirectToAction("FeedLanding", "Feed", new RouteValueDictionary(
                    new { controller = "Feed", action = "FeedLanding", id = feed.FeedId, sleepId = feed.SleepId }));
                }
                else
                {
                    return RedirectToAction("FeedLanding", "Feed", new RouteValueDictionary(
                    new { controller = "Feed", action = "FeedLanding", id = feed.FeedId }));
                }
            }

            return View();
        }

        // GET for FeedLanding 
        [HttpGet]
        public async Task<IActionResult> FeedLanding(Guid id, Guid? sleepId)
        {
            Feed feed = await _db.Feed.FindAsync(id);

            return View(feed);
        }

        // POST For FeedLanding. User updates Feed details and ends feed.
        [HttpPost, ActionName("FeedLanding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FeedLandingPost(Guid? id, string sleepId, [Bind(include: "LatchQuality,ChinEngagement,Alertness,Fussiness")] Feed feed)

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
            if (sleepId != null)
            {
                feedToUpdate.SleepId = Guid.Parse(sleepId);
            }

            if (await TryUpdateModelAsync<Feed>(
                feedToUpdate,
                "LatchQuality,ChinEngagement,Alertness,Fussiness",
                f => f.LatchQuality, f => f.ChinEngagement, f => f.Alertness, f => f.Fussiness))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    if (feedToUpdate.IsDreamFeed)
                    {
                        return RedirectToAction("SleepLanding", "Sleep", new { id = feedToUpdate.SleepId, babyId = feedToUpdate.BabyId });
                    }
                    else
                    {
                        return RedirectToAction("BabyLanding", "Baby", new { id = feedToUpdate.BabyId });
                    }
                    
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
