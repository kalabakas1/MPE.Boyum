using System.Linq;
using MPE.Boyum.Interfaces;
using MPE.Boyum.Models;

namespace MPE.Boyum.Logic
{
    internal class WebOrderWebOrderCalculationService : IWebOrderCalculationService
    {
        public decimal CalculateAverage(WebOrder order)
        {
            return order.Items?.Average(x => x.Price) ?? 0;
        }

        public decimal CalculateTotal(WebOrder order)
        {
            return order.Items?.Sum(x => x.Price * x.Quantity) ?? 0;
        }
    }
}
