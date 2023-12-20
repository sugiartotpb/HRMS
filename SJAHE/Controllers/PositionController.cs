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
    public class PositionController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Position
        public ActionResult Index()
        {
            return View(db.PA_Position.ToList());
        }

        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Position pA_Position = db.PA_Position.Find(id);
            if (pA_Position == null)
            {
                return HttpNotFound();
            }
            return View(pA_Position);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionID,PositionCode,PositionName,Hierarchy,Note,CreatedBy,DateCreated")] PA_Position pA_Position)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_Position.CreatedBy = identity.User.UserID;
                pA_Position.DateCreated = DateTime.Now;
                db.PA_Position.Add(pA_Position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pA_Position);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Position pA_Position = db.PA_Position.Find(id);
            if (pA_Position == null)
            {
                return HttpNotFound();
            }
            return View(pA_Position);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionID,PositionCode,PositionName,Hierarchy,Note,CreatedBy,DateCreated")] PA_Position pA_Position)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pA_Position.CreatedBy = identity.User.UserID;
                pA_Position.DateCreated = DateTime.Now;
                db.Entry(pA_Position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pA_Position);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PA_Position pA_Position = db.PA_Position.Find(id);
            if (pA_Position == null)
            {
                return HttpNotFound();
            }
            return View(pA_Position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PA_Position pA_Position = db.PA_Position.Find(id);
            db.PA_Position.Remove(pA_Position);
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
