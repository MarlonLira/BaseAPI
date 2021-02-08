using Infra;
using System.Web.Http;
using Unity.WebApi;

namespace Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(InjectorConfig.GetContainer());
        }
    }
}