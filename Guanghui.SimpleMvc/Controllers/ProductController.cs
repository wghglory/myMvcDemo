using System.Web;
using Guanghui.SimpleMvc.Mvc;

namespace Guanghui.SimpleMvc.Controllers
{
    public class ProductController:IController
    {
        public void Execute(HttpContext context)
        {
            context.Response.Write("ProductController");
        }
    }
}