using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetricCalculator
{
    public static class Logger
    {
        private const string fileName = "MetricCalculatorLogging.txt";

        public static void LogInfo(double value, double calcValue, string methodName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                //_logger.LogInformation($"{DateTime.Now}: {value} {methodName} = {calcValue}");
                writer.WriteLine($"{DateTime.Now}: {value} {methodName} = {calcValue}");
            }
        }
        public static void LogError(double meter, Exception ex)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                //_logger.LogError($"{DateTime.Now}: {ex.GetType()}: {ex.Message} \nAt calculation {meter} {MethodBase.GetCurrentMethod().Name}");
                writer.WriteLine($"{DateTime.Now}: {ex.GetType()}: {ex.Message} \nAt calculation {meter} {MethodBase.GetCurrentMethod().Name}");
            }
        }
    }
}
