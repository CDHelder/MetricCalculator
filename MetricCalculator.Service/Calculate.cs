using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MetricCalculator;
using System.Threading.Tasks;

namespace MetricCalculator.Service
{
    public class Calculate
    {
        public double MeterToCentimeter(double meter)
        {
            try
            {
            var calcValue = meter * 100;
            Logger.LogInfo(meter, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(meter, ex);
                return 0;
            }
        }

        public double CentimeterToMeter(double centimeter)
        {
            try
            {
            var calcValue =  centimeter / 100;
            Logger.LogInfo(centimeter, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(centimeter, ex);
                return 0;
            }
        }
        public double CentimeterToMillimeter(double centimeter)
        {
            try
            {
            var calcValue = centimeter * 10;
            Logger.LogInfo(centimeter, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(centimeter, ex);
                return 0;
            }
        }
        public double MillimeterToCentimeter(double millimeter)
        {
            try
            {
            var calcValue = millimeter / 10;
            Logger.LogInfo(millimeter, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(millimeter, ex);
                return 0;
            }
        }
        public double MeterToInch(double meter)
        {
            try
            {
            var calcValue = meter * 39.36;
            Logger.LogInfo(meter, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(meter, ex);
                return 0;
            }
        }
        public double InchToMeter(double inch)
        {
            try
            {
            var calcValue = inch / 39.36;
            Logger.LogInfo(inch, calcValue, MethodBase.GetCurrentMethod().Name);
            return calcValue;
            }
            catch (Exception ex)
            {
                Logger.LogError(inch, ex);
                return 0;
            }
        }
    }
}
