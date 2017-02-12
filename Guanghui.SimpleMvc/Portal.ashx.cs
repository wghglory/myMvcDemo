using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guanghui.SimpleMvc.Controllers;
using Guanghui.SimpleMvc.Mvc;

namespace Guanghui.SimpleMvc
{
    /// <summary>
    /// Portal of the application to distribute requests. Not to deal with any business logic.
    /// Like MVC Route
    /// like receptionist in a company sitting near the gate. who are you? who do you want to meet with?
    /// </summary>
    public class Portal : IHttpHandler
    {
        /// <summary>
        /// pipeline 11-12th event
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //ask your request
            string controllerName = context.Request.QueryString["c"] ?? "Home";

            //help u to find the right person
            IController controller = null;
            switch (controllerName.ToLower())
            {
                case "member":
                    controller = new MemberController();
                    break;
                case "product":
                    controller = new ProductController();
                    break;
            }
            //make sure there's someone who can handle the request
            if (controller == null)
            {
                throw new HttpException(404, "not found");
            }

            //found that person
            controller.Execute(context);

            //receptionist's work is done.

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}