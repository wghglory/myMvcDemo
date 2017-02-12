using System;
using Guanghui.SimpleMvc2.Mvc;
using Guanghui.SimpleMvc2.Routing;

namespace Guanghui.SimpleMvc2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //RouteTable.Routes.Add(new Route(
            //    "{controller}/{action}",
            //    new { controller = "Home", action = "Index" }
            //));

            //RouteTable.Routes.Add(new Route(
            //    "hello/{action}",
            //    new { controller = "Home", action = "Index" }
            //));

            RouteTable.Routes.MapRoute(
               "{controller}/{action}/{id}",
               new { controller = "Home", action = "Index" }
           );
            RouteTable.Routes.MapRoute(
                "{controller}/{action}",
                new { controller = "Home", action = "Index" }
            );


        }


    }
}