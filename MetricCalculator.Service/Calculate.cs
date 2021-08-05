using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricCalculator.Service
{
    public static class Calculate
    {
        public static double MeterToCentimeter(double meter)
        {
            return meter * 100;
        }
        public static double CentimeterToMeter(double centimeter)
        {
            return centimeter / 100;
        }
        public static double CentimeterToMillimeter(double centimeter)
        {
            return centimeter * 10;
        }
        public static double MillimeterToCentimeter(double millimeter)
        {
            return millimeter / 10;
        }
        public static double MeterToInch(double meter)
        {
            return meter * 39.36;
        }
        public static double InchToMeter(double inch)
        {
            return inch / 39.36;
        }
    }
}
