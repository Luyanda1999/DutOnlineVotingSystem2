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
    public class CandidatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Candidates
        public async Task<ActionResult> Index()
        {
            return View(await db.Candidates.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = await db.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            return View(candidates);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,IsSubscribedToNewsletter,GetMembershipType,MembershipTypeId,partyName")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidates);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = await db.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,IsSubscribedToNewsletter,GetMembershipType,MembershipTypeId,partyName")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidates).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidates candidates = await db.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return HttpNotFound();
            }
            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Candidates candidates = await db.Candidates.FindAsync(id);
            db.Candidates.Remove(candidates);
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
