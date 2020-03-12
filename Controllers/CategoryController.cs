using LibraryManagement.BL;
using LibraryManagement.Entity;
using LibraryManagement.DAL;
using LibraryManagement.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                CategoryBL categoryBL = new CategoryBL();
                Category category = new Category();
                category.CategoryId = categoryViewModel.CategoryId;
                category.CategoryName = categoryViewModel.CategoryName;
                category.CategoryDescription = categoryViewModel.CategoryDescription;
                categoryBL.AddCategory(category);
                TempData["Message"] = "Book Added Successfully!";
                return RedirectToAction("CategoryDetails");
            }
            else
            {
                ModelState.AddModelError("", "Some error occured");
            }
            return View();
        }


        public ActionResult CategoryDetails()
        {
            using (LibraryManagementContext libraryManagementContext = new LibraryManagementContext())
            {
                List<Category> data = libraryManagementContext.Categorys.ToList();
                return View(data);
            }

        }

        public ActionResult Detail(int id)
        {
            using (LibraryManagementContext libraryManagementContext = new LibraryManagementContext())
            {
                Category category = libraryManagementContext.Categorys.Find(id);
                return View(category);
            }
        }

        public ActionResult Delete(int id)
        {
            using (LibraryManagementContext libraryManagementContext = new LibraryManagementContext())
            {
                Category category = libraryManagementContext.Categorys.Find(id);
                CategoryBL categoryBL = new CategoryBL();
                categoryBL.DeleteCategory(id);
                TempData["Message"] = "Category deleted Successfully";
                return RedirectToAction("CategoryDetails");
            }

        }

        public ActionResult Edit(int id)
        {

            using (LibraryManagementContext libraryManagementContext = new LibraryManagementContext())
            {
                Category category = libraryManagementContext.Categorys.Find(id);
                return View(category);
            }

        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            Category category = new Category();

            using (LibraryManagementContext libraryManagementContext = new LibraryManagementContext())
            {
                category = libraryManagementContext.Categorys.Find(categoryViewModel.CategoryId);
                {
                    if (category != null)
                    {
                        category.CategoryName = categoryViewModel.CategoryName;
                        category.CategoryDescription = categoryViewModel.CategoryDescription;
                        libraryManagementContext.SaveChanges();
                        TempData["Message"] = "Category Details Updated Successfully";
                        return RedirectToAction("CategoryDetails");
                    }

                }
            }
            return View(category);
        }

    }
}