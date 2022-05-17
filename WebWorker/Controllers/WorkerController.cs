using Microsoft.AspNetCore.Mvc;

namespace WebWorker.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        [Route("Demo/{id}")]
        public IActionResult Demo(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
