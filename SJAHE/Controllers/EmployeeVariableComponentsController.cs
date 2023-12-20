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
    public class EmployeeVariableComponentsController : Controller
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

        public ActionResult EmpVariableComponentPartial(string EmpID)
        {
            var dbEmpVariable = db.PY_EmpVariableComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            return PartialView("EmpVariableComponentPartial", dbEmpVariable);
        }
        
        public ActionResult CreateByEmpID(string EmpID)
        {
            List<int> lstCompID = new List<int>();
            ViewBag.EmpID = EmpID;
            var dbEmp = db.PY_EmpVariableComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            foreach (var a in dbEmp)
            {
                lstCompID.Add(a.VariableComponentID);
            }
            var dbVariable = db.PY_VariableComponent.Where(x => !lstCompID.Contains(x.VariableComponentID)).ToList();
            return View(dbVariable);
        }

        [HttpPost]
        public ActionResult CreateByEmpID(int[] chkVariable, string EmpID, double[] txtValue, PY_EmpVariableComponent pY_EmpVariableComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkVariable != null)
            {
                for (int i = 0; i < chkVariable.Length; i++)
                {
                    intFixedID = chkVariable[i];
                    dblValue = txtValue[i];
                    pY_EmpVariableComponent.VariableComponentID = (int)intFixedID;
                    pY_EmpVariableComponent.VariableComponentValue = (decimal)dblValue;
                    pY_EmpVariableComponent.EmpVariableComponentCreatedBy = identity.User.UserID;
                    pY_EmpVariableComponent.EmpVariableComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpVariableComponent.Add(pY_EmpVariableComponent);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        public ActionResult ListVariableComponentPartial()
        {
            var dbVariableComponent = db.PY_VariableComponent.ToList();
            ViewBag.Count = dbVariableComponent.Count;
            return PartialView("ListVariableComponentPartial", dbVariableComponent);
        }

        public ActionResult Edit(int id)
        {
            //List<int> lstFixedID = new List<int>();
            //List<PY_FixedComponent> dbFixed = null;
            //string EmpID = String.Empty;
            var dbEmpVariable = db.PY_EmpVariableComponent.Find(id);
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
            return View(dbEmpVariable);
        }

        [HttpPost]
        public ActionResult Edit(PY_EmpVariableComponent pY_EmpVariableComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_EmpVariableComponent.EmpVariableComponentCreatedBy = identity.User.UserID;
                pY_EmpVariableComponent.EmpVariableComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_EmpVariableComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}