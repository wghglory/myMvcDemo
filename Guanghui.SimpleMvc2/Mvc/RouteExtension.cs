using System;
using System.Collections.Generic;
using System.Web;
using Guanghui.SimpleMvc2.Routing;

namespace Guanghui.SimpleMvc2.Mvc
{
    public static class RouteExtension
    {
        public static void MapRoute(this IList<Route> source, string url, object defaults)
        {
            MapRoute(source, url, defaults, routeData => new MvcHandler(routeData));
        }

        public static void MapRoute(this IList<Route> source, string url, object defaults, Func<IDictionary<string, object>,IHttpHandler> handler)
        {
            source.Add(new Route(url, defaults, handler));
        }
    }
}