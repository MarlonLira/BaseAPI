using Application.Commons;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Presentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCrossSiteRequests(config);
            AddRoutes(config);
        }

        private static void AddRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/"
            );
        }

        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            config.EnableCors(cors);
        }
    }
}
