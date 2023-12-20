using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SJAHE_BASE_LIBRARY.Models;
using System.Web.Security;
using System.Web;
using System.Web.Caching;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public class UserRoleProvider : RoleProvider
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        private int _cacheTimeoutInMinute = 20;

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }

            //check cache
            var cacheKey = string.Format("{0}_role", username);
            if (HttpRuntime.Cache[cacheKey] != null)
            {
                return (string[])HttpRuntime.Cache[cacheKey];
            }
            string[] roles = new string[] { };
            List<string> lstroles = new List<string>();
            using (sjahe_dbcontext dc = new sjahe_dbcontext())
            {
                var dbUserManagement = db.SC_UserRole.Include(c => c.SC_User).Include(c => c.SC_Role).Where(c => c.SC_User.UserName.Equals(username)).ToList();
                foreach (var i in dbUserManagement)
                {
                    lstroles.Add(i.SC_Role.RoleName);
                }
                roles = lstroles.ToArray();
                if (roles.Count() > 0)
                {
                    HttpRuntime.Cache.Insert(cacheKey, roles, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinute), Cache.NoSlidingExpiration);

                }
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
