﻿using System.Threading.Tasks;
using System.Web.Http;
using ValidationPoc.Command;
using ValidationPoc.Dto;
using ValidationPoc.Query;
using ValidationPoc.Services;

namespace ValidationPoc.Controllers
{
    public class QuestionnaireController : ApiController
    {
        private readonly IQueryHandlerDispatcher queryHandlerDispatcher;
        private readonly ICommandHandlerDisptcher commandHandlerDisptcher;

        public QuestionnaireController(IQueryHandlerDispatcher queryHandlerDispatcher,
            ICommandHandlerDisptcher commandHandlerDisptcher)
        {
            this.queryHandlerDispatcher = queryHandlerDispatcher;
            this.commandHandlerDisptcher = commandHandlerDisptcher;
        }

        [HttpGet]
        [Route("api/questionnaires/list")]
        public async Task<QuestionnaireSummaryCollection> List(int page = 1, int pageSize = 10)
        {
            return await queryHandlerDispatcher.HandleAsync<GetQuestionnaireSummaryPageQuery, QuestionnaireSummaryCollection>(
                new GetQuestionnaireSummaryPageQuery
                {
                    Page = page,
                    PageSize = pageSize
                });
        }

        [HttpDelete]
        [Route("api/questionnaires/{id:int}")]
        public async Task<int> Remove(int id)
        {
            var returnId = await commandHandlerDisptcher.HandleAsync<RemoveAnswersCommand, int>(new RemoveAnswersCommand
            {
                Id = id
            });

            return returnId;
        }
    }
}