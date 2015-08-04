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
            TryValidateModel(questionnaire);
            return View(questionnaire);
        }
    }
}