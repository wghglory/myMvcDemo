using System.Web;

namespace Guanghui.SimpleMvc.Routing
{
    /// <summary>
    /// 解析请求带来的路由数据，再将得到的数据分发给处理程序
    /// （伪静态）
    /// </summary>
    public class UrlRoutingModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.PostResolveRequestCache += Application_PostResolveRequestCache;
        }

        /// <summary>
        /// 假定请求http://localhost:31127/member/index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_PostResolveRequestCache(object sender, System.EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;

            //根据全局路由表解析当前请求的路径 member/index
            var requestUrl = context.Request.AppRelativeCurrentExecutionFilePath.Substring(2);  //AppRelativeCurrentExecutionFilePath: ~/member/index

            //遍历全局路由表中的路由规则
            foreach (var route in RouteTable.Routes)
            {
                //让当前遍历的路由对象匹配当前请求地址
                route.MatchUrl(requestUrl);
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}