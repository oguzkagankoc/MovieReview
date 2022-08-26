#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class DirectorsController : Controller
    {
        // Add service injections here
        private readonly DirectorServiceBase _directorService;

        public DirectorsController(DirectorServiceBase directorService)
        {
            _directorService = directorService;
        }

        // GET: Directors
        public IActionResult Index()
        {
            List<Director> directorList = _directorService.GetList();
            ViewBag.Message = directorList.Count == 0 ? "No records found!" : directorList.Count == 1 ? "1 record found." : directorList.Count + " records found.";
            return View(directorList);
        }

        // GET: Directors/Details/5
        public IActionResult Details(int id)
        {
            Director director = _directorService.GetItem(id);
            if (director == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                var result = _directorService.Add(director);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(director);
        }

        // GET: Directors/Edit/5
        public IActionResult Edit(int id)
        {
            Director director = _directorService.GetItem(id);
            if (director == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            }
            return View(director);
        }

        // POST: Directors/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Director director)
        {
            if (ModelState.IsValid)
            {
                var result = _directorService.Update(director);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(director);
        }

        // GET: Directors/Delete/5
        public IActionResult Delete(int id)
        {
            Director director = _directorService.GetItem(id);
            if (director == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(director);
        }

        // POST: Directors/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _directorService.Delete(d=>d.Id == id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
	}
}
