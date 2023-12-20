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
    public class ClosingProcessController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        // GET: ClosingProcess
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClsProcess(int Month, int Year)
        {
            PY_MonthlyEmpFixedComponent ModelEmpFixed = new PY_MonthlyEmpFixedComponent();
            PY_MonthlyEmpNonFixedComponent ModelEmpNonFixed = new PY_MonthlyEmpNonFixedComponent();
            PY_MonthlyEmpTarifComponent ModelEmpTarif = new PY_MonthlyEmpTarifComponent();
            PY_MonthlyEmpVariableComponent ModelEmpVariable = new PY_MonthlyEmpVariableComponent();
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            var dbEmpOccup = db.PA_EmployeeOccupation.ToList();
            foreach(var a in dbEmpOccup)
            {
                // Process Fixed Component
                var dbEmpFixed = db.PY_EmpFixedComponent.Where(e => e.EmployeeNo == a.EmployeeNo).ToList();
                foreach(var b in dbEmpFixed)
                {
                    ModelEmpFixed.EmployeeNo = a.EmployeeNo;
                    ModelEmpFixed.Month = Month;
                    ModelEmpFixed.Year = Year;

                    var ChkMonthFixed = db.PY_MonthlyEmpFixedComponent.Where(c => c.EmployeeNo == a.EmployeeNo && c.Month == Month && c.Year == Year && c.FixedComponentID == b.FixedComponentID).FirstOrDefault();
                    if(ChkMonthFixed != null)
                    {
                        var findMonthFixed = db.PY_MonthlyEmpFixedComponent.Find(ChkMonthFixed.MonthlyEmpFixedComponentID);
                        findMonthFixed.FixedComponentValue = b.FixedComponentValue;
                        db.Entry(findMonthFixed).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelEmpFixed.EmployeeNo = a.EmployeeNo;
                        ModelEmpFixed.Month = Month;
                        ModelEmpFixed.Year = Year;
                        ModelEmpFixed.FixedComponentID = b.FixedComponentID;
                        ModelEmpFixed.FixedComponentValue = b.FixedComponentValue;
                        ModelEmpFixed.EmpFixedComponentCreatedBy = identity.User.UserID;
                        ModelEmpFixed.EmpFixedComponentDateCreatedOn = DateTime.Now;
                        db.PY_MonthlyEmpFixedComponent.Add(ModelEmpFixed);
                        db.SaveChanges();
                    }
                }

                // Process Non Fixed Component
                var dbEmpNonFixed = db.PY_EmpNonFixedComponent.Where(e => e.EmployeeNo == a.EmployeeNo).ToList();
                foreach (var e in dbEmpNonFixed)
                {
                    ModelEmpNonFixed.EmployeeNo = a.EmployeeNo;
                    ModelEmpNonFixed.Month = Month;
                    ModelEmpNonFixed.Year = Year;

                    var ChkMonthNonFixed = db.PY_MonthlyEmpNonFixedComponent.Where(d => d.EmployeeNo == a.EmployeeNo && d.Month == Month && d.Year == Year && d.NonFixedComponentID == e.NonFixedComponentID).FirstOrDefault();
                    if (ChkMonthNonFixed != null)
                    {
                        var findMonthNonFixed = db.PY_MonthlyEmpNonFixedComponent.Find(ChkMonthNonFixed.MonthlyEmpNonFixedComponentID);
                        findMonthNonFixed.NonFixedComponentValue = e.NonFixedComponentValue;
                        db.Entry(findMonthNonFixed).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelEmpNonFixed.EmployeeNo = a.EmployeeNo;
                        ModelEmpNonFixed.Month = Month;
                        ModelEmpNonFixed.Year = Year;
                        ModelEmpNonFixed.NonFixedComponentID = e.NonFixedComponentID;
                        ModelEmpNonFixed.NonFixedComponentValue = e.NonFixedComponentValue;
                        ModelEmpNonFixed.EmpNonFixedComponentCreatedBy = identity.User.UserID;
                        ModelEmpNonFixed.EmpNonFixedComponentDateCreatedOn = DateTime.Now;
                        db.PY_MonthlyEmpNonFixedComponent.Add(ModelEmpNonFixed);
                        db.SaveChanges();
                    }
                }

                // Process Tarif Component
                var dbEmpTarif = db.PY_EmpTarifComponent.Where(e => e.EmployeeNo == a.EmployeeNo).ToList();
                foreach (var e in dbEmpTarif)
                {
                    ModelEmpTarif.EmployeeNo = a.EmployeeNo;
                    ModelEmpTarif.Month = Month;
                    ModelEmpTarif.Year = Year;

                    var ChkMonthTarif = db.PY_MonthlyEmpTarifComponent.Where(d => d.EmployeeNo == a.EmployeeNo && d.Month == Month && d.Year == Year && d.TarifComponentID == e.TarifComponentID).FirstOrDefault();
                    if (ChkMonthTarif != null)
                    {
                        var findMonthTarif = db.PY_MonthlyEmpTarifComponent.Find(ChkMonthTarif.MonthlyEmpTarifComponentID);
                        findMonthTarif.TarifComponentValue = e.TarifComponentValue;
                        db.Entry(findMonthTarif).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelEmpTarif.EmployeeNo = a.EmployeeNo;
                        ModelEmpTarif.Month = Month;
                        ModelEmpTarif.Year = Year;
                        ModelEmpTarif.TarifComponentID = e.TarifComponentID;
                        ModelEmpTarif.TarifComponentValue = e.TarifComponentValue;
                        ModelEmpTarif.EmpTarifComponentCreatedBy = identity.User.UserID;
                        ModelEmpTarif.EmpTarifComponentDateCreatedOn = DateTime.Now;
                        db.PY_MonthlyEmpTarifComponent.Add(ModelEmpTarif);
                        db.SaveChanges();
                    }
                }

                // Process Variable Component
                var dbEmpVariable = db.PY_EmpVariableComponent.Where(e => e.EmployeeNo == a.EmployeeNo).ToList();
                foreach (var e in dbEmpVariable)
                {
                    ModelEmpVariable.EmployeeNo = a.EmployeeNo;
                    ModelEmpVariable.Month = Month;
                    ModelEmpVariable.Year = Year;

                    var ChkMonthVariable = db.PY_MonthlyEmpVariableComponent.Where(d => d.EmployeeNo == a.EmployeeNo && d.Month == Month && d.Year == Year && d.VariableComponentID == e.VariableComponentID).FirstOrDefault();
                    if (ChkMonthVariable != null)
                    {
                        var findMonthVariable = db.PY_MonthlyEmpVariableComponent.Find(ChkMonthVariable.MonthlyEmpVariableComponentID);
                        findMonthVariable.VariableComponentValue = e.VariableComponentValue;
                        db.Entry(findMonthVariable).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        ModelEmpVariable.EmployeeNo = a.EmployeeNo;
                        ModelEmpVariable.Month = Month;
                        ModelEmpVariable.Year = Year;
                        ModelEmpVariable.VariableComponentID = e.VariableComponentID;
                        ModelEmpVariable.VariableComponentValue = e.VariableComponentValue;
                        ModelEmpVariable.EmpVariableComponentCreatedBy = identity.User.UserID;
                        ModelEmpVariable.EmpVariableComponentDateCreatedOn = DateTime.Now;
                        db.PY_MonthlyEmpVariableComponent.Add(ModelEmpVariable);
                        db.SaveChanges();
                    }
                }
            }
            return View();
        }
    }
}