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
    public class LevelController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Level
        public ActionResult Index()
        {
            var pA_Level = db.PA_Level.Include(p => p.PA_LevelType);
            return View(pA_Level.ToList());
        }

        // GET: Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Level pA_Level = db.PA_Level.Find(id);
            if (pA_Level == null)
            {
                return HttpNotFound();
            }
            return View(pA_Level);
        }

        // GET: Level/Create
        public ActionResult Create()
        {
            ViewBag.LevelTypeID = new SelectList(db.PA_LevelType, "LevelTypeID", "LevelTypeName");
            return View();
        }

        // POST: Level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevelID,LevelCode,LevelName,LevelTypeID,Description,CreatedBy,DateCreated")] PA_Level pA_Level)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_Level.CreatedBy = identity.User.UserID;
                pA_Level.DateCreated = DateTime.Now;
                db.PA_Level.Add(pA_Level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelTypeID = new SelectList(db.PA_LevelType, "LevelTypeID", "LevelTypeName", pA_Level.LevelTypeID);
            return View(pA_Level);
        }

        // GET: Level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Level pA_Level = db.PA_Level.Find(id);
            if (pA_Level == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelTypeID = new SelectList(db.PA_LevelType, "LevelTypeID", "LevelTypeName", pA_Level.LevelTypeID);
            return View(pA_Level);
        }

        // POST: Level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevelID,LevelCode,LevelName,LevelTypeID,Description,CreatedBy,DateCreated")] PA_Level pA_Level)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_Level.CreatedBy = identity.User.UserID;
                pA_Level.DateCreated = DateTime.Now;
                db.Entry(pA_Level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelTypeID = new SelectList(db.PA_LevelType, "LevelTypeID", "LevelTypeName", pA_Level.LevelTypeID);
            return View(pA_Level);
        }

        // GET: Level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Level pA_Level = db.PA_Level.Find(id);
            if (pA_Level == null)
            {
                return HttpNotFound();
            }
            return View(pA_Level);
        }

        // POST: Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PA_Level pA_Level = db.PA_Level.Find(id);
            db.PA_Level.Remove(pA_Level);
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
