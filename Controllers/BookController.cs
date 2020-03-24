using System.Web.Mvc;
using LibraryManagement.Entity;
using LibraryManagement.BL;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
   // [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        Book book = new Book();
        BookBL bookBL = new BookBL();

        public ActionResult Create()
        {
            List<Category> categorys = bookBL.BindCategory();
            ViewBag.categories = new SelectList(categorys, "CategoryId", "CategoryName");
            return View();
        }
        public ActionResult Edit(int id)
        {
            book = bookBL.GetBook(id);
            List<Category> categorys = bookBL.BindCategory();
            ViewBag.categories = new SelectList(categorys, "CategoryId", "CategoryName");
            return View(book);
        }
        public ActionResult BookDetails()
        {
            List<Book> books = bookBL.BookDetails();
            return View(books);
        }
        public ActionResult Delete(int id)
        {
            bookBL.DeleteBook(id);
            return RedirectToAction("BookDetails");
        }

        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                book.BookId = bookViewModel.BookId;
                book.Author = bookViewModel.Author;
                book.Name = bookViewModel.Name;
                book.Subject = bookViewModel.Subject;
                bookBL.AddMethod(book);
                TempData["Message"] = "Book Added Successfully!";
                List<Category> categories = bookBL.BindCategory();
                ViewBag.categories = new SelectList(categories, "CategoryId", "CategoryName");
                return RedirectToAction("BookDetails");
            }
            //else
            //{
            //    ModelState.AddModelError("", "Some error occured");
            //}
            return View();
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            if (book != null)
            {
                book.Author = bookViewModel.Author;
                book.BookId = bookViewModel.BookId;
                book.Name = bookViewModel.Name;
                book.Subject = bookViewModel.Subject;
                bookBL.Update(book);
                List<Category> categorys = bookBL.BindCategory();
                ViewBag.categories = new SelectList(categorys, "CategoryId", "CategoryName");
                return RedirectToAction("BookDetails");
            }
            return View();
        }
    }
}
