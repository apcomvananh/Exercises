using System.Web.Mvc;
using System.Web.Routing;

namespace TOEICEssentialWords.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "lessonUrl",
                string.Concat("lesson", "/{slug}"),
                new { controller = "Lesson", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                "searchUrl",
                string.Concat("search", "/{keyword}"),
                new { controller = "Word", action = "SearchWord", keyword = UrlParameter.Optional }
            );

            routes.MapRoute(
                "notFoundUrl",
                string.Concat("notfound", "/{keyword}"),
                new { controller = "Word", action = "NotFound", keyword = UrlParameter.Optional }
            );

            routes.MapRoute(
                "wordUrl",
                string.Concat("word", "/{slug}"),
                new { controller = "Word", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}