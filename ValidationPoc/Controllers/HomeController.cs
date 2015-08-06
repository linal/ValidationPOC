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
        private readonly ICommandHandlerWrapper commandHandlerWrapper;
        private readonly IQueryHandlerWrapper queryHandlerWrapper;

        public HomeController(ICommandHandlerWrapper commandHandlerWrapper,
            IQueryHandlerWrapper queryHandlerWrapper)
        {
            this.commandHandlerWrapper = commandHandlerWrapper;
            this.queryHandlerWrapper = queryHandlerWrapper;
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

            var result = await commandHandlerWrapper.HandleAsync<CreateAnswersCommand, Questionnaire>(new CreateAnswersCommand {Questionnaire = questionnaire});

            TempData["Message"] = "Thanks for completing the questionnaire";
            return RedirectToAction("Index", "Home");
        }

        [Route("{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            var questionnaire = await queryHandlerWrapper.HandleAsync<GetQuestionnaireQuery, Questionnaire>(new GetQuestionnaireQuery
            {
                Id = id
            });

            return View(questionnaire);
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<ActionResult> Edit(int id, Questionnaire questionnaire)
        {
            await commandHandlerWrapper.HandleAsync<UpdateAnswersCommand, Questionnaire>(new UpdateAnswersCommand { Id = id, Questionnaire = questionnaire });

            TempData["Message"] = "The questionnaire answers have successfully been updated.";
            return RedirectToAction("Edit", "Home", new { id });
        }
    }
}