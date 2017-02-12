using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using Guanghui.SimpleMvc2.Controllers;

namespace Guanghui.SimpleMvc2.Mvc
{
    public static class DefaultControllerFactory
    {
        /// <summary>
        /// 当前行目中所有的控制器类型实例
        /// </summary>
        public static IList<Type> AllControllerTypes { get; set; }

        static DefaultControllerFactory()
        {
            AllControllerTypes = new List<Type>();
            //找到所有引用的程序集
            var assemblies = BuildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    //判断是否是控制器（必须实现IController)
                    if (type.IsClass && !type.IsAbstract && !type.IsInterface && typeof(IController).IsAssignableFrom(type))
                    {
                        AllControllerTypes.Add(type);
                    }

                }
            }
        }

        public static IController CreateController(string controllerName)
        {
            #region simple factory
            //IController controller = null;
            //switch (controllerName.ToString().ToLower())
            //{
            //    case "member":
            //        controller = new MemberController();
            //        break;
            //    case "product":
            //        controller = new ProductController();
            //        break;
            //}
            //return controller; 
            #endregion

            #region abstract factory V1
            //string controllerTypeName = string.Format("Guanghui.SimpleMvc2.Controllers.{0}Controller", controllerName);
            //return Assembly.GetExecutingAssembly().CreateInstance(controllerTypeName, true) as IController;
            #endregion

            #region abstract factory V2

            foreach (var item in AllControllerTypes)
            {
                if (item.Name.Equals(controllerName + "controller", StringComparison.CurrentCultureIgnoreCase))
                {
                    var controller = Activator.CreateInstance(item) as IController;
                    return controller;
                }
            }
            return null;

            #endregion
        }
    }
}