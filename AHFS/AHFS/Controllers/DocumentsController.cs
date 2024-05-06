using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHFS.Models;
using AHFS.Services.Interfaces;

namespace AHFS.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDocumentService _documentService;

        public DocumentsController(IUserService userService, IDocumentService documentService)
        {
            _userService = userService;
            _documentService = documentService;
        }

        // GET: Documents
        public IActionResult Index()
        {
            
            return View( _documentService.GetDocuments());
        }

        // GET: Documents/Details/5
        public IActionResult Details(int id)
        {

            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("DocumentId,Link,UserId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _documentService.CreateDocument(document);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(document);
        }

        // GET: Documents/Edit/5
        public IActionResult Edit(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("DocumentId,Link,UserId")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _documentService.UpdateDocument(document);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetUsers(), "Id", "Id");
            return View(document);
        }

        // GET: Documents/Delete/5
        public IActionResult Delete(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document != null)
            {
                _documentService.DeleteDocument(document);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
            {
                return false;
            }
            return true;
        }
    }
}
