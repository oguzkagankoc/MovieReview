#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Services;

namespace MvcWebUI.Controllers
{
    public class UsersController : Controller
    {
        // Add service injections here
        private readonly UserServiceBase _userService;

        public UsersController(UserServiceBase userService)
        {
            _userService = userService;
        }

        // GET: Users
        public IActionResult Index()
        {
            List<User> userList = _userService.GetList();
            ViewBag.Message = userList.Count == 0 ? "No records found!" : userList.Count == 1 ? "1 record found." : userList.Count + " records found.";
            return View(userList);
        }

        // GET: Users/Details/5
        public IActionResult Details(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "RoleName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Add(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            else
            {
                // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
                ViewData["RoleId"] = new SelectList(null, "Id", "RoleName", user.RoleId);
            }
            return View(user);
        }

        // POST: Users/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Update(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                    return RedirectToAction(nameof(Index));
                }
                //ViewBag.Message = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(null, "Id", "RoleName", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            User user = _userService.GetItem(id);
            if (user == null)
            {
                //return NotFound();
                ViewBag.Message = "Record not found!";
            }
            return View(user);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _userService.Delete(u=>u.Id==id);
            TempData["Message"] = result.Message; // End message in service with '.' for success, '!' for danger Bootstrap CSS classes to be used in the View
            return RedirectToAction(nameof(Index));
        }
	}
}
