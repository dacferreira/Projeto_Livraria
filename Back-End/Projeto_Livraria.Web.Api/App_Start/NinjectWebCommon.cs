using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Projeto_Livraria.Web.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Projeto_Livraria.Web.Api.App_Start.NinjectWebCommon), "Stop")]


namespace Projeto_Livraria.Web.Api.App_Start
{

    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Projeto_Livraria.Aplicacao.Interfaces.Base;
    using Projeto_Livraria.Aplicacao.Interfaces.Livros;
    using Projeto_Livraria.Aplicacao.Services.Base;
    using Projeto_Livraria.Aplicacao.Services.Livros;
    using Projeto_Livraria.Dominio.Interfaces.Repositories.Base;
    using Projeto_Livraria.Dominio.Interfaces.Repositories.Livros;
    using Projeto_Livraria.Dominio.Interfaces.Services.Base;
    using Projeto_Livraria.Dominio.Interfaces.Services.Livros;
    using Projeto_Livraria.Dominio.Services.Base;
    using Projeto_Livraria.Dominio.Services.Livros;
    using Projeto_Livraria.Infraestrutura.Data.Repositories.Base;
    using Projeto_Livraria.Infraestrutura.Data.Repositories.Livros;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>)).InSingletonScope();
            kernel.Bind<ILivroAppService>().To<LivroAppService>().InSingletonScope();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>)).InSingletonScope();
            kernel.Bind<ILivroService>().To<LivroService>().InSingletonScope();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>)).InSingletonScope();
            kernel.Bind<ILivroRepository>().To<LivroRepository>().InSingletonScope();
        }
    }
}