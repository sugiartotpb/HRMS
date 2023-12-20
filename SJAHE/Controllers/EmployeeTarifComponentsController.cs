using PagedList;
using SJAHE_BASE_LIBRARY.Models;
using SJAHE_BASE_LIBRARY.SecurityHelpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJAHE.Controllers
{
    [CustomAuthorize("Level1,Level2")]
    public class EmployeeTarifComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        // GET: EmployeeFixedComponents


        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            var dbEmpCount = db.PA_EmployeeOccupation.ToList();
            ViewBag.CountEmp = dbEmpCount.Count;

            IPagedList<PA_EmployeeOccupation> dbEmpFixed = null;

            dbEmpFixed = db.PA_EmployeeOccupation.OrderBy(e => e.EmployeeNo).ToPagedList(pageIndex, pageSize);//db.PY_EmpFixedComponent.ToList();
            return View(dbEmpFixed);
        }

        public ActionResult SearchPartial(string txtEmpID, int? page)
        {
            int pageSize = 20;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            var dbEmpCount = db.PA_EmployeeOccupation.ToList();
            ViewBag.CountEmp = dbEmpCount.Count;

            IPagedList<PA_EmployeeOccupation> dbEmpFixed = null;

            if (txtEmpID != "")
            {
                dbEmpFixed = db.PA_EmployeeOccupation.Where(e => e.EmployeeNo.Contains(txtEmpID)).OrderBy(e => e.EmployeeNo).ToPagedList(pageIndex, pageSize);
                return PartialView(dbEmpFixed);
            }
            else
            {
                dbEmpFixed = db.PA_EmployeeOccupation.OrderBy(e => e.EmployeeNo).ToPagedList(pageIndex, pageSize);
                return PartialView(dbEmpFixed);
            }
        }

        public JsonResult ListEmpAutoComplete(string Search_)
        {
            var dbEmp = db.PA_EmployeeOccupation.Where(e => e.EmployeeNo.Contains(Search_));
            return Json(dbEmp.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmpTarifComponentPartial(string EmpID)
        {
            var dbEmpTarif = db.PY_EmpTarifComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            return PartialView("EmpTarifComponentPartial", dbEmpTarif);
        }

        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(int[] chkTarif, string EmpID, double[] txtValue, PY_EmpTarifComponent pY_EmpTarifComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkTarif != null)
            {
                for (int i = 0; i < chkTarif.Length; i++)
                {
                    intFixedID = chkTarif[i];
                    dblValue = txtValue[i];
                    pY_EmpTarifComponent.TarifComponentID = (int)intFixedID;
                    pY_EmpTarifComponent.TarifComponentValue = (decimal)dblValue;
                    pY_EmpTarifComponent.EmpTarifComponentCreatedBy = identity.User.UserID;
                    pY_EmpTarifComponent.EmpTarifComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpTarifComponent.Add(pY_EmpTarifComponent);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        public ActionResult CreateByEmpID(string EmpID)
        {
            List<int> lstCompID = new List<int>();
            ViewBag.EmpID = EmpID;
            var dbEmp = db.PY_EmpTarifComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            foreach (var a in dbEmp)
            {
                lstCompID.Add(a.TarifComponentID);
            }
            var dbTarif = db.PY_TarifComponent.Where(x => !lstCompID.Contains(x.TarifComponentID)).ToList();
            return View(dbTarif);
        }

        [HttpPost]
        public ActionResult CreateByEmpID(int[] chkTarif, string EmpID, double[] txtValue, PY_EmpTarifComponent pY_EmpTarifComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkTarif != null)
            {
                for (int i = 0; i < chkTarif.Length; i++)
                {
                    intFixedID = chkTarif[i];
                    dblValue = txtValue[i];
                    pY_EmpTarifComponent.TarifComponentID = (int)intFixedID;
                    pY_EmpTarifComponent.TarifComponentValue = (decimal)dblValue;
                    pY_EmpTarifComponent.EmpTarifComponentCreatedBy = identity.User.UserID;
                    pY_EmpTarifComponent.EmpTarifComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpTarifComponent.Add(pY_EmpTarifComponent);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        public ActionResult ListTarifComponentPartial()
        {
            var dbTarifComponent = db.PY_TarifComponent.ToList();
            ViewBag.Count = dbTarifComponent.Count;
            return PartialView("ListTarifComponentPartial", dbTarifComponent);
        }

        public ActionResult Edit(int id)
        {
            //List<int> lstFixedID = new List<int>();
            //List<PY_FixedComponent> dbFixed = null;
            //string EmpID = String.Empty;
            var dbEmpTarif = db.PY_EmpTarifComponent.Find(id);
            //if(dbEmpFixed != null)
            //{
            //    EmpID = dbEmpFixed.EmpID;
            //    var dbGetFixed = db.PY_EmpFixedComponent.Where(e => e.EmpID == EmpID).ToList();
            //    foreach(var a in dbGetFixed)
            //    {
            //        lstFixedID.Add(a.FixedComponentID);
            //    }
            //    dbFixed = db.PY_FixedComponent.Where(x => !lstFixedID.Contains(x.FixedComponentID)).ToList();
            //}
            //ViewBag.FixedComponentID = new SelectList(dbFixed.ToList(), "FixedComponentID", "FixedComponentName");
            return View(dbEmpTarif);
        }

        [HttpPost]
        public ActionResult Edit(PY_EmpTarifComponent pY_EmpTarifComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_EmpTarifComponent.EmpTarifComponentCreatedBy = identity.User.UserID;
                pY_EmpTarifComponent.EmpTarifComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_EmpTarifComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}