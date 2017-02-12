using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace Guanghui.SimpleMvc2.Mvc
{
    public abstract class ControllerBase : IController
    {
        protected HttpContext Context { get; set; }
        protected IDictionary<string, object> RouteData { get; set; }
        public virtual ActionResult Execute(RequestContext context)
        {
            Context = context.HttpContext;
            RouteData = context.RouteData;
            // 获取ActionName
            var actionName = RouteData["action"].ToString();

            #region 找到Action方法对象 echo method
            // 先找到当前类中的所有方法
            var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MethodInfo method = null;
            foreach (var item in methods)
            {
                if (item.Name.Equals(actionName, StringComparison.InvariantCultureIgnoreCase))
                {
                    method = item;
                    break;
                }
            }

            if (method == null)
                throw new HttpException(404, "Not Found");
            #endregion

            List<object> values = new List<object>();
            var parameters = method.GetParameters();
            foreach (var parameter in parameters)
            {
                var name = parameter.Name;
                var type = parameter.ParameterType;
                // 参数来源： 1. Form  2. QueryString  3. RouteData
                var value = Context.Request[name];
                if (string.IsNullOrEmpty(value))
                {
                    value = RouteData.ContainsKey(name) ? RouteData[name].ToString() : null;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    // 值类型转换
                    values.Add(Convert.ChangeType(value, type));
                }
                else
                {
                    values.Add(null);
                }
            }

            return method.Invoke(this, values.ToArray()) as ActionResult;
        }
    }
}