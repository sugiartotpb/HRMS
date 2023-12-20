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
    public class EmployeeFormulaNonFixedComponentController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: EmployeeFormulaNonFixedComponent
        public ActionResult Index()
        {
            var pY_EmployeeFormulaNonFixedComponent = db.PY_EmployeeFormulaNonFixedComponent.Include(p => p.PY_NonFixedComponent);
            return View(pY_EmployeeFormulaNonFixedComponent.ToList());
        }

        // GET: EmployeeFormulaNonFixedComponent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent = db.PY_EmployeeFormulaNonFixedComponent.Find(id);
            if (pY_EmployeeFormulaNonFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaNonFixedComponent);
        }

        // GET: EmployeeFormulaNonFixedComponent/Create
        public ActionResult Create()
        {
            ViewBag.NonFixedComponentID = new SelectList(db.PY_NonFixedComponent, "NonFixedComponentID", "NonFixedComponentName");
            return View();
        }

        // POST: EmployeeFormulaNonFixedComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormulaNonFixedComponentID,NonFixedComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent)
        {
            if (ModelState.IsValid)
            {
                db.PY_EmployeeFormulaNonFixedComponent.Add(pY_EmployeeFormulaNonFixedComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NonFixedComponentID = new SelectList(db.PY_NonFixedComponent, "NonFixedComponentID", "NonFixedComponentName", pY_EmployeeFormulaNonFixedComponent.NonFixedComponentID);
            return View(pY_EmployeeFormulaNonFixedComponent);
        }

        // GET: EmployeeFormulaNonFixedComponent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent = db.PY_EmployeeFormulaNonFixedComponent.Find(id);
            if (pY_EmployeeFormulaNonFixedComponent == null)
            {
                return HttpNotFound();
            }
            ViewBag.NonFixedComponentID = new SelectList(db.PY_NonFixedComponent, "NonFixedComponentID", "NonFixedComponentName", pY_EmployeeFormulaNonFixedComponent.NonFixedComponentID);
            return View(pY_EmployeeFormulaNonFixedComponent);
        }

        // POST: EmployeeFormulaNonFixedComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormulaNonFixedComponentID,NonFixedComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pY_EmployeeFormulaNonFixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NonFixedComponentID = new SelectList(db.PY_NonFixedComponent, "NonFixedComponentID", "NonFixedComponentName", pY_EmployeeFormulaNonFixedComponent.NonFixedComponentID);
            return View(pY_EmployeeFormulaNonFixedComponent);
        }

        // GET: EmployeeFormulaNonFixedComponent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent = db.PY_EmployeeFormulaNonFixedComponent.Find(id);
            if (pY_EmployeeFormulaNonFixedComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaNonFixedComponent);
        }

        // POST: EmployeeFormulaNonFixedComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_EmployeeFormulaNonFixedComponent pY_EmployeeFormulaNonFixedComponent = db.PY_EmployeeFormulaNonFixedComponent.Find(id);
            db.PY_EmployeeFormulaNonFixedComponent.Remove(pY_EmployeeFormulaNonFixedComponent);
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
