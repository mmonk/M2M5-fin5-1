using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M2M5_fin5_1.Models;

namespace M2M5_fin5_1.Controllers
{
    public class StudentsController : Controller
    {
        private CustomContext db = new CustomContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //Custom Start
        // GET: Students/One2Many/5
        public ActionResult One2Many(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        //Custom End

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FullName,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FullName,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// SAM 2016-03-20 added this thingy
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewStudentGrades() {
            // I want a StudentGrades model, but I need a student and their grades in order to do this.
            List<StudentGrades> studentGrades = new List<StudentGrades>();
            // Get all the students
            List<Student> students = db.Students.ToList();
            // Get all the assignments
            List<Assignment> assignments = db.Assignments.ToList();

            foreach(Student student in students){
                StudentGrades sg = new StudentGrades();
                sg.Student = student;
                sg.Grades = db.Grades.Where(g => g.StudentID == student.StudentID).ToList();
                studentGrades.Add(sg);
            }

            return View(new StudentGradesViewModel(assignments, studentGrades));
        }
        public class StudentGradesViewModel {
            public List<StudentGrades> StudentGrades { get; set; }
            public List<Assignment> Assignments { get; set; }
            public StudentGradesViewModel(List<Assignment> assignments, List<StudentGrades> studentGrades)
            {
                this.Assignments = assignments;
                this.StudentGrades = studentGrades;
            }
        }

        public class StudentGrades {
            public Student Student { get; set; }
            public List<Grade> Grades { get; set; }
        }
    }
}
