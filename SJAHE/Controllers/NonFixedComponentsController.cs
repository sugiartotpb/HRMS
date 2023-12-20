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
    [CustomAuthorize("Level1,Level2")]
    public class NonFixedComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: NonFixedComponents
        public ActionResult Index()
        {
            return View(db.PY_NonFixedComponent.ToList());
        }

        // GET: NonFixedComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_NonFixedComponent pY_NonFixedComponent = db.PY_NonFixedComponent.Find(id);
            if (pY_NonFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_NonFixedComponent);
        }

        // GET: NonFixedComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NonFixedComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NonFixedComponentID,NonFixedComponentName,NF01,NF02,NF03,NonFixedComponentCreatedBy,NonFixedComponentDateCreatedOn")] PY_NonFixedComponent pY_NonFixedComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_NonFixedComponent.NonFixedComponentCreatedBy = identity.User.UserID;
                pY_NonFixedComponent.NonFixedComponentDateCreatedOn = DateTime.Now;
                db.PY_NonFixedComponent.Add(pY_NonFixedComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_NonFixedComponent);
        }

        // GET: NonFixedComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_NonFixedComponent pY_NonFixedComponent = db.PY_NonFixedComponent.Find(id);
            if (pY_NonFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_NonFixedComponent);
        }

        // POST: NonFixedComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NonFixedComponentID,NonFixedComponentName,NF01,NF02,NF03,NonFixedComponentCreatedBy,NonFixedComponentDateCreatedOn")] PY_NonFixedComponent pY_NonFixedComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_NonFixedComponent.NonFixedComponentCreatedBy = identity.User.UserID;
                pY_NonFixedComponent.NonFixedComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_NonFixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_NonFixedComponent);
        }

        // GET: NonFixedComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_NonFixedComponent pY_NonFixedComponent = db.PY_NonFixedComponent.Find(id);
            if (pY_NonFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_NonFixedComponent);
        }

        // POST: NonFixedComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_NonFixedComponent pY_NonFixedComponent = db.PY_NonFixedComponent.Find(id);
            db.PY_NonFixedComponent.Remove(pY_NonFixedComponent);
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
