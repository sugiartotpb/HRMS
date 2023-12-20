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
    public class UserRolesController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: UserRoles
        public ActionResult Index()
        {
            var sC_UserRole = db.SC_UserRole.Include(s => s.SC_Role).Include(s => s.SC_User);
            return View(sC_UserRole.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_UserRole sC_UserRole = db.SC_UserRole.Find(id);
            if (sC_UserRole == null)
            {
                return HttpNotFound();
            }
            return View(sC_UserRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.SC_Role, "RoleID", "RoleName");
            ViewBag.UserID = new SelectList(db.SC_User, "UserID", "UserFullName");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserRoleID,UserID,RoleID,UserRoleCreatedBy,UserRoleDateCreatedOn,UserRoleStatus")] SC_UserRole sC_UserRole)
        {
            if (ModelState.IsValid)
            {
                sC_UserRole.UserRoleCreatedBy = 1;
                sC_UserRole.UserRoleDateCreatedOn = DateTime.Now;
                db.SC_UserRole.Add(sC_UserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.SC_Role, "RoleID", "RoleName", sC_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.SC_User, "UserID", "UserFullName", sC_UserRole.UserID);
            return View(sC_UserRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_UserRole sC_UserRole = db.SC_UserRole.Find(id);
            sC_UserRole.UserRoleCreatedBy = 1;
            sC_UserRole.UserRoleDateCreatedOn = DateTime.Now;
            if (sC_UserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.SC_Role, "RoleID", "RoleName", sC_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.SC_User, "UserID", "UserFullName", sC_UserRole.UserID);
            return View(sC_UserRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRoleID,UserID,RoleID,UserRoleCreatedBy,UserRoleDateCreatedOn,UserRoleStatus")] SC_UserRole sC_UserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sC_UserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.SC_Role, "RoleID", "RoleName", sC_UserRole.RoleID);
            ViewBag.UserID = new SelectList(db.SC_User, "UserID", "UserFullName", sC_UserRole.UserID);
            return View(sC_UserRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_UserRole sC_UserRole = db.SC_UserRole.Find(id);
            if (sC_UserRole == null)
            {
                return HttpNotFound();
            }
            return View(sC_UserRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SC_UserRole sC_UserRole = db.SC_UserRole.Find(id);
            db.SC_UserRole.Remove(sC_UserRole);
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
