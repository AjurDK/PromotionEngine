using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Service;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var skuIds = new List<string> { "A", "B", "C", "D" };

            var serviceProvider = new ServiceCollection()
                                    .AddTransient<IPromotionEngineService, PromotionEngineService>()
                                    .BuildServiceProvider();

            var promotionEngineService = serviceProvider.GetService<IPromotionEngineService>();
            var totalSum = promotionEngineService.GetGrandTotal(skuIds);

            Console.WriteLine(totalSum);
            Console.ReadLine();
        }
    }
}
