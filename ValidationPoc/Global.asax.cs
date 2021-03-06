﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using FluentValidation.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using ValidationPoc.Command.AutomapperProfiles;
using ValidationPoc.Command.Handlers;
using ValidationPoc.Query.AutomapperProfiles;
using ValidationPoc.Query.Handlers;
using ValidationPoc.Services;

namespace ValidationPoc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Container container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            SetupIoc();
            SetupAutomapper();

            FluentValidationModelValidatorProvider.Configure();

            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.None
                };

                settings.Converters.Add(new StringEnumConverter());
                return settings;
            });
        }

        private void SetupAutomapper()
        {
            Mapper.Initialize(
               x =>
               {
                   x.AddProfile<AnswersMappingProfile>();
                   x.AddProfile<QuestionnaireMappingProfile>();
               });
        }

        private void SetupIoc()
        {
            container = new Container();
            container.Register<ICommandHandlerDisptcher, CommandHandlerDisptcher>();
            container.Register<IQueryHandlerDispatcher, QueryHandlerDispatcher>();

            container.RegisterManyForOpenGeneric(typeof(IQueryHandlerAsync<,>), typeof(GetQuestionnaireQueryHandler).Assembly);
            container.RegisterManyForOpenGeneric(typeof(ICommandHandlerAsync<,>), typeof(CreateAnswersCommandHandler).Assembly);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.RegisterMvcControllers();


            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
