using System.Web;

namespace Guanghui.SimpleMvc.Mvc
{
    /// <summary>
    /// 约束所有具备处理请求能力
    /// </summary>
    public interface IController
    {
        void Execute(HttpContext context);
    }
}