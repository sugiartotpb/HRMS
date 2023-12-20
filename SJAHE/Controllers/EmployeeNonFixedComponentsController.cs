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
    public class EmployeeNonFixedComponentsController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: EmployeeNonFixedComponents
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

        public ActionResult EmpNonFixedComponentPartial(string EmpID)
        {
            var dbEmpNonFixed = db.PY_EmpNonFixedComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            return PartialView("EmpNonFixedComponentPartial", dbEmpNonFixed);
        }

        public ActionResult ListNonFixedComponentPartial()
        {
            var dbNonFixedComponent = db.PY_NonFixedComponent.ToList();
            ViewBag.Count = dbNonFixedComponent.Count;
            return PartialView("ListNonFixedComponentPartial", dbNonFixedComponent);
        }

        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(int[] chkNonFixed, string EmpID, double[] txtValue, PY_EmpNonFixedComponent pY_EmpNonFixedComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkNonFixed != null)
            {
                for (int i = 0; i < chkNonFixed.Length; i++)
                {
                    intFixedID = chkNonFixed[i];
                    dblValue = txtValue[i];
                    pY_EmpNonFixedComponent.NonFixedComponentID = (int)intFixedID;
                    pY_EmpNonFixedComponent.NonFixedComponentValue = (decimal)dblValue;
                    pY_EmpNonFixedComponent.EmpNonFixedComponentCreatedBy = identity.User.UserID;
                    pY_EmpNonFixedComponent.EmpNonFixedComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpNonFixedComponent.Add(pY_EmpNonFixedComponent);
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
            var dbEmp = db.PY_EmpNonFixedComponent.Where(e => e.EmployeeNo == EmpID).ToList();
            foreach (var a in dbEmp)
            {
                lstCompID.Add(a.NonFixedComponentID);
            }
            var dbNonFixed = db.PY_NonFixedComponent.Where(x => !lstCompID.Contains(x.NonFixedComponentID)).ToList();
            return View(dbNonFixed);
        }

        [HttpPost]
        public ActionResult CreateByEmpID(int[] chkNonFixed, string EmpID, double[] txtValue, PY_EmpNonFixedComponent pY_EmpNonFixedComponent)
        {
            int? intFixedID = null;
            double? dblValue = null;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            if (chkNonFixed != null)
            {
                for (int i = 0; i < chkNonFixed.Length; i++)
                {
                    intFixedID = chkNonFixed[i];
                    dblValue = txtValue[i];
                    pY_EmpNonFixedComponent.NonFixedComponentID = (int)intFixedID;
                    pY_EmpNonFixedComponent.NonFixedComponentValue = (decimal)dblValue;
                    pY_EmpNonFixedComponent.EmpNonFixedComponentCreatedBy = identity.User.UserID;
                    pY_EmpNonFixedComponent.EmpNonFixedComponentDateCreatedOn = DateTime.Now;

                    db.PY_EmpNonFixedComponent.Add(pY_EmpNonFixedComponent);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.PA_EmployeeOccupation.ToList(), "EmployeeNo", "EmployeeNo");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var dbEmpNonFixed = db.PY_EmpNonFixedComponent.Find(id);
            return View(dbEmpNonFixed);
        }

        [HttpPost]
        public ActionResult Edit(PY_EmpNonFixedComponent pY_EmpNonFixedComponent)
        {
            if (ModelState.IsValid)
            {
                var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
                pY_EmpNonFixedComponent.EmpNonFixedComponentCreatedBy = identity.User.UserID;
                pY_EmpNonFixedComponent.EmpNonFixedComponentDateCreatedOn = DateTime.Now;
                db.Entry(pY_EmpNonFixedComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}