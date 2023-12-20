using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SJAHE_BASE_LIBRARY.Models;
using SJAHE_BASE_LIBRARY.SecurityHelpers;

namespace SJAHE.Controllers
{
    public class GradeController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Grade
        public ActionResult Index()
        {
            return View(db.PA_Grade.ToList());
        }

        // GET: Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Grade pA_Grade = db.PA_Grade.Find(id);
            if (pA_Grade == null)
            {
                return HttpNotFound();
            }
            return View(pA_Grade);
        }

        // GET: Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradeID,GradeCode,GradeName,Hierarchy,Note,CreatedBy,DateCreated")] PA_Grade pA_Grade)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_Grade.CreatedBy = identity.User.UserID;
                pA_Grade.DateCreated = DateTime.Now;
                db.PA_Grade.Add(pA_Grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pA_Grade);
        }

        // GET: Grade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Grade pA_Grade = db.PA_Grade.Find(id);
            if (pA_Grade == null)
            {
                return HttpNotFound();
            }
            return View(pA_Grade);
        }

        // POST: Grade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradeID,GradeCode,GradeName,Hierarchy,Note,CreatedBy,DateCreated")] PA_Grade pA_Grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pA_Grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pA_Grade);
        }

        // GET: Grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Grade pA_Grade = db.PA_Grade.Find(id);
            if (pA_Grade == null)
            {
                return HttpNotFound();
            }
            return View(pA_Grade);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PA_Grade pA_Grade = db.PA_Grade.Find(id);
            db.PA_Grade.Remove(pA_Grade);
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
