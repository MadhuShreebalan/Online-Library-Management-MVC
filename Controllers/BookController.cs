using LibraryManagement.DAL;
using System.Web.Mvc;
using LibraryManagement.Entity;
using LibraryManagement.BL;
using System.Linq;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class BookController : Controller
    {
        BookRepository bookRepository = new BookRepository();
        public ActionResult Create()
        {
            LibraryManagementContext db = new LibraryManagementContext();
            List<Category> categories = db.Categorys.ToList();
            ViewBag.categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult BookDetails()
        {
            BookBL bookBL = new BookBL();
            bookBL.BookDetails();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                BookBL bookBL = new BookBL();
                Book book = new Book();
                book.BookId = bookViewModel.BookId;
                book.Author = bookViewModel.Author;
                book.Name = bookViewModel.Name;
                book.Subject = bookViewModel.Subject;
                bookBL.AddMethod(book);
                TempData["Message"] = "Book Added Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some error occured");
            }
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                List<Category> categories = db.Categorys.ToList();
                ViewBag.categories = new SelectList(categories, "CategoryId", "CategoryName");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteBook(int bookId)
        {
            BookBL bookBL = new BookBL();
            Book book = new Book();
            bookBL.DeleteBook(bookId);
            TempData["Message"] = "Book Deleted Successfully!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int bookId)
        {
            BookBL bookBL = new BookBL();
            Book book = new Book();
            bookBL.Edit(bookId);
            return RedirectToAction("BookDetails");
        }
        
        //public ActionResult UpdateBook(int bookId)
        //{
        //    BookBL bookBL = new BookBL();
        //    Book book = new Book();
        //    bookBL.UpdateBook(bookId);
        //    TempData["Message"] = "Book Details Updated Successfully";
        //    return RedirectToAction("BookDetails");
        //}
    }
}