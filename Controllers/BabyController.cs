using Baby_Tracker.Data;
using Baby_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
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

            List<Baby> _baby_list;
            _baby_list = GetBabies();

            if (_baby_list.Count == 0)
            {
                return RedirectToAction("CreateBaby", "Baby");
            }

            else if (_baby_list.Count == 1)
            {
                return RedirectToAction("BabyLanding", "Baby");
            }
            
            else if (_baby_list.Count > 1)
            {
                return RedirectToAction("BabiesLanding", "Baby");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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

                // grab the current user record from Identity db.
                var user = await _db2.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // update BabyId field in current user record.
                user.BabyId = baby.BabyId;
                _db2.Users.Update(user);
                await _db2.SaveChangesAsync();


                return RedirectToAction("BabyLanding", "Baby");
            }

            return RedirectToAction();
        }
    

        public IActionResult BabyLanding()
        {

            List<Baby> babies;
            babies = GetBabies();
            Baby baby = babies[0];
            return View(baby);
        }

        public IActionResult BabiesLanding()
        {
            List<Baby> babies;
            babies = GetBabies();
            return View(babies);
        }

        // Method to get a list of babies from the db baby table where the current user has access rights. 
        // Can this be handled with an async method?
        // This should be converted to an IQueryable variable. In this way it won't make a call to the db until an async method such as 
        // ToListAsync() is called and a collection is created.
        private List<Baby> GetBabies()
        {
            var currentUser = _db2.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Baby> babyQuery = // this could be an IQueryable.
                 from user_baby in _db.Baby
                 where ((user_baby.OwnerId1 == currentUser.Id) | (user_baby.OwnerId2 == currentUser.Id) | (user_baby.OwnerId3 == currentUser.Id))
                 select user_baby;

            List<Baby> baby_list = new List<Baby>(); // this should be able to be replaced with ToListAsync instead of a foreach to build the collection. 
                                                     // currently this looks like a mishmash of techniques.
            foreach (Baby user_baby in babyQuery)
            {
                baby_list.Add(user_baby);
            }
            return baby_list;
        } 
    }

}
