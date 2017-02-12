using System.Collections;
using System.Collections.Generic;


namespace Guanghui.SimpleMvc.Routing
{
    public class RouteTable
    {
        /// <summary>
        /// 全局路由表（路由规则）
        /// </summary>
        public static IList<Route> Routes { get; set; }

        public RouteTable()
        {
            Routes = new List<Route>();
        }
    }

}