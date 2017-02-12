using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Guanghui.SimpleMvc2.Routing
{
    /// <summary>
    /// 路由对象（路由规则）
    /// </summary>
    public class Route
    {
        public Route(string url, object defaults, Func<IDictionary<string, object>, IHttpHandler> getHandler)
        {
            UrlTemplate = url;

            Defaults = new Dictionary<string, object>();
            var defProps = defaults.GetType().GetProperties();
            foreach (var item in defProps)
            {
                Defaults.Add(item.Name, item.GetValue(defaults));
            }

            this.GetRouteHandler = getHandler;
        }

        /// <summary>
        /// 路由对象URL模版 "{controller}/{action}"
        /// </summary>
        public string UrlTemplate { get; set; }

        /// <summary>
        /// new { controller="Home", action="Index" }
        /// </summary>
        public IDictionary<string, object> Defaults { get; set; }

        /// <summary>
        /// 当前请求处理程序
        /// </summary>
        public Func<IDictionary<string, object>, IHttpHandler> GetRouteHandler { get; set; }

        #region 让该路由规则主动匹配一个Url +bool MatchRoute(string requestUrl, out IDictionary<string, object> routeData)
        /// <summary>
        /// 让该路由规则主动匹配一个Url
        /// </summary>
        /// <param name="requestUrl">"sdfs/dsfsd"</param>
        public bool MatchRoute(string requestUrl, out IDictionary<string, object> routeData)
        {
            // this.UrlTemplate         and  requestUrl
            // "{controller}/{action}"  and  "sdfs/dsfsd"
            // "sdfs/{action}"  and  "sdfs/dsfsd"

            // 为路由字典赋值一个空集合用于存放 匹配出来的数据
            // 先往路由数据中装入默认值（千万不要直接复制，引用类型的问题）
            routeData = new Dictionary<string, object>();
            foreach (var item in this.Defaults)
            {
                routeData.Add(item.Key, item.Value);
            }

            var requestUrlItems = requestUrl.Split('/'); // {"sdfs","dsfsd"}
            var urlTemplateItems = this.UrlTemplate.Split('/'); // {"{controller}","{action}"}


            // 判断是否匹配成功
            if (requestUrlItems.Length != urlTemplateItems.Length)
            {
                return false;
            }


            // 格式匹配了 开始匹配每一个元素
            for (int i = 0; i < requestUrlItems.Length; i++)
            {
                var urlTemplateItem = urlTemplateItems[i]; //   "{controller}"      "sdfg"
                var requestUrlItem = requestUrlItems[i]; //     "sdfs"              "sdfsdf"
                if (urlTemplateItem.StartsWith("{") && urlTemplateItem.EndsWith("}"))
                {
                    // 此时模版中是一个占位符变量 变量名=urlTemplateItem.trim("{}") 变量值=requestUrlItem
                    var key = urlTemplateItem.Trim("{}".ToArray());

                    if (routeData.ContainsKey(key))
                    {
                        // 字典中存在该键
                        routeData[key] = requestUrlItem;
                    }
                    else { routeData.Add(key, requestUrlItem); }
                }
                else
                {
                    // 不是占位符则必须强匹配
                    if (!urlTemplateItem.Equals(requestUrlItem, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 防止外面拿到假数据
                        routeData.Clear();
                        // 该位置没有匹配成功
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}