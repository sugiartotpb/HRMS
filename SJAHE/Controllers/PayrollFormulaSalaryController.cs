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
    public class PayrollFormulaSalaryController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: PayrollFormulaSalary
        public ActionResult Index()
        {
            var pY_PayrollFormulaSalary = db.PY_PayrollFormulaSalary.Include(p => p.PY_SalaryComponent);
            return View(pY_PayrollFormulaSalary.ToList());
        }

        // GET: PayrollFormulaSalary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollFormulaSalary pY_PayrollFormulaSalary = db.PY_PayrollFormulaSalary.Find(id);
            if (pY_PayrollFormulaSalary == null)
            {
                return HttpNotFound();
            }
            return View(pY_PayrollFormulaSalary);
        }

        // GET: PayrollFormulaSalary/Create
        public ActionResult Create()
        {
            ViewBag.SalaryComponentID = new SelectList(db.PY_SalaryComponent, "SalaryComponentID", "SalaryComponentName");
            return View();
        }

        // POST: PayrollFormulaSalary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayrollFormulaSalaryID,SalaryComponentID,SequenceNo,Condition,Formula,FlagProcess,Note,CreatedBy,DateCreated")] PY_PayrollFormulaSalary pY_PayrollFormulaSalary)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_PayrollFormulaSalary.CreatedBy = identity.User.UserID;
                pY_PayrollFormulaSalary.DateCreated = DateTime.Now;
                db.PY_PayrollFormulaSalary.Add(pY_PayrollFormulaSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SalaryComponentID = new SelectList(db.PY_SalaryComponent, "SalaryComponentID", "SalaryComponentName", pY_PayrollFormulaSalary.SalaryComponentID);
            return View(pY_PayrollFormulaSalary);
        }

        // GET: PayrollFormulaSalary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollFormulaSalary pY_PayrollFormulaSalary = db.PY_PayrollFormulaSalary.Find(id);
            if (pY_PayrollFormulaSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalaryComponentID = new SelectList(db.PY_SalaryComponent, "SalaryComponentID", "SalaryComponentName", pY_PayrollFormulaSalary.SalaryComponentID);
            return View(pY_PayrollFormulaSalary);
        }

        // POST: PayrollFormulaSalary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayrollFormulaSalaryID,SalaryComponentID,SequenceNo,Condition,Formula,FlagProcess,Note,CreatedBy,DateCreated")] PY_PayrollFormulaSalary pY_PayrollFormulaSalary)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_PayrollFormulaSalary.CreatedBy = identity.User.UserID;
                pY_PayrollFormulaSalary.DateCreated = DateTime.Now;
                db.Entry(pY_PayrollFormulaSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalaryComponentID = new SelectList(db.PY_SalaryComponent, "SalaryComponentID", "SalaryComponentName", pY_PayrollFormulaSalary.SalaryComponentID);
            return View(pY_PayrollFormulaSalary);
        }

        // GET: PayrollFormulaSalary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_PayrollFormulaSalary pY_PayrollFormulaSalary = db.PY_PayrollFormulaSalary.Find(id);
            if (pY_PayrollFormulaSalary == null)
            {
                return HttpNotFound();
            }
            return View(pY_PayrollFormulaSalary);
        }

        // POST: PayrollFormulaSalary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_PayrollFormulaSalary pY_PayrollFormulaSalary = db.PY_PayrollFormulaSalary.Find(id);
            db.PY_PayrollFormulaSalary.Remove(pY_PayrollFormulaSalary);
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
