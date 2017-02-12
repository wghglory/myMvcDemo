using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guanghui.SimpleMvc
{
    public partial class Error1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            Response.Write("<h1>not found</h>");
            Response.StatusCode = 404;
            Response.StatusDescription = "not found this page";
        }
    }
}