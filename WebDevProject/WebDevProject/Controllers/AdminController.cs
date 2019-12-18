using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDevProject.Views.Account;

namespace WebDevProject.Controllers
{
    public class AdminController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admin
        public ActionResult Index()
        {
            var admit_Cards = db.Admit_Cards.Include(a => a.Candidate).Include(a => a.Guardian).Include(a => a.School);
            return View(admit_Cards.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Admit_Card admit_Card = db.Admit_Cards.Find(id);
            if (admit_Card == null)
            {
                return HttpNotFound();
            }
            return View(admit_Card);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.Roll_Number = new SelectList(db.Candidates, "Roll_Number", "Gender");
            ViewBag.GuardianID = new SelectList(db.Guardians, "GuardianID", "GuardianID");
            ViewBag.School_Code = new SelectList(db.Schools, "School_Code", "Name");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "School_Code,GuardianID,Roll_Number")] Admit_Card admit_Card)
        {
            if (ModelState.IsValid)
            {
                db.Admit_Cards.Add(admit_Card);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roll_Number = new SelectList(db.Candidates, "Roll_Number", "Gender", admit_Card.Roll_Number);
            ViewBag.GuardianID = new SelectList(db.Guardians, "GuardianID", "GuardianID", admit_Card.GuardianID);
            ViewBag.School_Code = new SelectList(db.Schools, "School_Code", "Name", admit_Card.School_Code);
            return View(admit_Card);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admit_Card admit_Card = db.Admit_Cards.Find(id);
            if (admit_Card == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roll_Number = new SelectList(db.Candidates, "Roll_Number", "Gender", admit_Card.Roll_Number);
            ViewBag.GuardianID = new SelectList(db.Guardians, "GuardianID", "GuardianID", admit_Card.GuardianID);
            ViewBag.School_Code = new SelectList(db.Schools, "School_Code", "Name", admit_Card.School_Code);
            return View(admit_Card);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "School_Code,GuardianID,Roll_Number")] Admit_Card admit_Card)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admit_Card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Roll_Number = new SelectList(db.Candidates, "Roll_Number", "Gender", admit_Card.Roll_Number);
            ViewBag.GuardianID = new SelectList(db.Guardians, "GuardianID", "GuardianID", admit_Card.GuardianID);
            ViewBag.School_Code = new SelectList(db.Schools, "School_Code", "Name", admit_Card.School_Code);
            return View(admit_Card);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admit_Card admit_Card = db.Admit_Cards.Find(id);
            if (admit_Card == null)
            {
                return HttpNotFound();
            }
            return View(admit_Card);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admit_Card admit_Card = db.Admit_Cards.Find(id);
            db.Admit_Cards.Remove(admit_Card);
            db.SaveChanges();
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
