using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Baby_Tracker.Data;
using Baby_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Controllers.Babies
{
    public class CreateBabyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly AuthenticationDbContext _db2;

        public CreateBabyController(ApplicationDbContext db, AuthenticationDbContext db2)
        {
            _db = db;
            _db2 = db2;
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
        public IActionResult CreateBaby(Baby baby)
        {
            if (ModelState.IsValid)
            {
                baby.OwnerId1 = User.FindFirstValue(ClaimTypes.NameIdentifier);
                baby.BabyId = Guid.NewGuid();
                baby.DateAdded = DateTime.Now;
                _db.Baby.Add(baby);
                _db.SaveChanges();

                // update Owner record with BabyId
                // User.Identity.BabyId = baby.BabyId; How do I write to the authentication db? Is that within the framework of a Claim?
                return RedirectToAction("~/Baby/BabyLanding", new { id = baby.BabyId }); // need to redirect to the baby just created.
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
            Baby baby = _db.Baby.Find(id);
            if (baby.Name == null)
            {
                //return HttpNotFound();
                //Find a working replacement with Microsoft.AspNetCore.Mvc;
            }
            return View(baby);
        }
    }
}
  
