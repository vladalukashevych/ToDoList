using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApp.Controllers
{
    public class task : Controller
    {
        // GET: task
        public ActionResult Index()
        {
            return View();
        }

        // GET: task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
