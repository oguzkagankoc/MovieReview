#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class CommentsController : Controller
    {
        // Add service injections here
        private readonly CommentServiceBase _commentService;

        public CommentsController(CommentServiceBase commentService)
        {
            _commentService = commentService;
        }

        // GET: Comments
        public IActionResult Index()
        {
            List<Comment> commentList = _commentService.GetList();
            ViewBag.Message = commentList.Count == 0 ? "No records found!" : commentList.Count == 1 ? "1 record found." : commentList.Count + " records found.";
            return View(commentList);
        }

        // GET: Comments/Details/5
        public IActionResult Details(int id)
        {
            Comment comment = _commentService.GetItem(id);
            if (comment == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["MovieId"] = new SelectList(null, "Id", "Title");
            ViewData["UserId"] = new SelectList(null, "Id", "Password");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var result = _commentService.Add(comment);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["MovieId"] = new SelectList(null, "Id", "Title", comment.MovieId);
            ViewData["UserId"] = new SelectList(null, "Id", "Password", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public IActionResult Edit(int id)
        {
            Comment comment = _commentService.GetItem(id);
            if (comment == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
                ViewData["MovieId"] = new SelectList(null, "Id", "Title", comment.MovieId);
                ViewData["UserId"] = new SelectList(null, "Id", "Password", comment.UserId);
            }
            return View(comment);
        }

        // POST: Comments/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var result = _commentService.Update(comment);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["MovieId"] = new SelectList(null, "Id", "Title", comment.MovieId);
            ViewData["UserId"] = new SelectList(null, "Id", "Password", comment.UserId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public IActionResult Delete(int id)
        {
            Comment comment = _commentService.GetItem(id);
            if (comment == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(comment);
        }

        // POST: Comments/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _commentService.Delete(c => c.Id == id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
	}
}
