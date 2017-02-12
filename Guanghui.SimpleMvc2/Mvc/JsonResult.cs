using System.Web.Script.Serialization;

namespace Guanghui.SimpleMvc2.Mvc
{
    public class JsonResult : ActionResult
    {
        private object p;

        public JsonResult(object p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        public override void Execute(RequestContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var json = jss.Serialize(p);
            context.HttpContext.Response.Write(json);
            context.HttpContext.Response.ContentType = "application/json";
        }
    }
}