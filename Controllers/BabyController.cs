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

            return View();
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


                return RedirectToAction("BabyLanding/id", new {id = baby.BabyId}); // need to redirect to the baby just created.
            }

            return RedirectToAction();
        }
    

    public IActionResult BabyLanding(Guid id)
        {
            //if (id == null)
            //{
            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            //Find a working replacement with Microsoft.AspNetCore.Mvc;
            //}

            Models.Baby baby = _db.Baby.Find(id);
            if (baby.Name == null)
            {
                //return HttpNotFound();
                //Find a working replacement with Microsoft.AspNetCore.Mvc;
            }
            return View(baby);
        }
    }
}
