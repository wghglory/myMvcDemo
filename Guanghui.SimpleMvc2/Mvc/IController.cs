using System.Web;

namespace Guanghui.SimpleMvc2.Mvc
{
    /// <summary>
    /// 约束所有具备处理请求能力
    /// </summary>
    public interface IController
    {
        ActionResult Execute(RequestContext context);
    }
}