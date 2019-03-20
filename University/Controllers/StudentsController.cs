using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var students = universityContext.Students.Include(s => s.Department);
            //IList<Student>students = universityContext.Students.Include(d => d.Department).ToList();

            return View(await students.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(universityContext.Departments, "DepartmentId", "DepartmentId");
            return View();
        }
       /* [HttpPost]
        public IActionResult Create(Student model)
        {
            if (!ModelState.IsValid)
            {
                universityContext.Add(model);
                universityContext.SaveChanges();
                return RedirectToAction("index");
            }
            ViewData["DepartmentId"] = new SelectList(universityContext.Departments, "Id", "Id", st);


                return View(model);
  
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,GPA,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                universityContext.Add(student);
                await universityContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(universityContext.Departments, "DepartmentId", "DepartmentId", student.DepartmentId);
            return View(student);
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
            Student sampleStudent = universityContext.Students.Where(b => b.Id == id).Include(d => d.Department).FirstOrDefault();

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
