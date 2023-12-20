using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public class CustomRoleRequirement : System.Web.Security.SqlRoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] currentUserRoles = { "Admin", "User" };
            return currentUserRoles;
        }
    }
}
