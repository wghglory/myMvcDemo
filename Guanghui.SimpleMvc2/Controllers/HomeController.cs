using Guanghui.SimpleMvc2.Mvc;

namespace Guanghui.SimpleMvc2.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(int id, string controller)
        {
            //Context.Response.Write("差不多了" + controller + id);
            return new ContentResult("<h1>Header</h1>", "text/html");
        }

        public ActionResult Json()
        {
            return new JsonResult(new { Id = 1, Name = "赵剑宇", Message = "小样你想跑！" });
        }
    }
}