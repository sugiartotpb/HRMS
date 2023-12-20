using SJAHE_BASE_LIBRARY.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SJAHE_BASE_LIBRARY.Helpers;
using SJAHE_BASE_LIBRARY.SecurityHelpers;

namespace SJAHE.Controllers
{
    [CustomAuthorize("Level1,Level2")]
    public class PayrollProcessController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        // GET: PayrollProcess
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PYProcess(int Month, int Year)
        {
            double dFixedResult = 0;
            double dNonFixedResult = 0;
            double dTarifResult = 0;
            double dVariableResult = 0;
            double dSalaryResult = 0;
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            PY_EmpSalaryCalculated pY_EmpSalaryCalculated = new PY_EmpSalaryCalculated();
            var dbFormulaFixed = db.PY_EmployeeFormulaFixedComponent.Where(c => c.FlagProcess == true).OrderBy(c => c.FormulaSequence).ToList();
            foreach (var i in dbFormulaFixed)
            {
                if (i.Condition != String.Empty)
                {
                    string[] b = null;
                    string pattern = @"\[(.*?)\]";
                    string formulaRemoveLine = String.Empty;
                    var emp = db.PY_EmployeeAbsenteeismComponents.Include(c => c.PA_EmployeeOccupation).Where(i.Condition).ToList();
                    foreach (var em in emp)
                    {
                        var matches = Regex.Matches(i.Formula, pattern);
                        formulaRemoveLine = i.Formula.Replace("\r\n", String.Empty);
                        List<string> lstStringTableName = new List<string>();
                        List<string> lstStringFieldName = new List<string>();
                        DataTable dt = new DataTable();
                        for (int q = 0; q < matches.Count; q++)
                        {
                            string strSplit = matches[q].ToString();
                            b = matches[q].ToString().Split('.');
                            string strTableName = b[0].Replace("[", string.Empty).Replace("]", string.Empty);
                            string strFieldName = b[1].Replace("[", string.Empty).Replace("]", string.Empty);

                            lstStringTableName.Add(strTableName);
                            lstStringFieldName.Add(strFieldName);

                            double value = GetFormulaValue.GetFixedComponentValue(strTableName, strFieldName, em.EmployeeNo, Month, Year);

                            formulaRemoveLine = formulaRemoveLine.Replace(strSplit, value.ToString());
                        }
                        var componentvalue = dt.Compute(formulaRemoveLine, "");
                        dFixedResult = Convert.ToDouble(componentvalue);
                        var dbFixedComponent = db.PY_MonthlyEmpFixedComponent.Where(c => c.EmployeeNo.Equals(em.EmployeeNo) && c.Month == Month && c.Year == Year && c.FixedComponentID == i.FixedComponentID).SingleOrDefault();
                        if (dbFixedComponent != null)
                        {
                            dbFixedComponent.FixedComponentPayrollProcess = (decimal)dFixedResult;
                            db.Entry(dbFixedComponent).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                dFixedResult = 0;
            }

            var dbFormulaNonFixed = db.PY_EmployeeFormulaNonFixedComponent.Where(c => c.FlagProcess == true).OrderBy(c => c.FormulaSequence).ToList();
            foreach (var i in dbFormulaNonFixed)
            {
                if (i.Condition != String.Empty)
                {
                    string[] b = null;
                    string pattern = @"\[(.*?)\]";
                    string formulaRemoveLine = String.Empty;
                    var emp = db.PY_EmployeeAbsenteeismComponents.Include(c => c.PA_EmployeeOccupation).Where(i.Condition).ToList();
                    foreach (var em in emp)
                    {
                        var matches = Regex.Matches(i.Formula, pattern);
                        formulaRemoveLine = i.Formula.Replace("\r\n", String.Empty);
                        List<string> lstStringTableName = new List<string>();
                        List<string> lstStringFieldName = new List<string>();
                        DataTable dt = new DataTable();
                        for (int q = 0; q < matches.Count; q++)
                        {
                            string strSplit = matches[q].ToString();
                            b = matches[q].ToString().Split('.');
                            string strTableName = b[0].Replace("[", string.Empty).Replace("]", string.Empty);
                            string strFieldName = b[1].Replace("[", string.Empty).Replace("]", string.Empty);

                            lstStringTableName.Add(strTableName);
                            lstStringFieldName.Add(strFieldName);

                            double value = GetFormulaValue.GetNonFixedComponentValue(strTableName, strFieldName, em.EmployeeNo, Month, Year);

                            formulaRemoveLine = formulaRemoveLine.Replace(strSplit, value.ToString());
                        }
                        var componentvalue = dt.Compute(formulaRemoveLine, "");
                        dNonFixedResult = Convert.ToDouble(componentvalue);
                        var dbNonFixedComponent = db.PY_MonthlyEmpNonFixedComponent.Where(c => c.EmployeeNo.Equals(em.EmployeeNo) && c.Month == Month && c.Year == Year && c.NonFixedComponentID == i.NonFixedComponentID).SingleOrDefault();
                        if (dbNonFixedComponent != null)
                        {
                            dbNonFixedComponent.NonFixedComponentPayrollProcess = (decimal)dNonFixedResult;
                            db.Entry(dbNonFixedComponent).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                dNonFixedResult = 0;
            }

            var dbFormulaTarif = db.PY_EmployeeFormulaTarifComponent.Where(c => c.FlagProcess == true).OrderBy(c => c.FormulaSequence).ToList();
            foreach (var i in dbFormulaTarif)
            {
                if (i.Condition != String.Empty)
                {
                    string[] b = null;
                    string pattern = @"\[(.*?)\]";
                    string formulaRemoveLine = String.Empty;
                    var emp = db.PY_EmployeeAbsenteeismComponents.Include(c => c.PA_EmployeeOccupation).Where(i.Condition).ToList();
                    foreach (var em in emp)
                    {
                        var matches = Regex.Matches(i.Formula, pattern);
                        formulaRemoveLine = i.Formula.Replace("\r\n", String.Empty);
                        List<string> lstStringTableName = new List<string>();
                        List<string> lstStringFieldName = new List<string>();
                        DataTable dt = new DataTable();
                        for (int q = 0; q < matches.Count; q++)
                        {
                            string strSplit = matches[q].ToString();
                            b = matches[q].ToString().Split('.');
                            string strTableName = b[0].Replace("[", string.Empty).Replace("]", string.Empty);
                            string strFieldName = b[1].Replace("[", string.Empty).Replace("]", string.Empty);

                            lstStringTableName.Add(strTableName);
                            lstStringFieldName.Add(strFieldName);

                            double value = GetFormulaValue.GetTarifComponentValue(strTableName, strFieldName, em.EmployeeNo, Month, Year);

                            formulaRemoveLine = formulaRemoveLine.Replace(strSplit, value.ToString());
                        }
                        var componentvalue = dt.Compute(formulaRemoveLine, "");
                        dTarifResult = Convert.ToDouble(componentvalue);
                        var dbTarifComponent = db.PY_MonthlyEmpTarifComponent.Where(c => c.EmployeeNo.Equals(em.EmployeeNo) && c.Month == Month && c.Year == Year && c.TarifComponentID == i.TarifComponentID).SingleOrDefault();
                        if (dbTarifComponent != null)
                        {
                            dbTarifComponent.TarifComponentPayrollProcess = (decimal)dTarifResult;
                            db.Entry(dbTarifComponent).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                dTarifResult = 0;
            }

            var dbFormulaVariable = db.PY_EmployeeFormulaVariableComponent.Where(c => c.FlagProcess == true).OrderBy(c => c.FormulaSequence).ToList();
            foreach (var i in dbFormulaVariable)
            {
                if (i.Condition != String.Empty)
                {
                    string[] b = null;
                    string pattern = @"\[(.*?)\]";
                    string formulaRemoveLine = String.Empty;
                    var emp = db.PY_EmployeeAbsenteeismComponents.Include(c => c.PA_EmployeeOccupation).Where(i.Condition).ToList();
                    foreach (var em in emp)
                    {
                        var matches = Regex.Matches(i.Formula, pattern);
                        formulaRemoveLine = i.Formula.Replace("\r\n", String.Empty);
                        List<string> lstStringTableName = new List<string>();
                        List<string> lstStringFieldName = new List<string>();
                        DataTable dt = new DataTable();
                        for (int q = 0; q < matches.Count; q++)
                        {
                            string strSplit = matches[q].ToString();
                            b = matches[q].ToString().Split('.');
                            string strTableName = b[0].Replace("[", string.Empty).Replace("]", string.Empty);
                            string strFieldName = b[1].Replace("[", string.Empty).Replace("]", string.Empty);

                            lstStringTableName.Add(strTableName);
                            lstStringFieldName.Add(strFieldName);

                            double value = GetFormulaValue.GetVariableComponentValue(strTableName, strFieldName, em.EmployeeNo, Month, Year);

                            formulaRemoveLine = formulaRemoveLine.Replace(strSplit, value.ToString());
                        }
                        var componentvalue = dt.Compute(formulaRemoveLine, "");
                        dVariableResult = Convert.ToDouble(componentvalue);
                        var dbVariableComponent = db.PY_MonthlyEmpVariableComponent.Where(c => c.EmployeeNo.Equals(em.EmployeeNo) && c.Month == Month && c.Year == Year && c.VariableComponentID == i.VariableComponentID).SingleOrDefault();
                        if (dbVariableComponent != null)
                        {
                            dbVariableComponent.VariableComponentValue = (decimal)dVariableResult;
                            db.Entry(dbVariableComponent).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                dVariableResult = 0;
            }

            var dbFormulaSalary = db.PY_PayrollFormulaSalary.Where(c => c.FlagProcess == true).OrderBy(c => c.SequenceNo).ToList();
            foreach(var i in dbFormulaSalary)
            {
                if (i.Condition != String.Empty)
                {
                    string[] b = null;
                    string pattern = @"\[(.*?)\]";
                    string formulaRemoveLine = String.Empty;
                    var emp = db.PY_EmployeeAbsenteeismComponents.Include(c => c.PA_EmployeeOccupation).Where(i.Condition).ToList();
                    foreach (var em in emp)
                    {
                        var matches = Regex.Matches(i.Formula, pattern);
                        formulaRemoveLine = i.Formula.Replace("\r\n", String.Empty);
                        List<string> lstStringTableName = new List<string>();
                        List<string> lstStringFieldName = new List<string>();
                        DataTable dt = new DataTable();
                        for (int q = 0; q < matches.Count; q++)
                        {
                            string strSplit = matches[q].ToString();
                            b = matches[q].ToString().Split('.');
                            string strTableName = b[0].Replace("[", string.Empty).Replace("]", string.Empty);
                            string strFieldName = b[1].Replace("[", string.Empty).Replace("]", string.Empty);

                            lstStringTableName.Add(strTableName);
                            lstStringFieldName.Add(strFieldName);

                            double value = GetFormulaSalaryValue.GetSalaryComponentValue(strTableName, strFieldName, em.EmployeeNo, Month, Year);

                            formulaRemoveLine = formulaRemoveLine.Replace(strSplit, value.ToString());
                        }
                        var componentvalue = dt.Compute(formulaRemoveLine, "");
                        dSalaryResult = Convert.ToDouble(componentvalue);
                        var dbSalaryComponent = db.PY_EmpSalaryCalculated.Where(c => c.EmployeeNo.Equals(em.EmployeeNo) && c.Month == Month && c.Year == Year && c.SalaryComponentID == i.SalaryComponentID).SingleOrDefault();
                        if (dbSalaryComponent != null)
                        {
                            dbSalaryComponent.ComponentValue = (decimal)dSalaryResult;
                            db.Entry(dbSalaryComponent).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            pY_EmpSalaryCalculated.EmployeeNo = em.EmployeeNo;
                            pY_EmpSalaryCalculated.SalaryComponentID = i.SalaryComponentID;
                            pY_EmpSalaryCalculated.ComponentValue = (decimal)dSalaryResult;
                            pY_EmpSalaryCalculated.Month = Month;
                            pY_EmpSalaryCalculated.Year = Year;
                            pY_EmpSalaryCalculated.CreatedBy = identity.User.UserID;
                            pY_EmpSalaryCalculated.DateCreated = DateTime.Now;
                            db.PY_EmpSalaryCalculated.Add(pY_EmpSalaryCalculated);
                            db.SaveChanges();
                        }
                    }
                }
                dSalaryResult = 0;
            }

            return View();
        }
    }
}