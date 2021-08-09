using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricCalculator.WebRazor.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public double BeforeValue { get; set; }
        public double AfterValue { get; set; }
        public int CalculationTypeId { get; set; }
        public CalculationType Type { get; set; }
        public DateTime DateTimeCalculated { get; set; }
    }
}
