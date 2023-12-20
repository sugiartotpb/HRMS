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
    public class EmployeeFormulaTarifComponentController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: EmployeeFormulaTarifComponent
        public ActionResult Index()
        {
            var pY_EmployeeFormulaTarifComponent = db.PY_EmployeeFormulaTarifComponent.Include(p => p.PY_TarifComponent);
            return View(pY_EmployeeFormulaTarifComponent.ToList());
        }

        // GET: EmployeeFormulaTarifComponent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent = db.PY_EmployeeFormulaTarifComponent.Find(id);
            if (pY_EmployeeFormulaTarifComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaTarifComponent);
        }

        // GET: EmployeeFormulaTarifComponent/Create
        public ActionResult Create()
        {
            ViewBag.TarifComponentID = new SelectList(db.PY_TarifComponent, "TarifComponentID", "TarifComponentName");
            return View();
        }

        // POST: EmployeeFormulaTarifComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormulaTarifComponentID,TarifComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent)
        {
            if (ModelState.IsValid)
            {
                db.PY_EmployeeFormulaTarifComponent.Add(pY_EmployeeFormulaTarifComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarifComponentID = new SelectList(db.PY_TarifComponent, "TarifComponentID", "TarifComponentName", pY_EmployeeFormulaTarifComponent.TarifComponentID);
            return View(pY_EmployeeFormulaTarifComponent);
        }

        // GET: EmployeeFormulaTarifComponent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent = db.PY_EmployeeFormulaTarifComponent.Find(id);
            if (pY_EmployeeFormulaTarifComponent == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarifComponentID = new SelectList(db.PY_TarifComponent, "TarifComponentID", "TarifComponentName", pY_EmployeeFormulaTarifComponent.TarifComponentID);
            return View(pY_EmployeeFormulaTarifComponent);
        }

        // POST: EmployeeFormulaTarifComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormulaTarifComponentID,TarifComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pY_EmployeeFormulaTarifComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarifComponentID = new SelectList(db.PY_TarifComponent, "TarifComponentID", "TarifComponentName", pY_EmployeeFormulaTarifComponent.TarifComponentID);
            return View(pY_EmployeeFormulaTarifComponent);
        }

        // GET: EmployeeFormulaTarifComponent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent = db.PY_EmployeeFormulaTarifComponent.Find(id);
            if (pY_EmployeeFormulaTarifComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaTarifComponent);
        }

        // POST: EmployeeFormulaTarifComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_EmployeeFormulaTarifComponent pY_EmployeeFormulaTarifComponent = db.PY_EmployeeFormulaTarifComponent.Find(id);
            db.PY_EmployeeFormulaTarifComponent.Remove(pY_EmployeeFormulaTarifComponent);
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
