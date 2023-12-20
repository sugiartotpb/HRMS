using SJAHE_BASE_LIBRARY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SJAHE_BASE_LIBRARY.Helpers
{
    public class GetFormulaSalaryValue
    {
        private static sjahe_dbcontext db = new sjahe_dbcontext();
        public static double GetSalaryComponentValue(string strTable, string strFieldName, string EmpNo, int Month, int Year)
        {
            double value = 0;
            string strValue = String.Empty;
            if (strTable == "PY_MonthlyEmpFixedComponent")
            {
                value = (double)db.PY_MonthlyEmpFixedComponent.Include(c => c.PY_FixedComponent).Where(c => c.PY_FixedComponent.FixedComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().FixedComponentPayrollProcess;
            }
            else if (strTable == "PY_MonthlyEmpNonFixedComponent")
            {
                value = (double)db.PY_MonthlyEmpNonFixedComponent.Include(c => c.PY_NonFixedComponent).Where(c => c.PY_NonFixedComponent.NonFixedComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().NonFixedComponentPayrollProcess;
            }
            else if (strTable == "PY_MonthlyEmpTarifComponent")
            {
                value = (double)db.PY_MonthlyEmpTarifComponent.Include(c => c.PY_TarifComponent).Where(c => c.PY_TarifComponent.TarifComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().TarifComponentPayrollProcess;
            }
            else if (strTable == "PY_MonthlyEmpVariableComponent")
            {
                value = (double)db.PY_MonthlyEmpVariableComponent.Include(c => c.PY_VariableComponent).Where(c => c.PY_VariableComponent.VariableComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().VariableComponentPayrollProcess;
            }
            return value;
        }
    }
}
