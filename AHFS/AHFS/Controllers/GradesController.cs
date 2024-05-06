using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHFS.Models;
using AHFS.Services.Interfaces;

namespace AHFS.Controllers
{
    public class GradesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGradeService _gradeService;
        private readonly ISubjectService _subjectService;

        public GradesController(IUserService userService, IGradeService gradeService, ISubjectService subjectService)
        {
            _userService = userService;
            _gradeService = gradeService;
            _subjectService = subjectService;
        }

        // GET: Grades
        public IActionResult Index()
        {

            return View(_gradeService.GetGrades());
        }

        // GET: Grades/Details/5
        public IActionResult Details(int id)
        {

            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_subjectService.GetSubjects(), "Id", "Id");
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GradeId,SubjectId,GradeValue,UserId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeService.CreateGrade(grade);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_subjectService.GetSubjects(), "Id", "Id");
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(grade);
        }

        // GET: Grades/Edit/5
        public IActionResult Edit(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_subjectService.GetSubjects(), "Id", "Id");
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeId,SubjectId,GradeValue,UserId")] Grade grade)
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
            ViewData["UserId"] = new SelectList(_subjectService.GetSubjects(), "Id", "Id");
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(grade);
        }

        // GET: Grades/Delete/5
        public IActionResult Delete(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade != null)
            {
                _gradeService.DeleteGrade(grade);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return false;
            }
            return true;
        }
    }
}
