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
    public class LevelTypeController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: LevelType
        public ActionResult Index()
        {
            return View(db.PA_LevelType.ToList());
        }

        // GET: LevelType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_LevelType pA_LevelType = db.PA_LevelType.Find(id);
            if (pA_LevelType == null)
            {
                return HttpNotFound();
            }
            return View(pA_LevelType);
        }

        // GET: LevelType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevelTypeID,LevelTypeName,LevelSequence,CreatedBy,DateCreated")] PA_LevelType pA_LevelType)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_LevelType.CreatedBy = identity.User.UserID;
                pA_LevelType.DateCreated = DateTime.Now;
                db.PA_LevelType.Add(pA_LevelType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pA_LevelType);
        }

        // GET: LevelType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_LevelType pA_LevelType = db.PA_LevelType.Find(id);
            if (pA_LevelType == null)
            {
                return HttpNotFound();
            }
            return View(pA_LevelType);
        }

        // POST: LevelType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevelTypeID,LevelTypeName,LevelSequence,CreatedBy,DateCreated")] PA_LevelType pA_LevelType)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_LevelType.CreatedBy = identity.User.UserID;
                pA_LevelType.DateCreated = DateTime.Now;
                db.Entry(pA_LevelType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pA_LevelType);
        }

        // GET: LevelType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_LevelType pA_LevelType = db.PA_LevelType.Find(id);
            if (pA_LevelType == null)
            {
                return HttpNotFound();
            }
            return View(pA_LevelType);
        }

        // POST: LevelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PA_LevelType pA_LevelType = db.PA_LevelType.Find(id);
            db.PA_LevelType.Remove(pA_LevelType);
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
