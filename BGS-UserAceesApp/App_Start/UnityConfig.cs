using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using DAL;
using Services;

namespace BGS_UserAceesApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<ITAUserPermissionRepo, TAUserPermissionRepo>();
            container.RegisterType<ITAUserRepo, TAUserRepo>();

            container.RegisterType<ITAUserPermissionService, TAUserPermissionService>();
            container.RegisterType<ITAUserService, TAUserService>();
        }
    }
}