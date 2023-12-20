using SJAHE_BASE_LIBRARY.Models;
using System.Security.Principal;

namespace SJAHE_BASE_LIBRARY.SecurityHelpers
{
    public class UserIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public SC_User User { get; set; }

        public UserIdentity(SC_User user)
        {
            Identity = new GenericIdentity(user.UserName);
            User = user;
        }

        public string AuthenticationType
        {
            get
            {
                return Identity.AuthenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return Identity.IsAuthenticated;
            }
        }

        public string Name
        {
            get
            {
                return Identity.Name;
            }
        }
    }
}
