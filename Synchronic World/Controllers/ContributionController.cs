using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synchronic_World.Models;

namespace Synchronic_World.Controllers
{
    public class ContributionController : Controller
    {
        private SynchronicContext db = new SynchronicContext();

        //
        // GET: /Contribution/

        public ActionResult Index()
        {
            return View(db.ContributionSystems.ToList());
        }

        //
        // GET: /Contribution/Details/5

        public ActionResult Details(int id = 0)
        {
            ContributionSystem contributionsystem = db.ContributionSystems.Find(id);
            if (contributionsystem == null)
            {
                return HttpNotFound();
            }
            return View(contributionsystem);
        }

        //
        // GET: /Contribution/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contribution/Create

        [HttpPost]
        public ActionResult Create(ContributionSystem contributionsystem)
        {
            if (ModelState.IsValid)
            {
                contributionsystem.EventId = (int)Session["EventId"];
                db.ContributionSystems.Add(contributionsystem);
                db.SaveChanges();
                return Redirect("/Event/Details/"+(int)Session["EventId"]);
            }
            return View(contributionsystem);
        }

        //
        // GET: /Contribution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ContributionSystem contributionsystem = db.ContributionSystems.Find(id);
            if (contributionsystem == null)
            {
                return HttpNotFound();
            }
            return View(contributionsystem);
        }

        //
        // POST: /Contribution/Edit/5

        [HttpPost]
        public ActionResult Edit(ContributionSystem contributionsystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contributionsystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contributionsystem);
        }

        //
        // GET: /Contribution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ContributionSystem contributionsystem = db.ContributionSystems.Find(id);
            if (contributionsystem == null)
            {
                return HttpNotFound();
            }
            return View(contributionsystem);
        }

        //
        // POST: /Contribution/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ContributionSystem contributionsystem = db.ContributionSystems.Find(id);
            db.ContributionSystems.Remove(contributionsystem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}