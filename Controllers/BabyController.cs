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
            
            List<Baby> _baby_list = new List<Baby>();
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

            // return View();
        }

        // GET babies/CreateBaby No HttpMethod because in this instance there is no baby to retreive.
        public IActionResult CreateBaby()
        {


            return View();
        }

        // POST babies/CreateBaby
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBaby(Models.Baby baby)
        {
            if (ModelState.IsValid)
            {
                baby.BabyId = Guid.NewGuid();
                baby.OwnerId1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
                baby.DateAdded = DateTime.Now;
                _db.Baby.Add(baby);
                _db.SaveChanges();

                // grab the current user record from Identity db.
                var user = _db2.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // update BabyId field in current user record.
                user.BabyId = baby.BabyId;
                _db2.Users.Update(user);
                _db2.SaveChanges();


                return RedirectToAction("BabyLanding", "Baby");
            }

            return RedirectToAction();
        }
    

        public IActionResult BabyLanding()
        {

            List<Baby> babies = new List<Baby>();
            babies = GetBabies();
            Baby baby = babies[0];

            return View(baby);
        }

        public IActionResult BabiesLanding()
        {
            List<Baby> babies = new List<Baby>();
            babies = GetBabies();
            return View(babies);
        }


        private List<Baby> GetBabies()
        {
            var currentUser = _db2.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<Baby> babyQuery =
                 from user_baby in _db.Baby
                 where user_baby.OwnerId1 == currentUser.Id
                 select user_baby;

            List<Baby> baby_list = new List<Baby>();
            foreach (Baby user_baby in babyQuery)
            {
                baby_list.Add(user_baby);
            }
            return baby_list;
        } 
    }

}
