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
    public class PersonController : Controller
    {
        private SynchronicContext db = new SynchronicContext();


        public ActionResult Index()
        {
            return View(db.PersonSystems.ToList());
        }



        public ActionResult Details(int id = 0)
        {
            PersonSystem personsystem = db.PersonSystems.Find(id);
            if (personsystem == null)
            {
                return HttpNotFound();
            }
            return View(personsystem);
        }

        [HttpPost]
        public void FindFriend(string fname)
        {
            PersonSystem PS = db.PersonSystems.Where(b => b.Name == fname).FirstOrDefault();
            Response.ContentType = "application/x-www-form-urlencoded";
            string json = "[{\"Name\": \"" + PS.Name + "\",\"Role\":\""+PS.RoleOfPerson.who+"\"}]";
            Response.Write(json);
            Response.End();
            
        }
        public void AddFriend(string friendname) {
            FriendSystem FS = new FriendSystem();
            FS.PersonId = (int)Session["UserId"];
            FS.FriendName = friendname;
            db.FriendSystems.Add(FS);
            db.SaveChanges();
            Response.Redirect("/person/friend");
            Response.End();
        }
        public void RemoveFriend(string friendname)
        {
            FriendSystem FS = new FriendSystem();
            FS=db.FriendSystems.Where(b=>b.FriendName==friendname).FirstOrDefault();
            db.FriendSystems.Remove(FS);
            db.SaveChanges();
            Response.Redirect("/person/friend");
            Response.End();
        }
        public JsonResult AllPerson()
        {
           List<FriendSystem> FS =new List<FriendSystem>();
           int id = (int)Session["UserId"];
           var qy = db.FriendSystems.Where(b => b.PersonId == id);
           foreach (var b in qy) {
               FriendSystem tmp = new FriendSystem();
               tmp.FriendName = b.FriendName;
               tmp.ID = b.ID;
               tmp.PersonId = b.PersonId;
               FS.Add(tmp);
           }

            return Json(FS,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult NewFriend(string name)
        {
            try
            {
                FriendSystem tmp = new FriendSystem();
                tmp.FriendName = name;
                tmp.PersonId = (int)Session["UserId"];
                db.FriendSystems.Add(tmp);
                ModelState.AddModelError("success", "success");
            }
            catch {
                ModelState.AddModelError("error", "error");
            }
            return View();
        }
        public ActionResult Friend()
        {
            return View();
            
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(PersonSystem personsystem)
        {
            if (ModelState.IsValid)
            {
                personsystem.EventID = 0 ;
                db.RoleOfPerson.Add(personsystem.RoleOfPerson);
                db.PersonSystems.Add(personsystem);
                db.SaveChanges();
                return Redirect("/Person/Login");
            }

            return View(personsystem);
        }

        public ActionResult Edit(int id = 0)
        {
            PersonSystem personsystem = db.PersonSystems.Find(id);
            if (personsystem == null)
            {
                return HttpNotFound();
            }
            return View(personsystem);
        }
        public ActionResult Profile() {
            string username=(string)Session["username"];
            int userid = (int)Session["UserId"];
            return Redirect("/Person/Edit/" + userid);
        }

        [HttpPost]
        public ActionResult Edit(PersonSystem personsystem)
        {

            if (ModelState.IsValid)
            {
                db.Entry(personsystem).State = EntityState.Modified;
                db.SaveChanges();
                if ((string)Session["role"] == "admin")
                {
                    return RedirectToAction("Index");
                }
                else {
                    return Redirect("/Home/index");
                }
                
            }
            return View(personsystem);
        }

        public ActionResult Delete(int id = 0)
        {
            PersonSystem personsystem = db.PersonSystems.Find(id);
            if (personsystem == null)
            {
                return HttpNotFound();
            }
            return View(personsystem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonSystem personsystem = db.PersonSystems.Find(id);
            db.PersonSystems.Remove(personsystem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logoff()
        {
            Session.Clear();
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            PersonSystem person = new PersonSystem();
            try
            {
                person = db.PersonSystems.Where(b => b.Name == username).FirstOrDefault();
                if (person.password.Equals(password))
                {
                    Session["username"] = username;
                    Session["UserId"] = person.ID;
                    if (person.RoleOfPerson.who.Equals("admin"))
                    {
                        Session["role"] = "admin";
                        return Redirect("/Home/Admin");
                    }
                    return Redirect("/Event");
                }
                else {
                    ModelState.AddModelError("error", "error");
                }
              
            }
            catch
            {
                ModelState.AddModelError("error", "error");
            }

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}