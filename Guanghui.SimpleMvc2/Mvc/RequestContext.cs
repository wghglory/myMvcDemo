using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guanghui.SimpleMvc2.Mvc
{
    /// <summary>
    /// 将路由数据和请求上下文打包
    /// </summary>
    public class RequestContext
    {
        public HttpContext HttpContext { get; set; }

        public IDictionary<string, object> RouteData { get; set; }
    }
}