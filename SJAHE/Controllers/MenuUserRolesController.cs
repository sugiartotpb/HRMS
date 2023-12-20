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
    public class MenuUserRolesController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: MenuUserRoles
        public ActionResult Index()
        {
            var sC_MenuUserRole = db.SC_MenuUserRole.Include(s => s.AP_ApplicationModule).Include(s => s.AP_Menu).Include(s => s.AP_SubChildMenu).Include(s => s.AP_SubMenu).Include(s => s.SC_UserRole);
            return View(sC_MenuUserRole.ToList());
        }

        // GET: MenuUserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MenuUserRole sC_MenuUserRole = db.SC_MenuUserRole.Find(id);
            if (sC_MenuUserRole == null)
            {
                return HttpNotFound();
            }
            return View(sC_MenuUserRole);
        }

        public ActionResult GetMenu(int ApplicationID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var dbGetMenu = db.AP_Menu.Where(m => m.ApplicationModuleID == ApplicationID);
            return Json(dbGetMenu, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubMenuPartial(int MenuID)
        {
            var dbGetSubMenu = db.AP_SubMenu.Where(m => m.MenuID == MenuID).ToList();
            return PartialView("GetSubMenuPartial", dbGetSubMenu);
        }

        public ActionResult GetSubChildMenuPartial(int[] ChildID)
        {
            List<AP_SubChildMenu> dbGetSubChildMenu = null;
            List<AP_SubChildMenu> lstChildMenu = new List<AP_SubChildMenu>();
            for (int i = 0; i < ChildID.Length; i++)
            {
                int a = ChildID[i];
                dbGetSubChildMenu = db.AP_SubChildMenu.Where(m => m.SubMenuID == a).ToList();
                foreach(var k in dbGetSubChildMenu)
                {
                    lstChildMenu.Add(new AP_SubChildMenu
                    {
                        SubChildMenuID = k.SubChildMenuID,
                        SubMenuID = k.SubMenuID,
                        SubChildMenuName = k.SubChildMenuName,
                        SubChildUrl = k.SubChildUrl,
                        SubChildMenuStatus = k.SubChildMenuStatus
                    });
                }
            }
            return PartialView("GetSubChildMenuPartial", lstChildMenu);
        }

        // GET: MenuUserRoles/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName");
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName");
            ViewBag.SubChildMenuID = new SelectList(db.AP_SubChildMenu, "SubChildMenuID", "SubChildMenuName");
            ViewBag.SubmenuID = new SelectList(db.AP_SubMenu, "SubMenuID", "SubMenuName");
            ViewBag.UserRoleID = new SelectList(db.SC_UserRole.Include(c=>c.SC_User), "UserRoleID", "SC_User.UserFullName");
            return View();
        }

        // POST: MenuUserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuUserRoleID,UserRoleID,ApplicationModuleID,MenuID,SubmenuID,SubChildMenuID,MenuUserRoleCreatedBy,MenuUserRoleCreatedOn,MenuUserRoleStatus")] SC_MenuUserRole sC_MenuUserRole, int[] SubChildMenuID)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                for (int i = 0; i < SubChildMenuID.Length; i++)
                {
                    int dbSubMenuID = db.AP_SubChildMenu.Find(SubChildMenuID[i]).SubMenuID;
                    int dbMenuID = db.AP_SubMenu.Find(dbSubMenuID).MenuID;
                    int dbAppID = db.AP_Menu.Find(dbMenuID).ApplicationModuleID;
                    int SubChildID = SubChildMenuID[i];
                    var chkMenuUserRole = db.SC_MenuUserRole.Where(m => m.SubChildMenuID == SubChildID).ToList();
                    if(chkMenuUserRole.Count == 0)
                    {
                        sC_MenuUserRole.ApplicationModuleID = dbAppID;
                        sC_MenuUserRole.MenuID = dbMenuID;
                        sC_MenuUserRole.SubMenuID = dbSubMenuID;
                        sC_MenuUserRole.SubChildMenuID = SubChildMenuID[i];
                        sC_MenuUserRole.MenuUserRoleCreatedBy = identity.User.UserID;
                        sC_MenuUserRole.MenuUserRoleCreatedOn = DateTime.Now;
                        db.SC_MenuUserRole.Add(sC_MenuUserRole);
                        db.SaveChanges();
                    }
                }

                //db.SC_MenuUserRole.Add(sC_MenuUserRole);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", sC_MenuUserRole.ApplicationModuleID);
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", sC_MenuUserRole.MenuID);
            ViewBag.SubChildMenuID = new SelectList(db.AP_SubChildMenu, "SubChildMenuID", "SubChildMenuName", sC_MenuUserRole.SubChildMenuID);
            ViewBag.SubmenuID = new SelectList(db.AP_SubMenu, "SubMenuID", "SubMenuName", sC_MenuUserRole.SubMenuID);
            ViewBag.UserRoleID = new SelectList(db.SC_UserRole, "UserRoleID", "UserRoleID", sC_MenuUserRole.UserRoleID);
            return View(sC_MenuUserRole);
        }

        // GET: MenuUserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MenuUserRole sC_MenuUserRole = db.SC_MenuUserRole.Find(id);
            if (sC_MenuUserRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", sC_MenuUserRole.ApplicationModuleID);
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", sC_MenuUserRole.MenuID);
            ViewBag.SubChildMenuID = new SelectList(db.AP_SubChildMenu, "SubChildMenuID", "SubChildMenuName", sC_MenuUserRole.SubChildMenuID);
            ViewBag.SubmenuID = new SelectList(db.AP_SubMenu, "SubMenuID", "SubMenuName", sC_MenuUserRole.SubMenuID);
            ViewBag.UserRoleID = new SelectList(db.SC_UserRole, "UserRoleID", "UserRoleID", sC_MenuUserRole.UserRoleID);
            return View(sC_MenuUserRole);
        }

        // POST: MenuUserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuUserRoleID,UserRoleID,ApplicationModuleID,MenuID,SubmenuID,SubChildMenuID,MenuUserRoleCreatedBy,MenuUserRoleCreatedOn,MenuUserRoleStatus")] SC_MenuUserRole sC_MenuUserRole)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                sC_MenuUserRole.MenuUserRoleCreatedBy = identity.User.UserID;
                sC_MenuUserRole.MenuUserRoleCreatedOn = DateTime.Now;
                db.Entry(sC_MenuUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationModuleID = new SelectList(db.AP_ApplicationModule, "ApplicationModuleID", "ApplicationModuleName", sC_MenuUserRole.ApplicationModuleID);
            ViewBag.MenuID = new SelectList(db.AP_Menu, "MenuID", "MenuName", sC_MenuUserRole.MenuID);
            ViewBag.SubChildMenuID = new SelectList(db.AP_SubChildMenu, "SubChildMenuID", "SubChildMenuName", sC_MenuUserRole.SubChildMenuID);
            ViewBag.SubmenuID = new SelectList(db.AP_SubMenu, "SubMenuID", "SubMenuName", sC_MenuUserRole.SubMenuID);
            ViewBag.UserRoleID = new SelectList(db.SC_UserRole, "UserRoleID", "UserRoleID", sC_MenuUserRole.UserRoleID);
            return View(sC_MenuUserRole);
        }

        // GET: MenuUserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_MenuUserRole sC_MenuUserRole = db.SC_MenuUserRole.Find(id);
            if (sC_MenuUserRole == null)
            {
                return HttpNotFound();
            }
            return View(sC_MenuUserRole);
        }

        // POST: MenuUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SC_MenuUserRole sC_MenuUserRole = db.SC_MenuUserRole.Find(id);
            db.SC_MenuUserRole.Remove(sC_MenuUserRole);
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
