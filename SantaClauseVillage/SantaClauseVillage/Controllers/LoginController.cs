using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaClauseVillage.Classes;
using SantaClauseVillageMongoDB = SantaClauseVillage.Classes.MongoDB;
using System.Diagnostics;

namespace SantaClauseVillage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            Debug.WriteLine("login()");
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            SantaClauseVillageMongoDB db = new SantaClauseVillageMongoDB();
            var userAuthentication= db.GetUserByEmail(user.Email);
            if (userAuthentication != null && userAuthentication.Password==Sha512.GetSHA512(user.PasswordClearText))
            {
                Session["Email"] = userAuthentication.Email.ToString();
                Session["ID"] = userAuthentication.ID.ToString();
                Session["ScreenName"] = userAuthentication.Screenname.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password Error");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["ID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}