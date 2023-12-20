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
    public class SalaryComponentController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: SalaryComponent
        public ActionResult Index()
        {
            return View(db.PY_SalaryComponent.ToList());
        }

        // GET: SalaryComponent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_SalaryComponent pY_SalaryComponent = db.PY_SalaryComponent.Find(id);
            if (pY_SalaryComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_SalaryComponent);
        }

        // GET: SalaryComponent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryComponentID,SalaryComponentName,CreatedBy,DateCreated")] PY_SalaryComponent pY_SalaryComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_SalaryComponent.CreatedBy = identity.User.UserID;
                pY_SalaryComponent.DateCreated = DateTime.Now;
                db.PY_SalaryComponent.Add(pY_SalaryComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_SalaryComponent);
        }

        // GET: SalaryComponent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_SalaryComponent pY_SalaryComponent = db.PY_SalaryComponent.Find(id);
            if (pY_SalaryComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_SalaryComponent);
        }

        // POST: SalaryComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryComponentID,SalaryComponentName,CreatedBy,DateCreated")] PY_SalaryComponent pY_SalaryComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_SalaryComponent.CreatedBy = identity.User.UserID;
                pY_SalaryComponent.DateCreated = DateTime.Now;
                db.Entry(pY_SalaryComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_SalaryComponent);
        }

        // GET: SalaryComponent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_SalaryComponent pY_SalaryComponent = db.PY_SalaryComponent.Find(id);
            if (pY_SalaryComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_SalaryComponent);
        }

        // POST: SalaryComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_SalaryComponent pY_SalaryComponent = db.PY_SalaryComponent.Find(id);
            db.PY_SalaryComponent.Remove(pY_SalaryComponent);
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
