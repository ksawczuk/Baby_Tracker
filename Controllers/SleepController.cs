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
    public class SleepController : Controller
    {
        // Dependecy Injection for baby_db CRUD ops. 
        private readonly ApplicationDbContext _db;

        public SleepController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET Start sleep event. babyId passed with Action.
        [HttpGet]
        public IActionResult StartSleep(Guid id)
        {

            ViewData["BabyId"] = id;
            return View();
        }

        // POST Start sleep event.
        [HttpPost, ActionName("StartSleep")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartSleepAsync(Guid id, [Bind("BabyId")] Sleep sleep)
        {
            // if no id passed.
            if (id == null)
            {
                return NotFound();
            }

            // ModelState as per ValidateAntiForgeryToken
            if (ModelState.IsValid)
            {

                sleep.SleepId = Guid.NewGuid();
                sleep.BabyId = id;
                sleep.StartTime = DateTime.Now;

                // prep data for db write.
                _db.Add(sleep);
                // write data to the db.
                await _db.SaveChangesAsync();

                return RedirectToAction("SleepLanding", "Sleep", new RouteValueDictionary(
                    new { controller = "Sleep", action = "SleepLanding", sleepId = sleep.SleepId, babyId = sleep.BabyId }));

            }

            return View();
        }

        // GET for SleepLanding
        [HttpGet]
        public async Task<IActionResult> SleepLanding(Guid sleepId, Guid babyId)
        {
            // pass in babyId via ViewData as the model in view is used for sleep data.
            ViewData["BabyId"] = babyId;
            
            // connect to db and locate the sleep event record.
            Sleep sleep = await _db.Sleep.FindAsync(sleepId);  // This is where you want to have an include for Feed table for Dream Feeds.
            return View(sleep);
        }

        // POST For SleepLanding. User updates sleep details and ends event.
        [HttpPost, ActionName("SleepLanding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SleepLandingPost(Guid? id, [Bind(include: "Interventions,SleepFeeds")] Sleep sleep)

        {
            // if no id passed
            if (id == null)
            {
                return NotFound();
            }
            // prep 
            var sleepToUpdate = await _db.Sleep.FirstOrDefaultAsync(s => s.SleepId == id);
            sleepToUpdate.EndTime = DateTime.Now;
            sleepToUpdate.Interventions = sleep.Interventions;
            sleepToUpdate.SleepFeeds = sleep.SleepFeeds;

            if (await TryUpdateModelAsync<Sleep>(
                sleepToUpdate,
                "Interventions,SLeepFeeds",
                s => s.Interventions, s => s.SleepFeeds))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction("BabyLanding", "Baby", new { id = sleepToUpdate.BabyId });
                }
                catch (DbUpdateException /* ex */)
                {
                    // Log the error (uncomment ex variable and write a log entry.)

                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, later.");
                }
            }
            return View(sleepToUpdate);
        }

        // Need to add Delete and Edit for Sleeps.

        // GET Start Intervention form
        [HttpGet]
        public IActionResult StartIntervention(Guid id)
        {
            ViewData["SleepId"] = id;
            return View();
        }

        // POST Start Intervention
        [HttpPost, ActionName("StartIntervention")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartInterventionAsync(Guid id, [Bind("BabyId,SleepId,IsNap")] Intervention intervention)
        {

            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                intervention.InterventionId = Guid.NewGuid();
                intervention.SleepId = id;
                intervention.StartTime = DateTime.Now;


                _db.Add(intervention);
                await _db.SaveChangesAsync();

                return RedirectToAction("InterventionLanding", "Sleep", new RouteValueDictionary(
                    new { controller = "Sleep", action = "InterventionLanding", id = intervention.InterventionId }));
            }

            return View();
        }

        // GET for InterventionLanding
        [HttpGet]
        public async Task<IActionResult> InterventionLanding(Guid id)
        {
            Intervention intervention = await _db.Intervention.FindAsync(id);
            return View(intervention);
        }

        // POST For InterventionLanding. User updates Intervention details and ends intervention.
        // This all needs to be updated to be intervention specific.
        //Need to add intervention to Sleep record.

        [HttpPost, ActionName("InterventionLanding")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InterventionLandingPost(Guid? id, [Bind(include: "FirstTry,SecondTry,ThirdTry,FourthTry")] Intervention intervention)
        {
            if (id == null)
            {
                return NotFound();
            }
            var interventionToUpdate = await _db.Intervention.FirstOrDefaultAsync(i => i.InterventionId == id);
            interventionToUpdate.EndTime = DateTime.Now;

            if (await TryUpdateModelAsync<Intervention>(
                interventionToUpdate))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction("SleepLanding", "Sleep", new { id = interventionToUpdate.SleepId });
                }
                catch (DbUpdateException /* ex */)
                {
                    // Log the error (uncomment ex variable and write a log entry.)

                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(interventionToUpdate);
        }
    }
}

