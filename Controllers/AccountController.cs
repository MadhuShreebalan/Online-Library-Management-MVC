using System.Web.Mvc;
using LibraryManagement.Entity;
namespace LibraryManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //  [ActionName("Details")]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Signup");
            }
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Account account)
        {
            if (ModelState.IsValid)
                return View("SignUp");
            return View();
        }
    }
}