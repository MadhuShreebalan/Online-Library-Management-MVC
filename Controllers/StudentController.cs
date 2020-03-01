using System.Web.Mvc;
using LibraryManagement.Repository;
namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return RedirectToAction("Signup");
        }
         
        public ActionResult Search()
        {
            return RedirectToAction("Search");
        }
    }
}