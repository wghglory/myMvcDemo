using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guanghui.SimpleMvc.Routing
{
    /// <summary>
    /// 路由对象{controller}/{action}
    /// </summary>
    public class Route
    {
        public Route(string url, object defaults)
        {
            UrlTemplate = url;

            Defaults = new Dictionary<string, object>();
            var defPros = defaults.GetType().GetProperties();
            foreach (var d in defPros)
            {
                Defaults.Add(d.Name, d.GetValue(defaults));
            }
        }

        public string UrlTemplate { get; set; }

        /// <summary>
        /// new {controller="Home", action="Index"}
        /// </summary>
        public IDictionary<string, object> Defaults { get; set; }

        /// <summary>
        /// 让该路由规则主动匹配一个Url
        /// </summary>
        /// <param name="requestUrl"></param>
        internal void MatchUrl(string requestUrl)
        {
            //this.UrlTemplate  and requestUrl
            //{controller}/{action} and "member/index"

        }
    }
}