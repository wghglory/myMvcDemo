using System;
using System.Web;
using Guanghui.SimpleMvc.Mvc;

namespace Guanghui.SimpleMvc.Controllers
{
    public class MemberController : IController
    {
        private HttpContext _context;
        public void Execute(HttpContext context)
        {
            this._context = context;
            string actionName = context.Request.QueryString["a"] ?? "Index";
            switch (actionName.ToLower())
            {
                case "index":
                    Index();
                    break;

            }
            
        }

        //http://localhost:31127/?c=member&a=index
        public void Index()
        {
            _context.Response.Write("hello");
        }
    }
}