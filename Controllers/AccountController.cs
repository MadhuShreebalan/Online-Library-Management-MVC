using System.Web.Mvc;
using LibraryManagement.BL;
using LibraryManagement.Entity;
using AutoMapper;
using System.Web;
using System.Web.Security;
using System;

namespace LibraryManagement.Models
{
    public class AccountController : Controller
    {
        IAccountBL accountBL;
        public AccountController()
        {
            accountBL = new AccountBL();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var config = new MapperConfiguration(mapping =>
            {
                mapping.CreateMap<LoginViewModel, Account>();
            });
            IMapper mapper = config.CreateMapper();
            var account = mapper.Map<LoginViewModel, Account>(loginViewModel);
            var accountDetails = accountBL.Login(account);
            
            if (accountDetails != null)
            {// for admin
                FormsAuthentication.SetAuthCookie(account.EmailId, false);
                var authTicket = new FormsAuthenticationTicket(1, account.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, accountDetails.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("CategoryDetails", "Category");
            }
            else
            {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(account);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Signup(SignupViewModel signupViewModel)
        {
            try {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(mapping =>
                    {
                        mapping.CreateMap<SignupViewModel, Account>();
                    });
                    IMapper mapper = config.CreateMapper();
                    Account account= mapper.Map<SignupViewModel, Account>(signupViewModel);
                    account.Role = "User";
                    accountBL.AddMethod(account);
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                View("Error");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Home()
        {
            return View();
        }

        //public ActionResult UserDetails()
        //{
        //    IEnumerable<Account> list = accountBl.DisplayUsers();
        //    return View(list);
        //}
        //[HttpGet]
        //public ActionResult EditUser(string emailId) //Edit                             
        //{
        //    Account account = accountBl.GetId(emailId);
        //    return View(account);
        //}
        //[HttpPost]
        //public ActionResult EditUser(LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Account user = new Account();
        //        user.EmailId = loginViewModel.EmailId;
        //        accountBl.Update(user);
        //        ViewBag.Message = "User details updated successfully";
        //        ModelState.Clear();
        //        return RedirectToAction("UserDetails");
        //    }
        //    return View();
        //}
        //[HandleError]
        //public ActionResult DeleteUser(string emailId) //Delete
        //{
        //    accountBl.Delete(emailId);
        //    return RedirectToAction("UserDetails");

        //}

    }
}