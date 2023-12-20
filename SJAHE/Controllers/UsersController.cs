using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SJAHE_BASE_LIBRARY.Models;
using SJAHE_BASE_LIBRARY.SecurityHelpers;
using System.IO;

namespace SJAHE.Controllers
{
    [CustomAuthorize("Level1")]
    public class UsersController : Controller
    {
        private sjahe_dbcontext db = new sjahe_dbcontext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.SC_User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_User sC_User = db.SC_User.Find(id);
            if (sC_User == null)
            {
                return HttpNotFound();
            }
            return View(sC_User);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserFullName,UserEmailAddress,UserContactNo,UserName,UserPassword,UserImageUrl,UserStatus")] SC_User sC_User, HttpPostedFileBase UserImageUrl)
        {
            if (ModelState.IsValid)
            {
                string Seed = "S1Fsrvcs";
                var chkUserEmail = db.SC_User.Where(u => u.UserEmailAddress == sC_User.UserEmailAddress).ToList();
                if (chkUserEmail.Count == 0)
                {
                    if(UserImageUrl != null)
                    {
                        var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg" };
                        sC_User.UserImageUrl = UserImageUrl.ToString(); //getting complete url
                        var fileName = Path.GetFileName(UserImageUrl.FileName);
                        var ext = Path.GetExtension(UserImageUrl.FileName);
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = sC_User.UserFullName + DateTime.Now.ToString("yyyyddMMHH") + ext; //appending the name with id  
                                                                                                              // store the file inside ~/project folder(Img)  
                            var path = Path.Combine(Server.MapPath("~/Images/UserImages"), myfile);
                            sC_User.UserImageUrl = myfile;
                            //string password = SecurityEncryptedDecrypted.EncrypedProtectString(sC_User.UserPassword);
                            string password = SecurityEncryptedDecrypted.EncryptText(sC_User.UserPassword, Seed);
                            sC_User.UserPassword = password;
                            db.SC_User.Add(sC_User);
                            db.SaveChanges();
                            UserImageUrl.SaveAs(path);
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        db.SC_User.Add(sC_User);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(sC_User);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string Seed = "S1Fsrvcs";
            SC_User sC_User = db.SC_User.Find(id);
            string password = SecurityEncryptedDecrypted.DecryptText(sC_User.UserPassword, Seed);
            sC_User.UserPassword = password;
            if (sC_User == null)
            {
                return HttpNotFound();
            }
            return View(sC_User);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserFullName,UserEmailAddress,UserContactNo,UserName,UserPassword,UserImageUrl,UserStatus")] SC_User sC_User, HttpPostedFileBase UserImageUrl, int UserID)
        {
            if (ModelState.IsValid)
            {
                string Seed = "S1Fsrvcs";
                if (UserImageUrl != null)
                {
                    var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg" };
                    sC_User.UserImageUrl = UserImageUrl.ToString(); 
                    var fileName = Path.GetFileName(UserImageUrl.FileName);
                    var ext = Path.GetExtension(UserImageUrl.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string myfile = sC_User.UserFullName + DateTime.Now.ToString("yyyyddMMHH") + ext; 
                        var path = Path.Combine(Server.MapPath("~/Images/UserImages"), myfile);
                        sC_User.UserImageUrl = myfile;
                        string password = SecurityEncryptedDecrypted.EncryptText(sC_User.UserPassword, Seed);
                        sC_User.UserPassword = password;
                        db.Entry(sC_User).State = EntityState.Modified;
                        db.SaveChanges();
                        UserImageUrl.SaveAs(path);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    var dbUser = db.SC_User.Find(UserID);
                    string password = SecurityEncryptedDecrypted.EncryptText(sC_User.UserPassword, Seed);
                    dbUser.UserFullName = sC_User.UserFullName;
                    dbUser.UserEmailAddress = sC_User.UserEmailAddress;
                    dbUser.UserContactNo = sC_User.UserContactNo;
                    dbUser.UserName = sC_User.UserName;
                    dbUser.UserPassword = password;
                    dbUser.UserStatus = sC_User.UserStatus;
                    db.Entry(dbUser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(sC_User);
        }

        // GET: Users/Edit/5
        public ActionResult CopyRecords(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_User sC_User = db.SC_User.Find(id);
            if (sC_User == null)
            {
                return HttpNotFound();
            }
            return View(sC_User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CopyRecords([Bind(Include = "UserID,UserFullName,UserEmailAddress,UserContactNo,UserName,UserPassword,UserImageUrl,UserStatus")] SC_User sC_User, HttpPostedFileBase UserImageUrl)
        {
            if (ModelState.IsValid)
            {
                string Seed = "S1Fsrvcs";
                var chkUserEmail = db.SC_User.Where(u => u.UserEmailAddress == sC_User.UserEmailAddress).ToList();
                if (chkUserEmail.Count == 0)
                {
                    if (UserImageUrl != null)
                    {
                        var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg" };
                        sC_User.UserImageUrl = UserImageUrl.ToString(); //getting complete url
                        var fileName = Path.GetFileName(UserImageUrl.FileName);
                        var ext = Path.GetExtension(UserImageUrl.FileName);
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = sC_User.UserFullName + DateTime.Now.ToString("yyyyddMMHH") + ext; //appending the name with id  
                                                                                                              // store the file inside ~/project folder(Img)  
                            var path = Path.Combine(Server.MapPath("~/Images/UserImages"), myfile);
                            sC_User.UserImageUrl = myfile;
                            string password = SecurityEncryptedDecrypted.EncryptText(sC_User.UserPassword, Seed);
                            sC_User.UserPassword = password;
                            db.SC_User.Add(sC_User);
                            db.SaveChanges();
                            UserImageUrl.SaveAs(path);
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        db.SC_User.Add(sC_User);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(sC_User);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SC_User sC_User = db.SC_User.Find(id);
            if (sC_User == null)
            {
                return HttpNotFound();
            }
            return View(sC_User);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SC_User sC_User = db.SC_User.Find(id);
            db.SC_User.Remove(sC_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
