using System.Net.Http.Headers;
using System.Web.Http;

namespace CC9_Assessment_2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.Remove(config.Formatters.XmlFormatter);

         
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
