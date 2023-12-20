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
    public class FixedComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: FixedComponents
        public ActionResult Index()
        {
            return View(db.PY_FixedComponent.ToList());
        }

        // GET: FixedComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_FixedComponent pY_FixedComponent = db.PY_FixedComponent.Find(id);
            if (pY_FixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_FixedComponent);
        }

        // GET: FixedComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FixedComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FixedComponentID,FixedComponentName,F01,F02,F03,FixedComponentCreatedBy,FixedComponentDateCreatedOn")] PY_FixedComponent pY_FixedComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_FixedComponent.FixedComponentCreatedBy = identity.User.UserID;
                pY_FixedComponent.FixedComponentDateCreatedOn = DateTime.Now;
                db.PY_FixedComponent.Add(pY_FixedComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_FixedComponent);
        }

        // GET: FixedComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_FixedComponent pY_FixedComponent = db.PY_FixedComponent.Find(id);
            if (pY_FixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_FixedComponent);
        }

        // POST: FixedComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FixedComponentID,FixedComponentName,F01,F02,F03,FixedComponentCreatedBy,FixedComponentDateCreatedOn")] PY_FixedComponent pY_FixedComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_FixedComponent.FixedComponentCreatedBy = identity.User.UserID;
                pY_FixedComponent.FixedComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_FixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_FixedComponent);
        }

        // GET: FixedComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_FixedComponent pY_FixedComponent = db.PY_FixedComponent.Find(id);
            if (pY_FixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_FixedComponent);
        }

        // POST: FixedComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_FixedComponent pY_FixedComponent = db.PY_FixedComponent.Find(id);
            db.PY_FixedComponent.Remove(pY_FixedComponent);
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
