using AHFS.Models;
using AHFS.Services;
using AHFS.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Diagnostics;
using System.Dynamic;


namespace AHFS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IGradeService _gradeService;
        private readonly ISubjectService _subjectService;
        private readonly IDocumentService _documentService;


        public HomeController(IStudentService setService, IUserService userService, ITeacherService teacherService, IGradeService gradeService, ISubjectService subjectService, IDocumentService documentService)
        {
            _studentService = setService;
            _userService = userService;
            _teacherService = teacherService;
            _gradeService = gradeService;
            _subjectService = subjectService;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Profile(string id)
        {
            var student = _studentService.GetStudentByUserId(id);//check student exists
            if (student != null)
            {
                return View(student);
            }
            var teacher = _teacherService.GetTeacherByUserId(id);//check teacher exists
            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                return View(teacher);
            }
        }

        public IActionResult ProfileStudentEdit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return View(id);
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileStudentEdit(int id, [Bind("StudentId,Name,Email,PhoneNr,Class,Group,Subgroup,Scholarship,FinalGrade,Faculty,Sex,CNP,Age,YearOfStudy,Semester,UserId")] Student student)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", student.UserId);
            return View(student);
        }

        public IActionResult ProfileTeacherEdit(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return View(id);
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileTeacherEdit(int id, [Bind("TeacherId,Name,Email,Sex,CNP,Age,PhoneNr,Role,Faculty,UserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _teacherService.UpdateTeacher(teacher);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id", teacher.UserId);
            return View(teacher);

        }


        public IActionResult Grades(string id)
        {
            var student = _studentService.GetStudentByUserId(id);//check student exists
            if (student == null)
            {
                return NotFound();
            }
            dynamic mymodel = new ExpandoObject();
            mymodel.Grades = _gradeService.GetGradesByStudentId(student.StudentId);
            mymodel.Subjects = _subjectService.GetSubjectsByStudentInfo(student.Faculty, student.YearOfStudy ?? 0);
            return View(mymodel);
        }

        public IActionResult GradesSubmit(string id)
        {
            var teacher = _teacherService.GetTeacherByUserId(id);//check teacher exists
            if (teacher == null)
            {
                return NotFound();
            }

            dynamic mymodel = new ExpandoObject();
            mymodel.Grades = _gradeService.GetGrades();
            mymodel.Subjects = _subjectService.GetSubjectsByTeacherId(teacher.TeacherId);
            mymodel.Students = _studentService.GetStudents();
            return View(mymodel);
        }

        public IActionResult Edit(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetStudents(), "StudentId", "StudentId", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GradeId,SubjectId,GradeValue,StudentId")] Grade grade)
        {
            if (id != grade.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gradeService.UpdateGrade(grade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_studentService.GetStudents(), "StudentId", "StudentId", grade.StudentId);
            ViewData["SubjectId"] = new SelectList(_subjectService.GetSubjects(), "SubjectId", "SubjectId", grade.SubjectId);
            return View(grade);
        }

        public IActionResult SubjectList(string id)
        {
            var teacher = _teacherService.GetTeacherByUserId(id);//check teacher exists
            if (teacher == null)
            {
                return NotFound();
            }
            var subjects = _subjectService.GetSubjectsByTeacherId(teacher.TeacherId);

            if (subjects == null)
            {
                return NotFound();
            }

            return View(subjects);
        }

        public IActionResult StudentList()
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        public IActionResult Timetables()
        {
            return View();
        }

        public IActionResult Certificates()
        {
            return View();
        }

        public IActionResult Documents(string id)
        {
            var document = _documentService.GetDocumentsByUserId(id);
            return View(document);
        }

    }
}
