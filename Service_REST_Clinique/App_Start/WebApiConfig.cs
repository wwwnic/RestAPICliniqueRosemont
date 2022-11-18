using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Service_REST_Clinique
{
    public static class WebApiConfig
    {
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'HttpConfiguration' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
        public static void Register(HttpConfiguration config)
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'HttpConfiguration' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
