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
    public class SubChildMenusController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: SubChildMenus
        public ActionResult Index()
        {
            var aP_SubChildMenu = db.AP_SubChildMenu.Include(a => a.AP_SubMenu);
            return View(aP_SubChildMenu.ToList());
        }

        // GET: SubChildMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubChildMenu aP_SubChildMenu = db.AP_SubChildMenu.Find(id);
            if (aP_SubChildMenu == null)
            {
                return HttpNotFound();
            }
            return View(aP_SubChildMenu);
        }

        // GET: SubChildMenus/Create
        public ActionResult Create()
        {
            ViewBag.SubMenuID = new SelectList(db.AP_SubMenu, "SubmenuID", "SubMenuName");
            return View();
        }

        // POST: SubChildMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubChildMenuID,SubMenuID,SubChildMenuName,SubChildUrl,SubChildMenuCreatedBy,SubChildMenuCreatedOn,SubChildMenuStatus")] AP_SubChildMenu aP_SubChildMenu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_SubChildMenu.SubChildMenuCreatedBy = identity.User.UserID;
                aP_SubChildMenu.SubChildMenuCreatedOn = DateTime.Now;
                db.AP_SubChildMenu.Add(aP_SubChildMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubMenuID = new SelectList(db.AP_SubMenu, "SubmenuID", "SubMenuName", aP_SubChildMenu.SubMenuID);
            return View(aP_SubChildMenu);
        }

        // GET: SubChildMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubChildMenu aP_SubChildMenu = db.AP_SubChildMenu.Find(id);
            if (aP_SubChildMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubMenuID = new SelectList(db.AP_SubMenu, "SubmenuID", "SubMenuName", aP_SubChildMenu.SubMenuID);
            return View(aP_SubChildMenu);
        }

        // POST: SubChildMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubChildMenuID,SubMenuID,SubChildMenuName,SubChildUrl,SubChildMenuCreatedBy,SubChildMenuCreatedOn,SubChildMenuStatus")] AP_SubChildMenu aP_SubChildMenu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_SubChildMenu.SubChildMenuCreatedBy = identity.User.UserID;
                aP_SubChildMenu.SubChildMenuCreatedOn = DateTime.Now;
                db.Entry(aP_SubChildMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubMenuID = new SelectList(db.AP_SubMenu, "SubmenuID", "SubMenuName", aP_SubChildMenu.SubMenuID);
            return View(aP_SubChildMenu);
        }

        // GET: SubChildMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubChildMenu aP_SubChildMenu = db.AP_SubChildMenu.Find(id);
            if (aP_SubChildMenu == null)
            {
                return HttpNotFound();
            }
            return View(aP_SubChildMenu);
        }

        // POST: SubChildMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AP_SubChildMenu aP_SubChildMenu = db.AP_SubChildMenu.Find(id);
            db.AP_SubChildMenu.Remove(aP_SubChildMenu);
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
