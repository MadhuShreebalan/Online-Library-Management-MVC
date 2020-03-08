using System.Web.Mvc;
using LibraryManagement.BL;
using LibraryManagement.Entity;

namespace LibraryManagement.Models
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login_View)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.EmailId = login_View.EmailId;
                account.Password = login_View.Password;
                return RedirectToAction("Signup");
            }
            return View();
        }
        [HttpPost]
        [ActionName("Signup")]
        public ActionResult Signup(SignupViewModel signupViewModel)
        {
            if (ModelState.IsValid)
            {
                    AccountBl accountBl = new AccountBl();
                    Account account = new Account();
                    account.AccountId = signupViewModel.AccountId;
                    account.Department = signupViewModel.Department;
                    account.EmailId = signupViewModel.EmailId;
                    account.Password = signupViewModel.Password;
                    account.Phone = signupViewModel.Phone;
                    accountBl.AddMethod(account);
                    TempData["Message"] = "User signup details successfull";
                    return RedirectToAction("Login");

            }
            else
            {
                ModelState.AddModelError("", "Some error occured");
            }
            return View();
            //if (ModelState.IsValid)
            //{
            //    Account account = new Account();
            //    account.EmailId = signup.EmailId;
            //    account.Password = signup.Password;
            //    account.Department = signup.Department;
            //    account.Phone = signup.Phone;
            //    return RedirectToAction("Signup");
            //}
            //return View();
        }
    }
}