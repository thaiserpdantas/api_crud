using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_CRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "ClienteApi",
            //    routeTemplate: "api/Clientes/{id}",
            //    defaults: new { controller = "cliente", id = RouteParameter.Optional }
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "ClienteApi",
            //    routeTemplate: "api/Clientes/{id}/Endereco/{endId}",
            //    defaults: new { controller = "endereco", endId = RouteParameter.Optional }
            //    );
        }
    }
}
