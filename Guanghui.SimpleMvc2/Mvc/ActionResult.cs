namespace Guanghui.SimpleMvc2.Mvc
{
    public abstract class ActionResult
    {
        public abstract void Execute(RequestContext context);
    }
}