using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Service;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class UnitTest1 : IClassFixture<ProvideFixture>
    {
        private ServiceProvider _serviceProvide;

        public UnitTest1(ProvideFixture provideFixture)
        {
            _serviceProvide = provideFixture.ServiceProvider;
        }

        [Fact]
        public void GetGrandTotalScenario1()
        {
            var skuIds = new List<string> { "A", "B", "C" };

            var promotionEngineService = _serviceProvide.GetService<IPromotionEngineService>();
            var totalSum = promotionEngineService.GetGrandTotal(skuIds);

            Assert.True(totalSum == 100);
        }

        [Fact]
        public void GetGrandTotalScenario2()
        {
            var skuIds = new List<string> { "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C" };

            var promotionEngineService = _serviceProvide.GetService<IPromotionEngineService>();
            var totalSum = promotionEngineService.GetGrandTotal(skuIds);

            Assert.True(totalSum == 370);
        }

        [Fact]
        public void GetGrandTotalScenario3()
        {
            var skuIds = new List<string> { "A", "A", "A", "B", "B", "B", "B", "B", "C", "D" };

            var promotionEngineService = _serviceProvide.GetService<IPromotionEngineService>();
            var totalSum = promotionEngineService.GetGrandTotal(skuIds);

            Assert.True(totalSum == 280);
        }
    }
}
