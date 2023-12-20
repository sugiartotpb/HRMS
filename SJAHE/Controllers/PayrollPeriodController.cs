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
    public class PayrollPeriodController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: PayrollPeriod
        public ActionResult Index()
        {
            return View(db.PY_PayrollPeriod.ToList());
        }

        // GET: PayrollPeriod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollPeriod pY_PayrollPeriod = db.PY_PayrollPeriod.Find(id);
            if (pY_PayrollPeriod == null)
            {
                return HttpNotFound();
            }
            return View(pY_PayrollPeriod);
        }

        // GET: PayrollPeriod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PayrollPeriod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayrollPeriodID,Month,Year,SalaryStartDate,SalaryEndDate,OvertimeStartDate,OvertimeEndDate,AbsenteeismStartDate,AbsenteeismEndDate,JamsostekStartDate,JamsostekEndDate,Note,CreatedBy,DateCreated")] PY_PayrollPeriod pY_PayrollPeriod)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_PayrollPeriod.CreatedBy = identity.User.UserID;
                pY_PayrollPeriod.DateCreated = DateTime.Now;
                db.PY_PayrollPeriod.Add(pY_PayrollPeriod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pY_PayrollPeriod);
        }

        // GET: PayrollPeriod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollPeriod pY_PayrollPeriod = db.PY_PayrollPeriod.Find(id);
            if (pY_PayrollPeriod == null)
            {
                return HttpNotFound();
            }
            return View(pY_PayrollPeriod);
        }

        // POST: PayrollPeriod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayrollPeriodID,Month,Year,SalaryStartDate,SalaryEndDate,OvertimeStartDate,OvertimeEndDate,AbsenteeismStartDate,AbsenteeismEndDate,JamsostekStartDate,JamsostekEndDate,Note,CreatedBy,DateCreated")] PY_PayrollPeriod pY_PayrollPeriod)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_PayrollPeriod.CreatedBy = identity.User.UserID;
                pY_PayrollPeriod.DateCreated = DateTime.Now;
                db.Entry(pY_PayrollPeriod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pY_PayrollPeriod);
        }

        // GET: PayrollPeriod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollPeriod pY_PayrollPeriod = db.PY_PayrollPeriod.Find(id);
            if (pY_PayrollPeriod == null)
            {
                return HttpNotFound();
            }
            return View(pY_PayrollPeriod);
        }

        // POST: PayrollPeriod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_PayrollPeriod pY_PayrollPeriod = db.PY_PayrollPeriod.Find(id);
            db.PY_PayrollPeriod.Remove(pY_PayrollPeriod);
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
