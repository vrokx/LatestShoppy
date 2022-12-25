using RepoPractice.Models.DAL.Product;
using RepoPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RepoPractice.App_Start
{
    public class LoginController : Controller
    {
        private IRepository<UserModel> userObj;

        ShoppingCartDBContext db = new ShoppingCartDBContext();

        public LoginController()
        {
            this.userObj = new GenericRepository<UserModel>();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            userObj.Add(user);
            userObj.Save();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password , UserModel user)
        {
            
            var credentials = db.UserSet.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if (credentials != null) 
            {
                List<UserModel> users = userObj.GetAll().ToList();
                var userid = (from id in users where id.Email == email select id.UserId).ToList();
                Session["UserId"] = userid[0];
                Session["userEmail"] = email;
                Session["userPassword"] = password;

                var uid = (int)Session["UserId"];

                if (email == "admin@admin.com" && password == "admin@123")
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return RedirectToAction("DisplayAllProducts", "Seller");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(email, false);
                    return RedirectToAction("BuyerDisplayAllProduct", "Buyer" , new {});
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}