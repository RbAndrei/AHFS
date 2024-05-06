using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHFS.Data;
using AHFS.Models;
using AHFS.Services.Interfaces;

namespace AHFS.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ISubjectService _subjectService;

        public SubjectsController(ITeacherService teacherService, ISubjectService subjectService)
        {
            _teacherService = teacherService;
            _subjectService = subjectService;
        }

        // GET: Subjects
        public IActionResult Index()
        {
            return View(_subjectService.GetSubjects());
        }

        // GET: Subjects/Details/5
        public IActionResult Details(int id)
        {

            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachers(), "TeacherId", "TeacherId");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SubjectId,Link,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectService.CreateSubject(subject);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachers(), "TeacherId", "TeacherId");
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public IActionResult Edit(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachers(), "TeacherId", "TeacherId");
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SubjectId,Link,TeacherId")] Subject subject)
        {
            if (id != subject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _subjectService.UpdateSubject(subject);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_teacherService.GetTeachers(), "TeacherId", "TeacherId");
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public IActionResult Delete(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject != null)
            {
                _subjectService.DeleteSubject(subject);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return false;
            }
            return true;
        }
    }
}
