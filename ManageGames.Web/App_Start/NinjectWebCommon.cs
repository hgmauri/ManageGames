using ManageGames.Business.Business;
using ManageGames.Business.IBusiness;
using ManageGames.Data.Repositories;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Web.Models;
using Microsoft.AspNet.Identity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ManageGames.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ManageGames.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ManageGames.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAmigoBusiness>().To<AmigoBusiness>();
            kernel.Bind<IGeneroBusiness>().To<GeneroBusiness>();
            kernel.Bind<IJogoBusiness>().To<JogoBusiness>();
            kernel.Bind<IEmprestimoBusiness>().To<EmprestimoBusiness>();
            

            kernel.Bind<IEmprestimoRepository>().To<EmprestimoRepository>();
            kernel.Bind<IJogoRepository>().To<JogoRepository>();
            kernel.Bind<IGeneroRepository>().To<GeneroRepository>();
            kernel.Bind<IAmigoRepository>().To<AmigoRepository>();

            kernel.Bind<ApplicationDbContext>().ToSelf();
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().WithConstructorArgument("context", kernel.Get<ApplicationDbContext>());
            kernel.Bind<UserManager<ApplicationUser>>().ToSelf();
        }        
    }
}
