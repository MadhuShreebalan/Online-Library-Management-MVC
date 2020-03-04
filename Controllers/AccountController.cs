using System.Web.Mvc;
using LibraryManagement.Entity;
namespace LibraryManagement.Models
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
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
        public ActionResult Signup(SignupViewModel signup)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.EmailId = signup.EmailId;
                account.Password = signup.Password;
                account.Department = signup.Department;
                account.Phone = signup.Phone;
                return RedirectToAction("Signup");
            }
            return View();
        }
    }
}