using System.Data.Entity;

namespace SJAHE_BASE_LIBRARY.Models
{
    public class sjahe_dbcontext : DbContext
    {
        public sjahe_dbcontext() : base("ConnString") { }

        public DbSet<SC_Role> SC_Role { get; set; }
        public DbSet<SC_User> SC_User { get; set; }
        public DbSet<SC_UserRole> SC_UserRole { get; set; }

        public System.Data.Entity.DbSet<AP_ApplicationModule> AP_ApplicationModule { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.AP_Menu> AP_Menu { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.AP_SubMenu> AP_SubMenu { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.AP_SubChildMenu> AP_SubChildMenu { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.SC_MenuUserRole> SC_MenuUserRole { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_FixedComponent> PY_FixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_NonFixedComponent> PY_NonFixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_TarifComponent> PY_TarifComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_VariableComponent> PY_VariableComponent { get; set; }

        public System.Data.Entity.DbSet<PY_EmpFixedComponent> PY_EmpFixedComponent { get; set; }

        public System.Data.Entity.DbSet<PY_EmpNonFixedComponent> PY_EmpNonFixedComponent { get; set; }

        public System.Data.Entity.DbSet<PY_EmpVariableComponent> PY_EmpVariableComponent { get; set; }

        public System.Data.Entity.DbSet<PY_EmpTarifComponent> PY_EmpTarifComponent { get; set; }

        public System.Data.Entity.DbSet<PA_EmployeeOccupation> PA_EmployeeOccupation { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PA_LevelType> PA_LevelType { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PA_Level> PA_Level { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PA_Grade> PA_Grade { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PA_Position> PA_Position { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_PayrollPeriod> PY_PayrollPeriod { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_MonthlyEmpFixedComponent> PY_MonthlyEmpFixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_MonthlyEmpNonFixedComponent> PY_MonthlyEmpNonFixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_MonthlyEmpTarifComponent> PY_MonthlyEmpTarifComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_MonthlyEmpVariableComponent> PY_MonthlyEmpVariableComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeFormulaComponent> PY_EmployeeFormulaComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeAbsenteeismComponents> PY_EmployeeAbsenteeismComponents { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeFormulaFixedComponent> PY_EmployeeFormulaFixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeFormulaNonFixedComponent> PY_EmployeeFormulaNonFixedComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeFormulaTarifComponent> PY_EmployeeFormulaTarifComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmployeeFormulaVariableComponent> PY_EmployeeFormulaVariableComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_SalaryComponent> PY_SalaryComponent { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_PayrollFormulaSalary> PY_PayrollFormulaSalary { get; set; }

        public System.Data.Entity.DbSet<SJAHE_BASE_LIBRARY.Models.PY_EmpSalaryCalculated> PY_EmpSalaryCalculated { get; set; }
    }
}
