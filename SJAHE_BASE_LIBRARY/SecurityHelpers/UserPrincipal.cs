using System.Security.Principal;
using System.Web.Security;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public class UserPrincipal : IPrincipal
    {
        private readonly UserIdentity UserIdentity;
        public UserPrincipal(UserIdentity _myIdentity)
        {
            UserIdentity = _myIdentity;
        }
        public IIdentity Identity
        {
            get { return UserIdentity; }
        }

        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }
    }
}
