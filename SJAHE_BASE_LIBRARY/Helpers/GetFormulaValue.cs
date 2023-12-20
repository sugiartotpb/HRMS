using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SJAHE_BASE_LIBRARY.Models;

namespace SJAHE_BASE_LIBRARY.Helpers
{
    public class GetFormulaValue
    {
        private static sjahe_dbcontext db = new sjahe_dbcontext();
        public static double GetFixedComponentValue(string strTable, string strFieldName, string EmpNo, int Month, int Year)
        {
            double value = 0;
            string strValue = String.Empty;
            if (strTable == "PY_MonthlyEmpFixedComponent")
            {
                value = (double)db.PY_MonthlyEmpFixedComponent.Include(c=>c.PY_FixedComponent).Where(c => c.PY_FixedComponent.FixedComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().FixedComponentValue;
            }
            if(strTable == "PY_EmployeeAbsenteeismComponents")
            {
                var _tableRepository = db.PY_EmployeeAbsenteeismComponents.Where(x => x.EmployeeNo.Equals(EmpNo) && x.Year == Year && x.Month == Month).SingleOrDefault();//.FirstOrDefault();
                if (_tableRepository == null) return 0;

                var _value = _tableRepository.GetType().GetProperties().Where(a => a.Name == strFieldName).Select(p => p.GetValue(_tableRepository, null)).FirstOrDefault();
                value = Convert.ToDouble(_value);
            }
            return value;
        }

        public static double GetNonFixedComponentValue(string strTable, string strFieldName, string EmpNo, int Month, int Year)
        {
            double value = 0;
            string strValue = String.Empty;
            if (strTable == "PY_MonthlyEmpNonFixedComponent")
            {
                value = (double)db.PY_MonthlyEmpNonFixedComponent.Include(c => c.PY_NonFixedComponent).Where(c => c.PY_NonFixedComponent.NonFixedComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().NonFixedComponentValue;
            }
            if (strTable == "PY_EmployeeAbsenteeismComponents")
            {
                var _tableRepository = db.PY_EmployeeAbsenteeismComponents.Where(x => x.EmployeeNo.Equals(EmpNo) && x.Year == Year && x.Month == Month).SingleOrDefault();//.FirstOrDefault();
                if (_tableRepository == null) return 0;

                var _value = _tableRepository.GetType().GetProperties().Where(a => a.Name == strFieldName).Select(p => p.GetValue(_tableRepository, null)).FirstOrDefault();
                value = Convert.ToDouble(_value);
            }
            return value;
        }

        public static double GetTarifComponentValue(string strTable, string strFieldName, string EmpNo, int Month, int Year)
        {
            double value = 0;
            string strValue = String.Empty;
            if (strTable == "PY_MonthlyEmpTarifComponent")
            {
                value = (double)db.PY_MonthlyEmpTarifComponent.Include(c => c.PY_TarifComponent).Where(c => c.PY_TarifComponent.TarifComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().TarifComponentValue;
            }
            if (strTable == "PY_EmployeeAbsenteeismComponents")
            {
                var _tableRepository = db.PY_EmployeeAbsenteeismComponents.Where(x => x.EmployeeNo.Equals(EmpNo) && x.Year == Year && x.Month == Month).SingleOrDefault();//.FirstOrDefault();
                if (_tableRepository == null) return 0;

                var _value = _tableRepository.GetType().GetProperties().Where(a => a.Name == strFieldName).Select(p => p.GetValue(_tableRepository, null)).FirstOrDefault();
                value = Convert.ToDouble(_value);
            }
            return value;
        }

        public static double GetVariableComponentValue(string strTable, string strFieldName, string EmpNo, int Month, int Year)
        {
            double value = 0;
            string strValue = String.Empty;
            if (strTable == "PY_MonthlyEmpVariableComponent")
            {
                value = (double)db.PY_MonthlyEmpVariableComponent.Include(c => c.PY_VariableComponent).Where(c => c.PY_VariableComponent.VariableComponentName == strFieldName && c.EmployeeNo == EmpNo && c.Month == Month && c.Year == Year).SingleOrDefault().VariableComponentValue;
            }
            if (strTable == "PY_EmployeeAbsenteeismComponents")
            {
                var _tableRepository = db.PY_EmployeeAbsenteeismComponents.Where(x => x.EmployeeNo.Equals(EmpNo) && x.Year == Year && x.Month == Month).SingleOrDefault();//.FirstOrDefault();
                if (_tableRepository == null) return 0;

                var _value = _tableRepository.GetType().GetProperties().Where(a => a.Name == strFieldName).Select(p => p.GetValue(_tableRepository, null)).FirstOrDefault();
                value = Convert.ToDouble(_value);
            }
            return value;
        }
    }
}