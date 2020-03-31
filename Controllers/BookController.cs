using System.Web.Mvc;
using LibraryManagement.Entity;
using LibraryManagement.BL;
using System.Collections.Generic;
using AutoMapper;

namespace LibraryManagement.Models
{
   // [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        Book book = new Book();
        BookBL bookBL = new BookBL();

        public ActionResult Create()
        {
            var categorys = bookBL.BindCategory();
            ViewBag.Mycategory = new SelectList(categorys, "CategoryId", "CategoryName");
            return View();
        }

        public ActionResult Edit(int id)
        {
            book = bookBL.GetBook(id);
            var Categorys = bookBL.BindCategory();
            ViewBag.Mycategory = new SelectList(Categorys, "CategoryId", "CategoryName");
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
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<BookViewModel, Book>();
                });
                IMapper mapper = config.CreateMapper();
                var book = mapper.Map<BookViewModel, Book>(bookViewModel);
                var Categorys = bookBL.BindCategory();
                ViewBag.Mycategory = new SelectList(Categorys, "CategoryId", "CategoryName");
                bookBL.AddMethod(book);
                    
                return RedirectToAction("BookDetails");
            }
            else
            {
                ModelState.AddModelError("", "Some error occured");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            if (book != null)
            {
                var config = new MapperConfiguration(mapping =>
                {
                    mapping.CreateMap<BookViewModel, Book>();
                });
                IMapper mapper = config.CreateMapper();
                var book = mapper.Map<BookViewModel, Book>(bookViewModel);
                var Categorys = bookBL.BindCategory();
                ViewBag.Mycategory = new SelectList(Categorys, "CategoryId", "CategoryName");
                bookBL.Update(book);
                
                return RedirectToAction("BookDetails");
            }
            return View();
        }
    }
}
