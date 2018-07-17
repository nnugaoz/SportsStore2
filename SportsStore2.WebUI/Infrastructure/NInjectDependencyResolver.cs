using Ninject;
using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SportsStore2.WebUI.Infrastructure
{
    public class NInjectDependencyResolver:IDependencyResolver
    {
        IKernel kernel;

        public NInjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            Bindings();
        }

        private void Bindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}