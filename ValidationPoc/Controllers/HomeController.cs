using System.Threading.Tasks;
using System.Web.Mvc;
using ValidationPoc.Command;
using ValidationPoc.Dto;
using ValidationPoc.Query;
using ValidationPoc.Services;

namespace ValidationPoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommandHandlerDisptcher commandHandlerDisptcher;
        private readonly IQueryHandlerDispatcher queryHandlerDispatcher;

        public HomeController(ICommandHandlerDisptcher commandHandlerDisptcher,
            IQueryHandlerDispatcher queryHandlerDispatcher)
        {
            this.commandHandlerDisptcher = commandHandlerDisptcher;
            this.queryHandlerDispatcher = queryHandlerDispatcher;
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Index(Questionnaire questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return View(questionnaire);
            }

            var result = await commandHandlerDisptcher.HandleAsync<CreateAnswersCommand, Questionnaire>(new CreateAnswersCommand {Questionnaire = questionnaire});

            TempData["Message"] = "Thanks for completing the questionnaire";
            return RedirectToAction("Index", "Home");
        }

        [Route("edit/{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            var questionnaire = await queryHandlerDispatcher.HandleAsync<GetQuestionnaireQuery, Questionnaire>(new GetQuestionnaireQuery
            {
                Id = id
            });

            return View(questionnaire);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public async Task<ActionResult> Edit(int id, Questionnaire questionnaire)
        {
            await commandHandlerDisptcher.HandleAsync<UpdateAnswersCommand, Questionnaire>(new UpdateAnswersCommand { Id = id, Questionnaire = questionnaire });

            TempData["Message"] = "The questionnaire answers have successfully been updated.";
            return RedirectToAction("Edit", "Home", new { id });
        }

        [Route("list")]
        public ActionResult List(int? page, int? pageSize)
        {
            return View();
        }

        [Route("jsonlist")]
        public async Task<JsonResult> JsonList(int? page, int? pageSize)
        {
            var questionnaireSummaryCollection = await queryHandlerDispatcher.HandleAsync<GetQuestionnaireSummaryPageQuery, QuestionnaireSummaryCollection>(
                new GetQuestionnaireSummaryPageQuery
                {
                    Page = page ?? 1,
                    PageSize = pageSize ?? 10
                });

            return Json(questionnaireSummaryCollection, JsonRequestBehavior.AllowGet);
        }
    }
}