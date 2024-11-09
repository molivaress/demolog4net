using log4net;
using Microsoft.AspNetCore.Mvc;

namespace log4netdemo.Controllers
{
    public class HomeController : Controller
    {
        ILog logger = LogManager.GetLogger("debug");
        // GET: HomeController
        public ActionResult Index()
        {
            logger.Info("info ingresa al index :: test for blob storage updasted");
            logger.Debug("debug demo4net :: test for blob storage updasted");
            logger.Warn("warn demo4net :: test for blob storage updasted");
            logger.Error("error demo4net :: test for blob storage updasted");

            return View();
        }
        public IActionResult Privacy()
        {
            logger.Warn("Warn! Privacy zone! :: Aplication log4netdemo");

            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
