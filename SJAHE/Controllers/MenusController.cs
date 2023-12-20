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
    public class MenusController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Menus
        public ActionResult Index()
        {
            var aP_Menu = db.AP_Menu.Include(a => a.AP_ApplicationModule);
            return View(aP_Menu.ToList());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_Menu aP_Menu = db.AP_Menu.Find(id);
            if (aP_Menu == null)
            {
                return HttpNotFound();
            }
            return View(aP_Menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,ApplicationModuleID,MenuName,MenuCreatedBy,MenuCreatedOn,MenuStatus")] AP_Menu aP_Menu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_Menu.MenuCreatedBy = identity.User.UserID;
                aP_Menu.MenuCreatedOn = DateTime.Now;
                db.AP_Menu.Add(aP_Menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", aP_Menu.ApplicationModuleID);
            return View(aP_Menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_Menu aP_Menu = db.AP_Menu.Find(id);
            if (aP_Menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", aP_Menu.ApplicationModuleID);
            return View(aP_Menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,ApplicationModuleID,MenuName,MenuCreatedBy,MenuCreatedOn,MenuStatus")] AP_Menu aP_Menu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_Menu.MenuCreatedBy = identity.User.UserID;
                aP_Menu.MenuCreatedOn = DateTime.Now;
                db.Entry(aP_Menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", aP_Menu.ApplicationModuleID);
            return View(aP_Menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_Menu aP_Menu = db.AP_Menu.Find(id);
            if (aP_Menu == null)
            {
                return HttpNotFound();
            }
            return View(aP_Menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AP_Menu aP_Menu = db.AP_Menu.Find(id);
            db.AP_Menu.Remove(aP_Menu);
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
