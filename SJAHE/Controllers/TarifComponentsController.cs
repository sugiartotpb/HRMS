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
    public class TarifComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: TarifComponents
        public ActionResult Index()
        {
            return View(db.PY_TarifComponent.ToList());
        }

        // GET: TarifComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_TarifComponent pY_TarifComponent = db.PY_TarifComponent.Find(id);
            if (pY_TarifComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_TarifComponent);
        }

        // GET: TarifComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarifComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TarifComponentID,TarifComponentName,TF01,TF02,TF03,TarifComponentCreatedBy,TarifComponentDateCreatedOn")] PY_TarifComponent pY_TarifComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_TarifComponent.TarifComponentCreatedBy = identity.User.UserID;
                pY_TarifComponent.TarifComponentDateCreatedOn = DateTime.Now;
                db.PY_TarifComponent.Add(pY_TarifComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_TarifComponent);
        }

        // GET: TarifComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_TarifComponent pY_TarifComponent = db.PY_TarifComponent.Find(id);
            if (pY_TarifComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_TarifComponent);
        }

        // POST: TarifComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TarifComponentID,TarifComponentName,TF01,TF02,TF03,TarifComponentCreatedBy,TarifComponentDateCreatedOn")] PY_TarifComponent pY_TarifComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_TarifComponent.TarifComponentCreatedBy = identity.User.UserID;
                pY_TarifComponent.TarifComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_TarifComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_TarifComponent);
        }

        // GET: TarifComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_TarifComponent pY_TarifComponent = db.PY_TarifComponent.Find(id);
            if (pY_TarifComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_TarifComponent);
        }

        // POST: TarifComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_TarifComponent pY_TarifComponent = db.PY_TarifComponent.Find(id);
            db.PY_TarifComponent.Remove(pY_TarifComponent);
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
