using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Service;

namespace PromotionEngine.Tests
{
    public class ProvideFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public ProvideFixture()
        {
            var serviceCollection = new ServiceCollection()
                                    .AddTransient<IPromotionEngineService, PromotionEngineService>()
                                    .BuildServiceProvider();

            ServiceProvider = serviceCollection;
        }
    }
}
