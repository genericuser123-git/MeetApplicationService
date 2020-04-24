using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MeetApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.
                              Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "PostNewMeeting",
                routeTemplate: "api/{controller}/{Action}/{name}/{year}/{month}/{day}/{hour}/{min}"
               // defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateMeetingState",
                routeTemplate: "api/{controller}/{Action}/{Id}"
                );

            config.Routes.MapHttpRoute(
                name: "DeleteParticipant",
                routeTemplate: "api/{controller}/{Action}/{Id}"
                );

            config.Routes.MapHttpRoute(
               name: "AddNewParticipant",
               routeTemplate: "api/{controller}/{Action}/{name}/{mail}/{meetingid}"
               );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            


        }
    }
}
