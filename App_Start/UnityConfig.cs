using College_Management_System.UnitOfWork;
using System.Web.Mvc;
using College_Management_System.App_Start;
using College_Management_System.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Unity;
using Unity.Mvc5;

namespace College_Management_System
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();

            var unityHubActivator = new UnityHubActivator(container);
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => unityHubActivator);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}