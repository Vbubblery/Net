using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synchronic_World.Models;
using System.Collections;
using System.Threading;

namespace Synchronic_World.Controllers
{
    public class EventController : Controller
    {
        private SynchronicContext db = new SynchronicContext();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View(db.EventSystems.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            if (eventsystem == null)
            {
                return HttpNotFound();
            }
            Session["EventId"] = eventsystem.ID;
            return View(eventsystem);
        }

        public ActionResult Join() {
            PersonSystem ps = new PersonSystem();
            int ss = (int)Session["UserId"];
            ps=db.PersonSystems.Find(ss);
            ps.EventID = (int)Session["EventId"];
            db.Entry(ps).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Event/Details/"+(int)Session["EventId"]);
        }
        public JsonResult AllContribution() {
            List<ContributionSystem> LCS = new List<ContributionSystem>();
            int id =(int)Session["EventId"];
            var CS = db.ContributionSystems.Where(b => b.EventId == id);
            if (CS == null) {
                return null;
            }
            foreach (var key in CS) {
                ContributionSystem tmp = new ContributionSystem();
                tmp.ID = key.ID;
                tmp.Name = key.Name;
                tmp.Quantity = key.Quantity;
                LCS.Add(tmp);
            }
            return Json(LCS,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(EventSystem eventsystem)
        {
            if (ModelState.IsValid)
            {
                //1:pending,2:closed,3:open
                eventsystem.StatusId = 1;
                db.TypeOfEvents.Add(eventsystem.TypeOfEvent);
                db.EventSystems.Add(eventsystem);
                db.SaveChanges();
                PersonSystem oneperson = db.PersonSystems.Find((int)Session["UserId"]);
                EventSystem tmp = db.EventSystems.Where(b=>b.Name==eventsystem.Name).FirstOrDefault();
                oneperson.EventID = tmp.ID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsystem);
        }


        public JsonResult EventFriend() { 
           ArrayList tmp = new ArrayList();
            int ss = (int)Session["EventID"];
            var ListPerson = db.PersonSystems.Where(b=>b.EventID==ss);
            if (ListPerson == null) {
                return null;
            }
            foreach(var key in ListPerson){
                tmp.Add(key.Name);
            }
        return Json(tmp,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id = 0)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            if (eventsystem == null)
            {
                return HttpNotFound();
            }
            return View(eventsystem);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(EventSystem eventsystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsystem);
        }
        public ActionResult Delete(int id = 0)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            if (eventsystem == null)
            {
                return HttpNotFound();
            }
            return View(eventsystem);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            db.EventSystems.Remove(eventsystem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Invite() {
            List<FriendSystem> LFS = new List<FriendSystem>();
            int MyId = (int)Session["UserId"];
            var que = db.FriendSystems.Where(b => b.PersonId == MyId);
             SynchronicContext db2 = new SynchronicContext();
            foreach (var key in que) {
                PersonSystem tmp = db2.PersonSystems.Where(b => b.Name == key.FriendName).FirstOrDefault();
                tmp.EventID = (int)Session["EventId"];
                db2.Entry(tmp).State = EntityState.Modified;
                db2.SaveChanges();
            }
            return Redirect("/Event/Details/" + (int)Session["EventId"]);
        }
        public ActionResult open(int id = 0)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            eventsystem.StatusId = 3;
            db.Entry(eventsystem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult closed(int id = 0)
        {
            EventSystem eventsystem = db.EventSystems.Find(id);
            eventsystem.StatusId = 2;
            db.Entry(eventsystem).State = EntityState.Modified;
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