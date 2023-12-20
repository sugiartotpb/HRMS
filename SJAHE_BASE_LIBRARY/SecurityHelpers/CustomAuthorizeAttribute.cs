using SJAHE_BASE_LIBRARY.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Linq;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private static sjahe_dbcontext db = new sjahe_dbcontext();
        public CustomAuthorizeAttribute(string roleKeys)
        {
            //var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            //var dbUser = db.SC_UserRole.Include(c=>c.SC_Role).ToList();
            string[] keyRoles = roleKeys.Split(',');
            var roles = new List<string>();
            var allRoles = (NameValueCollection)ConfigurationManager.GetSection("CustomRoles");
            foreach (var roleKey in keyRoles)
            {
                roles.AddRange(allRoles[roleKey].Split(new[] { ',' }));
            }
            //foreach (var i in dbUser)
            //{
            //    roles.AddRange(i.SC_Role.RoleName.Split(new[] { ',' }));
            //}
            Roles = string.Join(",", roles);
        }
    }
}
