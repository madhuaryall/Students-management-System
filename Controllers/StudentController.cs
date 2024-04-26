using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{


    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicatonDbContext _context;

        public StudentController(ApplicatonDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            Student student = new Student();
            var students = new Student();

            return View(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Add(student);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var studentInfo = _context.Students.FirstOrDefault(x => x.Id == id);

            return View(studentInfo);
        }



        [HttpPost]
    public IActionResult Edit(Student student)
    {
        var studentInfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);
        if (studentInfo != null)
        {
            studentInfo.FullName = student.FullName;
            studentInfo.Class = student.Class;
            studentInfo.Title = student.Title;
            studentInfo.Email = student.Email;
                _context.Update(studentInfo);

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }


        [HttpGet]
        public IActionResult AddEdit(int id)
        {
            Student student = new Student();

            if (id > 0)
            {
                student = _context.Students.FirstOrDefault(x => x.Id == id);
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult AddEdit(Student student)
        {
            if (student.Id == 0)
            {
                _context.Add(student);
                _context.SaveChanges();

            }
            else
            {

                var studentinfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);

                studentinfo.FullName = student.FullName;
                studentinfo.Class = student.Class;
                studentinfo.Title = student.Title;
                studentinfo.Email = student.Email;

                _context.Update(studentinfo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Remove(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Remove(studentinfo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(studentinfo);
        }
    }
}

