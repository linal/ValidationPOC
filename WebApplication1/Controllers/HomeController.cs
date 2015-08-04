using System.Web.Mvc;
using ValidationPoc.Models;

namespace ValidationPoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Questionnaire questionnaire)
        {
            if (!TryValidateModel(questionnaire))
            {
                return View(questionnaire);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}