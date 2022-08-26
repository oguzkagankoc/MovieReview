#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class GenresController : Controller
    {
        // Add service injections here
        private readonly GenreServiceBase _genreService;

        public GenresController(GenreServiceBase genreService)
        {
            _genreService = genreService;
        }

        // GET: Genres
        public IActionResult Index()
        {
            List<Genre> genreList = _genreService.GetList();
            ViewBag.Message = genreList.Count == 0 ? "No records found!" : genreList.Count == 1 ? "1 record found." : genreList.Count + " records found.";
            return View(genreList);
        }

        // GET: Genres/Details/5
        public IActionResult Details(int id)
        {
            Genre genre = _genreService.GetItem(id);
            if (genre == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var result = _genreService.Add(genre);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(genre);
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(int id)
        {
            Genre genre = _genreService.GetItem(id);
            if (genre == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            }
            return View(genre);
        }

        // POST: Genres/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                var result = _genreService.Update(genre);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(genre);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(int id)
        {
            Genre genre = _genreService.GetItem(id);
            if (genre == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(genre);
        }

        // POST: Genres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _genreService.Delete(g => g.Id == id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
	}
}
