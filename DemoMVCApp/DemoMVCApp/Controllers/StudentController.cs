using DemoMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVCApp.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> StudentList = new List<Student>()
        {
            new Student() { Id = 29, Name = "Shihab", Section = "A" },
            new Student() { Id = 27, Name = "Shibli", Section = "A" },
            new Student() { Id = 59, Name = "Abir", Section = "B" }
        };
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentList);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Name, Section")] Student student)
        {
            StudentList.Add(new Student() { Id = student.Id, Name = student.Name, Section = student.Section });
            //return $"Name: {student.Name}; Id: {student.Id}; Section: {student.Section}";
            return View("Index", StudentList);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var student = StudentList.Where(m => m.Id == id).FirstOrDefault();

            return View("Edit", student);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var student = StudentList.Where(m => m.Id == id).FirstOrDefault();
            StudentList.Remove(student);

            return View("Index", StudentList);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, Section")] Student student)
        {
            var seletedStudent = StudentList.Where(m => m.Id == student.Id).FirstOrDefault();

            seletedStudent.Name = student.Name;
            seletedStudent.Section = student.Section;

            return View("Index", StudentList);
        }

        public ActionResult Test()
        {
            return Content("Hello world");
        }
    }
}