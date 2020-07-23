using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Service;
using System;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                    .AddTransient<IPromotionEngineService, PromotionEngineService>()
                                    .BuildServiceProvider();
        }
    }
}
