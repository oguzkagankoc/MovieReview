#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class RolesController : Controller
    {
        // Add service injections here
        private readonly RoleServiceBase _roleService;

        public RolesController(RoleServiceBase roleService)
        {
            _roleService = roleService;
        }

        // GET: Roles
        public IActionResult Index()
        {
            List<Role> roleList = _roleService.GetList();
            ViewBag.Message = roleList.Count == 0 ? "No records found!" : roleList.Count == 1 ? "1 record found." : roleList.Count + " records found.";
            return View(roleList);
        }

        // GET: Roles/Details/5
        public IActionResult Details(int id)
        {
            Role role = _roleService.GetItem(id);
            if (role == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                var result = _roleService.Add(role);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(role);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            Role role = _roleService.GetItem(id);
            if (role == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            }
            return View(role);
        }

        // POST: Roles/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                var result = _roleService.Update(role);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            return View(role);
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            Role role = _roleService.GetItem(id);
            if (role == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(role);
        }

        // POST: Roles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _roleService.Delete(r => r.Id == id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
    }
}
