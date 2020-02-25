using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Repository;
using LibraryManagement.Entity;

namespace LibraryManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentRepository studentRepository;
        public StudentController()
        {
            studentRepository = new StudentRepository();
        }
        // GET: Index
        public ActionResult Index()
        {
            IEnumerable<Student> students = studentRepository.GetAllStudents();
            return View(students);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student students)
        {
            studentRepository.AddStudent(students);
            TempData["Message"] = "Employee Added Successfully!";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(double id)
        {
            studentRepository.DeleteStudent(id);
            TempData["Message"] = "Employee Deleted Successfully!";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(double id)
        {
            Student students = studentRepository.GetStudent(id);
            return View(students);
        }
        [HttpPost]
        public ActionResult Update(Student students)
        {
            studentRepository.UpdateStudent(students);
            TempData["Message"] = "Employee Details Updated Successfully";
            return RedirectToAction("Index");
        }
    }
}