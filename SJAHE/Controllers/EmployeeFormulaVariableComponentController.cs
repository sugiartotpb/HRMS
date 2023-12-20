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
    public class EmployeeFormulaVariableComponentController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: EmployeeFormulaVariableComponent
        public ActionResult Index()
        {
            var pY_EmployeeFormulaVariableComponent = db.PY_EmployeeFormulaVariableComponent.Include(p => p.PY_VariableComponent);
            return View(pY_EmployeeFormulaVariableComponent.ToList());
        }

        // GET: EmployeeFormulaVariableComponent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent = db.PY_EmployeeFormulaVariableComponent.Find(id);
            if (pY_EmployeeFormulaVariableComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaVariableComponent);
        }

        // GET: EmployeeFormulaVariableComponent/Create
        public ActionResult Create()
        {
            ViewBag.VariableComponentID = new SelectList(db.PY_VariableComponent, "VariableComponentID", "VariableComponentName");
            return View();
        }

        // POST: EmployeeFormulaVariableComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormulaVariableComponentID,VariableComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent)
        {
            if (ModelState.IsValid)
            {
                db.PY_EmployeeFormulaVariableComponent.Add(pY_EmployeeFormulaVariableComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VariableComponentID = new SelectList(db.PY_VariableComponent, "VariableComponentID", "VariableComponentName", pY_EmployeeFormulaVariableComponent.VariableComponentID);
            return View(pY_EmployeeFormulaVariableComponent);
        }

        // GET: EmployeeFormulaVariableComponent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent = db.PY_EmployeeFormulaVariableComponent.Find(id);
            if (pY_EmployeeFormulaVariableComponent == null)
            {
                return HttpNotFound();
            }
            ViewBag.VariableComponentID = new SelectList(db.PY_VariableComponent, "VariableComponentID", "VariableComponentName", pY_EmployeeFormulaVariableComponent.VariableComponentID);
            return View(pY_EmployeeFormulaVariableComponent);
        }

        // POST: EmployeeFormulaVariableComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormulaVariableComponentID,VariableComponentID,FormulaSequence,Condition,Formula,FlagProcess")] PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pY_EmployeeFormulaVariableComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VariableComponentID = new SelectList(db.PY_VariableComponent, "VariableComponentID", "VariableComponentName", pY_EmployeeFormulaVariableComponent.VariableComponentID);
            return View(pY_EmployeeFormulaVariableComponent);
        }

        // GET: EmployeeFormulaVariableComponent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent = db.PY_EmployeeFormulaVariableComponent.Find(id);
            if (pY_EmployeeFormulaVariableComponent == null)
            {
                return HttpNotFound();
            }
            return View(pY_EmployeeFormulaVariableComponent);
        }

        // POST: EmployeeFormulaVariableComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PY_EmployeeFormulaVariableComponent pY_EmployeeFormulaVariableComponent = db.PY_EmployeeFormulaVariableComponent.Find(id);
            db.PY_EmployeeFormulaVariableComponent.Remove(pY_EmployeeFormulaVariableComponent);
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
