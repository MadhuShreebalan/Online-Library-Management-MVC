using LibraryManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        LibraryManagementContext db = new LibraryManagementContext();
        public ActionResult Index()
        {
            db.Categorys.ToList();
            //db.Books.ToList();
            return View();
        }
    }
} 