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
    public class RolesController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.SC_Role.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_Role sC_Role = db.SC_Role.Find(id);
            if (sC_Role == null)
            {
                return HttpNotFound();
            }
            return View(sC_Role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,RoleName,RoleCreatedBy,RolDateCreatedOn")] SC_Role sC_Role)
        {
            if (ModelState.IsValid)
            {
                db.SC_Role.Add(sC_Role);
                sC_Role.RoleCreatedBy = 1;
                sC_Role.RoleDateCreatedOn = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sC_Role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_Role sC_Role = db.SC_Role.Find(id);
            if (sC_Role == null)
            {
                return HttpNotFound();
            }
            return View(sC_Role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,RoleName,RoleCreatedBy,RolDateCreatedOn")] SC_Role sC_Role)
        {
            if (ModelState.IsValid)
            {
                sC_Role.RoleCreatedBy = 1;
                sC_Role.RoleDateCreatedOn = DateTime.Now;
                db.Entry(sC_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sC_Role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_Role sC_Role = db.SC_Role.Find(id);
            if (sC_Role == null)
            {
                return HttpNotFound();
            }
            return View(sC_Role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SC_Role sC_Role = db.SC_Role.Find(id);
            db.SC_Role.Remove(sC_Role);
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
