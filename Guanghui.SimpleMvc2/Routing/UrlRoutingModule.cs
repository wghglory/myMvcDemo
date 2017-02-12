using System.Collections.Generic;
using System.Web;

namespace Guanghui.SimpleMvc2.Routing
{
    /// <summary>
    /// 解析请求带来的路由数据，再将得到的数据分发给处理程序
    /// （伪静态）
    /// </summary>
    public class UrlRoutingModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            //注册第七个管道事件
            application.PostResolveRequestCache += Application_PostResolveRequestCache;
        }

        /// <summary>
        /// 假定请求http://localhost:31127/member/index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_PostResolveRequestCache(object sender, System.EventArgs e)
        {
            #region 获取请求相对于网站根目录的路径 pathName
            var application = sender as HttpApplication;
            var context = application.Context;

            //根据全局路由表解析当前请求的路径 member/index
            var requestUrl = context.Request.AppRelativeCurrentExecutionFilePath.Substring(2);  //AppRelativeCurrentExecutionFilePath: ~/member/index 
            #endregion

            #region 获取当前请求的处理路由
            //解析数据，返回被匹配上的路由对象
            IDictionary<string, object> routeData;
            var route = RouteTable.MatchRoutes(requestUrl, out routeData);

            if (route == null)
            {
                //404未找到
                throw new HttpException(404, "there is no route matching your request");
            }

            if (!routeData.ContainsKey("controller") || !routeData.ContainsKey("action"))
            {
                throw new HttpException(404, "there is no route matching your request");
            }


            var handler = route.GetRouteHandler(routeData);
            #endregion

            //为当前请求分配一个处理程序
            context.RemapHandler(handler);

        }



        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}