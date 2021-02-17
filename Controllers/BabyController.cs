using Baby_Tracker.Data;
using Baby_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Baby_Tracker.Controllers
{
    public class BabyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly AuthenticationDbContext _db2;

        public BabyController(ApplicationDbContext db, AuthenticationDbContext db2)
        {
            _db = db;
            _db2 = db2;
        }
        public IActionResult Index()
        {
            /*
            List<Baby> baby_list;
            baby_list = GetBabies();

            if (baby_list.Count == 0)
            {
                return RedirectToAction("CreateBaby", "Baby");
            }

            else if (baby_list.Count == 1)
            {
                return RedirectToAction("BabyLanding", "Baby");
            }
            
            else if (baby_list.Count > 1)
            {
                return RedirectToAction("BabiesLanding", "Baby");
            }
            else
            {
                
            }
            */
            return RedirectToAction("Index", "Home");
        }

        // GET babies/CreateBaby No HttpMethod because in this instance there is no baby to retreive.
        public IActionResult CreateBaby()
        {
            return View();
        }

        // POST babies/CreateBaby
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateBaby")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBabyAsync(Models.Baby baby)
        {
            if (ModelState.IsValid)
            {
                baby.BabyId = Guid.NewGuid();
                baby.OwnerId1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
                baby.DateAdded = DateTime.Now;
                _db.Baby.Add(baby);
                await _db.SaveChangesAsync();

                return RedirectToAction("BabyLanding", "Baby");
            }

            return RedirectToAction();
        }
    

        public async Task<IActionResult> BabyLanding(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var baby = await _db.Baby
                .Include(s => s.Sleeps)
                .ThenInclude(i => i.Interventions)
                .Include(f => f.Feeds)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BabyId == id);
            /*
            var babies = await _db.Baby.ToListAsync();
            if (id == null)
            {
                babies[0].BabyId;
                return View(babies[0]);
            }
            var babySearch = babies.Where(b => b.BabyId == id);

            foreach (Baby baby in babySearch)
            {
                Baby babe = baby;
                return View(babe);
            }
                
            */
            return View(baby);
        }

        public async Task<IActionResult> BabiesLanding()
        {
            
            return View(await _db.Baby.ToListAsync());
        }
    }

}
