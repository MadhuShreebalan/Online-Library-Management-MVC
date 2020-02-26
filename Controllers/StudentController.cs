
using System.Collections.Generic;
using System.Web.Mvc;
using LibraryManagement.Repository;
using LibraryManagement.Entity;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        BookRepository bookRepository;
        public StudentController()
        {
            bookRepository = new BookRepository();
        }
        // GET: Index
        public ActionResult Index()
        {
            IEnumerable<Books> books = bookRepository.GetAllBooks();
            return View(books);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Books books)
        {
            bookRepository.AddBook(books);
            TempData["Message"] = "Book Added Successfully!";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
            TempData["Message"] = "Book Deleted Successfully!";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Books books = bookRepository.GetBook(id);
            return View(books);
        }
        [HttpPost]
        public ActionResult Update(Books books)
        {
            bookRepository.UpdateBook(books);
            TempData["Message"] = "Employee Details Updated Successfully";
            return RedirectToAction("Index");
        }
    }
}