using System.Collections.Generic;
using System.Web;
using Guanghui.SimpleMvc2.Controllers;

namespace Guanghui.SimpleMvc2.Mvc
{
    /// <summary>
    /// 找到控制器处理请求
    /// </summary>
    public class MvcHandler : IHttpHandler
    {
        private IDictionary<string, object> routeData;

        public MvcHandler(IDictionary<string, object> routeData)
        {
            this.routeData = routeData;
        }

        public void ProcessRequest(HttpContext context)
        {
            //ask your request
            string controllerName = routeData["controller"].ToString();

            ////help u to find the right person
            //IController controller = null;
            //switch (controllerName.ToString().ToLower())
            //{
            //    case "member":
            //        controller = new MemberController();
            //        break;
            //    case "product":
            //        controller = new ProductController();
            //        break;
            //}

            IController controller = DefaultControllerFactory.CreateController(controllerName);

            //make sure there's someone who can handle the request
            if (controller == null)
            {
                throw new HttpException(404, "not found");
            }


            var requestContext = new RequestContext { HttpContext = context, RouteData = routeData };
            // 已经找到
            var result = controller.Execute(requestContext);
            result.Execute(requestContext);

            //receptionist's work is done.
        }

        public bool IsReusable { get { return false; } }
    }
}