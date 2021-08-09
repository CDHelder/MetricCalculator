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
        public double MeterToCentimeter(double meter, bool LogInfo)
        {
            return Calc(meter, 100, LogInfo, false);
        }
        public double CentimeterToMeter(double centimeter, bool LogInfo)
        {
            return Calc(centimeter, 100, LogInfo, true);
        }
        public double CentimeterToMillimeter(double centimeter, bool LogInfo)
        {
            return Calc(centimeter, 10, LogInfo, false);
        }
        public double MillimeterToCentimeter(double millimeter, bool logInfo)
        {
            return Calc(millimeter, 10, logInfo, true);
        }
        public double MeterToInch(double meter, bool LogInfo)
        {
            return Calc(meter, 39.36, LogInfo, false);
        }
        public double InchToMeter(double inch, bool LogInfo)
        {
            return Calc(inch, 39.36, LogInfo, true);
        }
        double Calc(double input, double divideTimes, bool logInfo, bool divide)
        {
            if (logInfo == true)
            {
                try
                {
                    double calcValue;
                    if (divide == true)
                        calcValue = input / divideTimes;
                    else
                        calcValue = input * divideTimes;

                    Logger.LogInfo(input, calcValue, MethodBase.GetCurrentMethod().Name);
                    return calcValue;
                }
                catch (Exception ex)
                {
                    Logger.LogError(input, ex);
                    return 0;
                }
            }

            if (divide == true)
                return input / divideTimes;
            else
                return input * divideTimes;
        }
    }
}
