using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHFS.Models;
using AHFS.Services.Interfaces;

namespace AHFS.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;

        public TeachersController(IUserService userService, ITeacherService teacherService)
        {
            _userService = userService;
            _teacherService = teacherService;
        }

        // GET: Teachers
        public IActionResult Index()
        {

            return View(_teacherService.GetTeachers());
        }

        // GET: Teachers/Details/5
        public IActionResult Details(int id)
        {

            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TeacherId,Link,UserId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.CreateTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public IActionResult Edit(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TeacherId,Link,UserId")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

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
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public IActionResult Delete(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher != null)
            {
                _teacherService.DeleteTeacher(teacher);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
            {
                return false;
            }
            return true;
        }
    }
}
