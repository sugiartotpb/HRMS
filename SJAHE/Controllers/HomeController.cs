using SJAHE_BASE_LIBRARY.Models;
using SJAHE_BASE_LIBRARY.SecurityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Data.Entity;
using SJAHE.Models;

namespace SJAHE.Controllers
{
    
    public class HomeController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();
        

        [CustomAuthorize("Level1,Level2")]
        public ActionResult Index()
        {
            var dbModule = db.AP_ApplicationModule.Include(a => a.AP_Menu).Include(a => a.AP_Menu).ToList();
            return View(dbModule);
        }

        public ActionResult Menus()
        {
            List<Menu_Model> lstMenu = new List<Menu_Model>();
            var identity = (System.Web.HttpContext.Current.User as UserPrincipal).Identity as UserIdentity;
            int dbUserRoleID = db.SC_UserRole.Where(u => u.UserID == identity.User.UserID).SingleOrDefault().UserRoleID;
            ViewBag.UserRoleID = dbUserRoleID;
            var dbModuleUser = db.SC_MenuUserRole.Include(a=>a.AP_ApplicationModule).Where(a=>a.UserRoleID == dbUserRoleID).Select(a=> new { a.ApplicationModuleID, a.AP_ApplicationModule.ApplicationModuleName }).Distinct().ToList();
            foreach (var a in dbModuleUser)
            {
                var dbMenuUser = db.SC_MenuUserRole.Include(b => b.AP_Menu).OrderBy(b=>b.AP_Menu.Sequence).Where(b => b.UserRoleID == dbUserRoleID && b.ApplicationModuleID == a.ApplicationModuleID).Select(b => new { b.MenuID, b.AP_Menu.MenuName}).Distinct().ToList();
                foreach(var c in dbMenuUser)
                {
                    lstMenu.Add(new Menu_Model
                    {
                        MenuID = c.MenuID,
                        MenuName = c.MenuName
                    });
                }
            }
            return PartialView("Menus", lstMenu);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}