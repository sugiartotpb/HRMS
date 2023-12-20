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
    [CustomAuthorize("Level1")]
    public class ApplicationModulesController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: ApplicationModules
        public ActionResult Index()
        {
            return View(db.AP_ApplicationModule.ToList());
        }

        // GET: ApplicationModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_ApplicationModule aP_ApplicationModule = db.AP_ApplicationModule.Find(id);
            if (aP_ApplicationModule == null)
            {
                return HttpNotFound();
            }
            return View(aP_ApplicationModule);
        }

        // GET: ApplicationModules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationModuleID,ApplicationModuleName,ApplicationModuleCreatedBy,ApplicationModuleCreatedOn,ApplicationModuleStatus")] AP_ApplicationModule aP_ApplicationModule)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_ApplicationModule.ApplicationModuleCreatedBy = identity.User.UserID;
                aP_ApplicationModule.ApplicationModuleCreatedOn = DateTime.Now;
                db.AP_ApplicationModule.Add(aP_ApplicationModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aP_ApplicationModule);
        }

        // GET: ApplicationModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_ApplicationModule aP_ApplicationModule = db.AP_ApplicationModule.Find(id);
            if (aP_ApplicationModule == null)
            {
                return HttpNotFound();
            }
            return View(aP_ApplicationModule);
        }

        // POST: ApplicationModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationModuleID,ApplicationModuleName,ApplicationModuleCreatedBy,ApplicationModuleCreatedOn,ApplicationModuleStatus")] AP_ApplicationModule aP_ApplicationModule)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_ApplicationModule.ApplicationModuleCreatedBy = identity.User.UserID;
                aP_ApplicationModule.ApplicationModuleCreatedOn = DateTime.Now;
                db.Entry(aP_ApplicationModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aP_ApplicationModule);
        }

        // GET: ApplicationModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_ApplicationModule aP_ApplicationModule = db.AP_ApplicationModule.Find(id);
            if (aP_ApplicationModule == null)
            {
                return HttpNotFound();
            }
            return View(aP_ApplicationModule);
        }

        // POST: ApplicationModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AP_ApplicationModule aP_ApplicationModule = db.AP_ApplicationModule.Find(id);
            db.AP_ApplicationModule.Remove(aP_ApplicationModule);
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
