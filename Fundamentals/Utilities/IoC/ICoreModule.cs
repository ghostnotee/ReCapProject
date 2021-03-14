using Microsoft.Extensions.DependencyInjection;

namespace Fundamentals.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}