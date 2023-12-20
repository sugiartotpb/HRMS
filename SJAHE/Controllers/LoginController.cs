using SJAHE_BASE_LIBRARY.Models;
using SJAHE_BASE_LIBRARY.SecurityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SJAHE.Controllers
{
    public class LoginController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string ReturnUrl)
        {
            var getUser = (from s in db.SC_User where s.UserName.Equals(UserName) || s.UserEmailAddress.Equals(UserName) select s).FirstOrDefault();
            if (getUser != null)
            {
                if (ModelState.IsValid)
                {
                    //var hashCode = getUser.user_vcode;
                    UserMembershipProvider userMember = new UserMembershipProvider();

                    //var encodingPasswordString = Password_helper.EncodePassword(Password, hashCode);
                    bool isValidUser = userMember.ValidateUser(UserName, Password);//Membership.ValidateUser(l.username, encodingPasswordString);
                    if (isValidUser)
                    {
                        SC_User user = null;
                        using (sjahe_dbcontext dc = new sjahe_dbcontext())
                        {
                            user = db.SC_User.Where(a => a.UserName.Equals(UserName)).FirstOrDefault();
                        }

                        if (user != null)
                        {
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            string data = js.Serialize(user);
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), false, data);
                            string encToken = FormsAuthentication.Encrypt(ticket);
                            HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                            Response.Cookies.Add(authoCookies);
                            //return Redirect(ReturnUrl);
                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
            ModelState.Remove("Password");
            return View();
        }
    }
}