using System.Web.Mvc;

namespace Csw.Library.Controllers
{
    public class ApiDemoController : Controller
    {
        public ActionResult Books()
        {
            return View();
        }

        public ActionResult BooksByAuthor()
        {
            return View();
        }

        public ActionResult BooksByCategory()
        {
            return View();
        }
    }
}
