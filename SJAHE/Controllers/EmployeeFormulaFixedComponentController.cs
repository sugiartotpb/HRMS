using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SJAHE_BASE_LIBRARY.Models;

namespace SJAHE.Controllers
{
    public class EmployeeFormulaFixedComponentController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: EmployeeFormulaFixedComponent
        public ActionResult Index()
        {
            var pY_EmployeeFormulaFixedComponent = db.PY_EmployeeFormulaFixedComponent.Include(p => p.PY_FixedComponent);
            return View(pY_EmployeeFormulaFixedComponent.ToList());
        }

        // GET: EmployeeFormulaFixedComponent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent = db.PY_EmployeeFormulaFixedComponent.Find(id);
            if (pY_EmployeeFormulaFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaFixedComponent);
        }

        // GET: EmployeeFormulaFixedComponent/Create
        public ActionResult Create()
        {
            ViewBag.FixedComponentID = new SelectList(db.PY_FixedComponent, "FixedComponentID", "FixedComponentName");
            return View();
        }

        // POST: EmployeeFormulaFixedComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormulaFixedComponentID,FixedComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent)
        {
            if (ModelState.IsValid)
            {
                db.PY_EmployeeFormulaFixedComponent.Add(pY_EmployeeFormulaFixedComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FixedComponentID = new SelectList(db.PY_FixedComponent, "FixedComponentID", "FixedComponentName", pY_EmployeeFormulaFixedComponent.FixedComponentID);
            return View(pY_EmployeeFormulaFixedComponent);
        }

        // GET: EmployeeFormulaFixedComponent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent = db.PY_EmployeeFormulaFixedComponent.Find(id);
            if (pY_EmployeeFormulaFixedComponent == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedComponentID = new SelectList(db.PY_FixedComponent, "FixedComponentID", "FixedComponentName", pY_EmployeeFormulaFixedComponent.FixedComponentID);
            return View(pY_EmployeeFormulaFixedComponent);
        }

        // POST: EmployeeFormulaFixedComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormulaFixedComponentID,FixedComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pY_EmployeeFormulaFixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedComponentID = new SelectList(db.PY_FixedComponent, "FixedComponentID", "FixedComponentName", pY_EmployeeFormulaFixedComponent.FixedComponentID);
            return View(pY_EmployeeFormulaFixedComponent);
        }

        // GET: EmployeeFormulaFixedComponent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent = db.PY_EmployeeFormulaFixedComponent.Find(id);
            if (pY_EmployeeFormulaFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaFixedComponent);
        }

        // POST: EmployeeFormulaFixedComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_EmployeeFormulaFixedComponent pY_EmployeeFormulaFixedComponent = db.PY_EmployeeFormulaFixedComponent.Find(id);
            db.PY_EmployeeFormulaFixedComponent.Remove(pY_EmployeeFormulaFixedComponent);
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
