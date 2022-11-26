using Autofac;
using ProductCodeGenarator.Domain.Services.Code;

namespace ProductCodeGenarator.Utilities
{
    public class DependencyResolver : Module
    {
        //DI için kullandığım DependencyResolverSınıfını iplement ettiğimiz interfaceleri, repositoryleri kolayca görmek hem de Program veya Startup sınıfında kalabalık oluşturmamak için tercih ettiğim bir yöntem.
        protected override void Load(ContainerBuilder builder)
        {
            LoadServices(builder);
        }
        private void LoadServices(ContainerBuilder builder) 
        {
            builder.RegisterType<CodeService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
