using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MotivationMinders.Controllers
{
    public class UserController : Controller
    {
        private mainDBEntities db = new mainDBEntities();

        //
        // GET: /USer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.UserModel User)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(User.Email, User.Password))
                {
                    FormsAuthentication.SetAuthCookie(User.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }
            return View(User);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.UserModel User)
        {
            if (ModelState.IsValid)
            {
                using (var db = new mainDBEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(User.Password);

                    var sysUser = db.SystemUsers.Create();

                    sysUser.Email = User.Email;
                    sysUser.Password = encrpPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.UserID = Guid.NewGuid();

                    db.SystemUsers.Add(sysUser);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(User);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string UserName)
        {
            //check user existance
            var user = UserName;
            if (user == null)
            {
                TempData["Message"] = "Email does not exist in database.";
            }
            else
            {
                //generate password token
                var token = "as4da2sd1a";
                //create url with above token
                var resetLink = "<a href='" + Url.Action("ResetPassword", "Account", new { un = UserName, rt = token }, "http") + "'>Reset Password</a>";
                //get user emailid
                var db = new mainDBEntities();
                var emailid = (from i in db.SystemUsers
                               where i.Email == UserName
                               select i.Email).FirstOrDefault();
                //send mail
                string subject = "Password request";
                string body = "<b>Please click the link to reset your password</b><br/>" + resetLink; //edit it
                try
                {
                    SendEMail(emailid, subject, body);
                    TempData["Message"] = "Mail Sent.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Error occured while sending email." + ex.Message;
                }
                //only for testing
                TempData["Message"] = resetLink;
            }

            return View();
        }

        public ActionResult EditUser()
        {
            RedirectToAction("Index", "AdminController");
            return View();
        }

        private void SendEMail(string emailid, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("xxxxx@gmail.com", "xxxxx");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("MotivationMindersAdministration@gmail.com");
            msg.To.Add(new MailAddress(emailid));

            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            client.Send(msg);
        }



        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            //using (var db = new MainDbEntities1())
            //{
            //    var user = db.SystemUsers.FirstOrDefault(u => u.Email == email);

            //    if (user != null)
            //    {
            //        if (user.Password == crypto.Compute(password, user.PasswordSalt))
            //        {
            //            isValid = true;
            //        }
            //    }

            //}
            return isValid;
        }
    }
}
