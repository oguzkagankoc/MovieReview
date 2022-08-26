#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class MoviesController : Controller
    {
        // Add service injections here
        private readonly MovieServiceBase _movieService;

        public MoviesController(MovieServiceBase movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            List<Movie> movieList = _movieService.GetList();
            ViewBag.Message = movieList.Count == 0 ? "No records found!" : movieList.Count == 1 ? "1 record found." : movieList.Count + " records found.";
            return View(movieList);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            Movie movie = _movieService.GetItem(id);
            if (movie == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["DirectorId"] = new SelectList(null, "Id", "DirectorFirstName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var result = _movieService.Add(movie);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["DirectorId"] = new SelectList(null, "Id", "DirectorFirstName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            Movie movie = _movieService.GetItem(id);
            if (movie == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
                ViewData["DirectorId"] = new SelectList(null, "Id", "DirectorFirstName", movie.DirectorId);
            }
            return View(movie);
        }

        // POST: Movies/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var result = _movieService.Update(movie);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["DirectorId"] = new SelectList(null, "Id", "DirectorFirstName", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            Movie movie = _movieService.GetItem(id);
            if (movie == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(movie);
        }

        // POST: Movies/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _movieService.Delete(m=>m.Id == id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
	}
}
