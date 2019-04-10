﻿using System.Web.Http;

namespace Resource.Skills.Analysis.App_Start
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: UrlPrefix + "/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}