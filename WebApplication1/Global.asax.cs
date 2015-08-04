using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ValidationPoc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();

            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter());
                return settings;
            });
        }
    }
}
