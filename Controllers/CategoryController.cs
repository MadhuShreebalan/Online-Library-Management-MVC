using LibraryManagement.BL;
using LibraryManagement.Entity;
using LibraryManagement.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBL categoryBL = new CategoryBL();
        Category category = new Category();
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                category.CategoryId = categoryViewModel.CategoryId;
                category.CategoryName = categoryViewModel.CategoryName;
                category.CategoryDescription = categoryViewModel.CategoryDescription;
                categoryBL.AddCategory(category);
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
                List<Category> categories= categoryBL.CategoryDetails();
                return View(categories);
        }

        public ActionResult Detail(int id)
        {
                return View(category);
            
        }

        public ActionResult Delete(int id)
        {
                categoryBL.DeleteCategory(id);
                return RedirectToAction("CategoryDetails");
        }

        public ActionResult Edit(int id)
        {
            Category category = categoryBL.GetCategoryId(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
                    if (category != null)
                    {
                        category.CategoryId = categoryViewModel.CategoryId;
                        category.CategoryName = categoryViewModel.CategoryName;
                        category.CategoryDescription = categoryViewModel.CategoryDescription;
                        categoryBL.Update(category);
                        return RedirectToAction("CategoryDetails");
                    }
            return View();
        }

    }
}