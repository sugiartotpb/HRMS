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
    public class VariableComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: VariableComponents
        public ActionResult Index()
        {
            return View(db.PY_VariableComponent.ToList());
        }

        // GET: VariableComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_VariableComponent pY_VariableComponent = db.PY_VariableComponent.Find(id);
            if (pY_VariableComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_VariableComponent);
        }

        // GET: VariableComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VariableComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VariableComponentID,VariableComponentName,V01,V02,V03,VariableComponentCreatedBy,VariableComponentDateCreatedOn")] PY_VariableComponent pY_VariableComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_VariableComponent.VariableComponentCreatedBy = identity.User.UserID;
                pY_VariableComponent.VariableComponentDateCreatedOn = DateTime.Now;
                db.PY_VariableComponent.Add(pY_VariableComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_VariableComponent);
        }

        // GET: VariableComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_VariableComponent pY_VariableComponent = db.PY_VariableComponent.Find(id);
            if (pY_VariableComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_VariableComponent);
        }

        // POST: VariableComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VariableComponentID,VariableComponentName,V01,V02,V03,VariableComponentCreatedBy,VariableComponentDateCreatedOn")] PY_VariableComponent pY_VariableComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_VariableComponent.VariableComponentCreatedBy = identity.User.UserID;
                pY_VariableComponent.VariableComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_VariableComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_VariableComponent);
        }

        // GET: VariableComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_VariableComponent pY_VariableComponent = db.PY_VariableComponent.Find(id);
            if (pY_VariableComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_VariableComponent);
        }

        // POST: VariableComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_VariableComponent pY_VariableComponent = db.PY_VariableComponent.Find(id);
            db.PY_VariableComponent.Remove(pY_VariableComponent);
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
