using System.Collections.Generic;

namespace Guanghui.SimpleMvc2.Routing
{
    public static class RouteTable
    {
        /// <summary>
        /// 全局路由表（路由规则）
        /// </summary>
        public static IList<Route> Routes { get; set; }

        static RouteTable()
        {
            Routes = new List<Route>();
        }

        /// <summary>
        /// 根据请求的pathName解析路由数据
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static Route MatchRoutes(string requestUrl, out IDictionary<string, object> dic)
        {
            dic = null;
            //遍历全局路由表中的路由规则
            foreach (Route route in Routes)
            {
                //让当前遍历的路由对象匹配当前请求地址
                if (route.MatchRoute(requestUrl, out dic))
                {
                    return route;
                }
            }
            return null;
        }
    }

}