using System.ComponentModel;
using System.IO;
using log4net;
using log4netdemo.data.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;

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

            var items = new List<User>();
            try
            {
                using (var db = new CoreContext())
                {
                    items = db.Users.ToList();
                }
                Console.WriteLine("Datos recuperados desde BD Azure");
                Console.WriteLine(JsonConvert.SerializeObject(items));
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                items.Clear();
                items.Add(new User()
                {
                    IdUser= -1, Names = ex.Message.ToString(),
                });
            }

            return View(items);
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

        public IActionResult RedirectToHome()
        {
            var ReturnUrl = "https://google.com";
            //Response.Redirect(ReturnUrl);
            //return RedirectPermanent(ReturnUrl);
            return Redirect(ReturnUrl);
        }

        // POST: HomeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                await Task.Delay(1200);
                Console.WriteLine("yengo a google ");
                return RedirectToHome();
                //return RedirectToAction(nameof(Index));
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
