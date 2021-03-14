using Fundamentals.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Fundamentals.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceColection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceColection);
            }

            return ServiceTool.Create(serviceColection);
        }
    }
}