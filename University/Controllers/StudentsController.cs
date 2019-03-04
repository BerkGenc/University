using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        UniversityContext universityContext;

        public StudentsController(UniversityContext context)
        {
            universityContext = context;

        }

        public IActionResult Index()
        {
            var students = universityContext.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Student model)
        {
            if (!ModelState.IsValid) return View(model);
            universityContext.Add(model);
            universityContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = universityContext.Students.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (!ModelState.IsValid) return View(model);
            universityContext.Students.Update(model);
            universityContext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = universityContext.Students.Find(id);
            universityContext.Students.Remove(emp);
            universityContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student sampleStudent = universityContext.Students.Where(b => b.Id == id).FirstOrDefault();
            if (sampleStudent != null)
            {
                return View(sampleStudent);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
