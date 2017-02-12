﻿namespace Guanghui.SimpleMvc2.Mvc
{
    public class ContentResult : ActionResult
    {
        private string content;
        private string contentType;

        public ContentResult(string content, string contentType)
        {
            // TODO: Complete member initialization
            this.content = content;
            this.contentType = contentType;
        }
        public override void Execute(RequestContext context)
        {
            context.HttpContext.Response.Write(content);
            context.HttpContext.Response.ContentType = contentType;
        }
    }
}