using LibraryManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class LibraryController : Controller
    {
        LibraryManagementContext db = new LibraryManagementContext();
        public ActionResult Index()
        {
           db.Category.ToList();
            return View();
        }
    }
}