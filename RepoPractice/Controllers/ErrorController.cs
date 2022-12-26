using System.Web.Mvc;

namespace RepoPractice.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }
    }
}