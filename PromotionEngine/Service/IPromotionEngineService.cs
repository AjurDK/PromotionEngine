using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Service
{
    public interface IPromotionEngineService
    {
        public int GetGrandTotal(List<string> skuIds);
    }
}
