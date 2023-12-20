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
    public class EmployeeFixedComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        // GET: EmployeeFixedComponents

        
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            
            var dbEmpCount = db.PA_EmployeeOccupation.ToList();
            ViewBag.CountEmp = dbEmpCount.Count;

            IPagedList<PA_EmployeeOccupation> dbEmpFixed = null;

            dbEmpFixed = db.PA_EmployeeOccupation.OrderBy(e=>e.EmployeeNo).ToPagedList(pageIndex, pageSize);//db.PY_EmpFixedComponent.ToList();
            return View(dbEmpFixed);
        }

        public ActionResult SearchPartial(string txtEmpID, int? page)
        {
            int pageSize = 10;
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

        public ActionResult EmpFixedComponentPartial(string EmpID)
        {
            var dbEmpFixed = db.PY_EmpFixedComponent.Where(e=>e.EmployeeNo == EmpID).ToList();
            return PartialView("EmpFixedComponentPartial", dbEmpFixed);
        }

        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(int[] chkFixed, string EmpID, double[] txtValue, PY_EmpFixedComponent pY_EmpFixedComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkFixed != null)
            {
                for(int i = 0; i < chkFixed.Length; i++)
                {
                    intFixedID = chkFixed[i];
                    dblValue = txtValue[i];
                    pY_EmpFixedComponent.FixedComponentID = (int)intFixedID;
                    pY_EmpFixedComponent.FixedComponentValue = (decimal)dblValue;
                    pY_EmpFixedComponent.EmpFixedComponentCreatedBy = identity.User.UserID;
                    pY_EmpFixedComponent.EmpFixedComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpFixedComponent.Add(pY_EmpFixedComponent);
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
            var dbEmp = db.PY_EmpFixedComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            foreach(var a in dbEmp)
            {
                lstCompID.Add(a.FixedComponentID);
            }
            var dbFixed = db.PY_FixedComponent.Where(x => !lstCompID.Contains(x.FixedComponentID)).ToList();
            return View(dbFixed);
        }

        [HttpPost]
        public ActionResult CreateByEmpID(int[] chkFixed, string EmpID, double[] txtValue, PY_EmpFixedComponent pY_EmpFixedComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkFixed != null)
            {
                for (int i = 0; i < chkFixed.Length; i++)
                {
                    intFixedID = chkFixed[i];
                    dblValue = txtValue[i];
                    pY_EmpFixedComponent.FixedComponentID = (int)intFixedID;
                    pY_EmpFixedComponent.FixedComponentValue = (decimal)dblValue;
                    pY_EmpFixedComponent.EmpFixedComponentCreatedBy = identity.User.UserID;
                    pY_EmpFixedComponent.EmpFixedComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpFixedComponent.Add(pY_EmpFixedComponent);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        public ActionResult ListFixedComponentPartial()
        {
            var dbFixedComponent = db.PY_FixedComponent.ToList();
            ViewBag.Count = dbFixedComponent.Count;
            return PartialView("ListFixedComponentPartial", dbFixedComponent);
        }

        public ActionResult Edit(int id)
        {
            //List<int> lstFixedID = new List<int>();
            //List<PY_FixedComponent> dbFixed = null;
            //string EmpID = String.Empty;
            var dbEmpFixed = db.PY_EmpFixedComponent.Find(id);
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
            return View(dbEmpFixed);
        }

        [HttpPost]
        public ActionResult Edit(PY_EmpFixedComponent pY_EmpFixedComponent)
        {
            if(ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_EmpFixedComponent.EmpFixedComponentCreatedBy = identity.User.UserID;
                pY_EmpFixedComponent.EmpFixedComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_EmpFixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}