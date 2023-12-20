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
    public class SubMenusController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: SubMenus
        public ActionResult Index()
        {
            var aP_SubMenu = db.AP_SubMenu.Include(a => a.AP_Menu);
            return View(aP_SubMenu.ToList());
        }

        // GET: SubMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubMenu aP_SubMenu = db.AP_SubMenu.Find(id);
            if (aP_SubMenu == null)
            {
                return HttpNotFound();
            }
            return View(aP_SubMenu);
        }

        // GET: SubMenus/Create
        public ActionResult Create()
        {
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName");
            return View();
        }

        // POST: SubMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubMenuID,MenuID,SubMenuName,SubMenuCreatedBy,SubMenuCreatedOn,SubMenuStatus")] AP_SubMenu aP_SubMenu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_SubMenu.SubMenuCreatedBy = identity.User.UserID;
                aP_SubMenu.SubMenuCreatedOn = DateTime.Now;
                db.AP_SubMenu.Add(aP_SubMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", aP_SubMenu.MenuID);
            return View(aP_SubMenu);
        }

        // GET: SubMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubMenu aP_SubMenu = db.AP_SubMenu.Find(id);
            if (aP_SubMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", aP_SubMenu.MenuID);
            return View(aP_SubMenu);
        }

        // POST: SubMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubmenuID,MenuID,SubMenuName,SubMenuCreatedBy,SubmenuCreatedOn,SubmenuStatus")] AP_SubMenu aP_SubMenu)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                aP_SubMenu.SubMenuCreatedBy = identity.User.UserID;
                aP_SubMenu.SubMenuCreatedOn = DateTime.Now;
                db.Entry(aP_SubMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", aP_SubMenu.MenuID);
            return View(aP_SubMenu);
        }

        // GET: SubMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AP_SubMenu aP_SubMenu = db.AP_SubMenu.Find(id);
            if (aP_SubMenu == null)
            {
                return HttpNotFound();
            }
            return View(aP_SubMenu);
        }

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AP_SubMenu aP_SubMenu = db.AP_SubMenu.Find(id);
            db.AP_SubMenu.Remove(aP_SubMenu);
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
