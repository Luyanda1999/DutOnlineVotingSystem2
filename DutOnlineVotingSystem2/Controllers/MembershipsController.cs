using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DutOnlineVotingSystem2.Models;

namespace DutOnlineVotingSystem2.Controllers
{
    public class MembershipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Memberships
        public async Task<ActionResult> Index()
        {
            return View(await db.Memberships.ToListAsync());
        }

        // GET: Memberships/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Surname,Birthdate,StudentNumber,Gender,PhoneNumber,Email,Campus,Party")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Memberships.Add(membership);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(membership);
        }

        // GET: Memberships/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Surname,Birthdate,StudentNumber,Gender,PhoneNumber,Email,Campus,Party")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = await db.Memberships.FindAsync(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Membership membership = await db.Memberships.FindAsync(id);
            db.Memberships.Remove(membership);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
