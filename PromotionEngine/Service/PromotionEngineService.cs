using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Service
{
    public class PromotionEngineService : IPromotionEngineService
    {
        private int GetProductValue(string product)
        {
            var products = new Dictionary<string, int>();
            products.Add("A", 50);
            products.Add("B", 30);
            products.Add("C", 20);
            products.Add("D", 15);

            return products.Where(d => d.Key == product).Select(d => d.Value).FirstOrDefault();
        }

        private Promotion GetPromotionDetails(string promotion)
        {
            var promotions = new Dictionary<string, Promotion>();
            promotions.Add("A", new Promotion { TotalUnits = 3, Value = 130, SKUId = "None" });
            promotions.Add("B", new Promotion { TotalUnits = 2, Value = 45, SKUId = "None" });
            promotions.Add("C", new Promotion { TotalUnits = 1, Value = 30, SKUId = "D" });
            promotions.Add("D", new Promotion { TotalUnits = 1, Value = 30, SKUId = "C" });

            return promotions.Where(d => d.Key == promotion).Select(d => d.Value).FirstOrDefault();
        }

        public int GetGrandTotal(List<string> skuIds)
        {
            var skuGrpIds = skuIds.GroupBy(d => d).Select(d => new { sku = d.Key, Count = d.Count() }).ToList();
            var total = 0;
            var tempSKU = string.Empty;
            foreach (var skuId in skuGrpIds)
            {
                var totalCount = skuId.Count;
                var promotion = GetPromotionDetails(skuId.sku);
                var productValue = GetProductValue(skuId.sku);
                while (totalCount >= promotion.TotalUnits && promotion.SKUId == "None")
                {
                    total += promotion.Value;
                    totalCount -= promotion.TotalUnits;
                }

                if (skuIds.Contains(promotion.SKUId))
                {
                    if (skuId.sku == tempSKU)
                    {
                        total += promotion.Value;
                    }
                    tempSKU = promotion.SKUId;
                }
                else
                {
                    total += totalCount * productValue;
                }
            }

            return total;
        }
    }
}
