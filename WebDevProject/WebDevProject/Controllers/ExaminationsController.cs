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
    public class ExaminationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Examinations
        public ActionResult Index()
        {
            return View(db.Examinations.ToList());
        }

        // GET: Examinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // GET: Examinations/Create
        public ActionResult Create()
        {
            //return View();
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "---Select---", Value = "0", Selected = true });

            items.Add(new SelectListItem { Text = "Biology", Value = "1" });

            items.Add(new SelectListItem { Text = "Computer Science", Value = "2" });

            items.Add(new SelectListItem { Text = "Commerce", Value = "3" });

            items.Add(new SelectListItem { Text = "Humanities", Value = "4" });

            ViewBag.Exam_Group = items;

            return View();
        }

        // POST: Examinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamID,Fee,Exam_Group")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Examinations.Add(examination);
                db.SaveChanges();
                return RedirectToAction("About","Home");
            }

            return View(examination);
        }

        // GET: Examinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: Examinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamID,Fee,Exam_Group")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examination);
        }

        // GET: Examinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: Examinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examination examination = db.Examinations.Find(id);
            db.Examinations.Remove(examination);
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
