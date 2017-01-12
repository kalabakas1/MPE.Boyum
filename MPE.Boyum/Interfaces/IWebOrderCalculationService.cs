using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPE.Boyum.Models;

namespace MPE.Boyum.Interfaces
{
    public interface IWebOrderCalculationService
    {
        decimal CalculateAverage(WebOrder order);

        decimal CalculateTotal(WebOrder order);
    }
}
