using MetricCalculator.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace MetricCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var Calculate = serviceProvider.GetService<Calculate>();

            try
            {
            StartProgram(Calculate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
                CloseApplication();
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(config => config.AddConsole()).AddTransient<Calculate>();
        }

        private static void StartProgram(Calculate calculate)
        {
            HomeScreen();

            string optionEntry;
            Regex homeRegex = new("[^1-7]");
            do
            {
                optionEntry = Console.ReadLine();

                if (homeRegex.IsMatch(optionEntry) == true)
                {
                    Console.WriteLine("Please enter a valid number to redirect");
                }
            } while (homeRegex.IsMatch(optionEntry) == true);

            ExecuteSelectedOption(optionEntry, calculate);
        }

        private static void HomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("\n1.Meter naar centimeter \n2.Centimeter naar meter \n" +
                "3.Centimeter naar millimeter \n4.Millimeter naar centimeter \n" +
                "5.Meter naar inch \n6.Inch naar meter \n7.Afsluiten \n");
        }

        private static void ExecuteSelectedOption(string optionEntry, Calculate calculate)
        {
            Console.Clear();

            //TODO: Vervang firsttype en second door optionEntry en die switch statement met int 1tm7
            switch (int.Parse(optionEntry))
            {
                case 1:
                    Console.WriteLine("Meter to Centimeter");
                    ReadCalculateShowRedirect(optionEntry, "Meter", "Centimeter", calculate);
                    break;
                case 2:
                    Console.WriteLine("Centimeter to Meter");
                    ReadCalculateShowRedirect(optionEntry, "Centimeter", "Meter", calculate);
                    break;
                case 3:
                    Console.WriteLine("Centimeter to Millimeter");
                    ReadCalculateShowRedirect(optionEntry, "Centimeter", "Millimeter", calculate);
                    break;
                case 4:
                    Console.WriteLine("Millimeter to Centimeter");
                    ReadCalculateShowRedirect(optionEntry, "Millimeter", "Centimeter", calculate);
                    break;
                case 5:
                    Console.WriteLine("Meter to Inch");
                    ReadCalculateShowRedirect(optionEntry, "Meter", "Inch", calculate);
                    break;
                case 6:
                    Console.WriteLine("Inch to Meter");
                    ReadCalculateShowRedirect(optionEntry, "Inch", "Meter", calculate);
                    break;
                case 7:
                    CloseApplication();
                    break;
                default:
                    break;
            }
        }

        private static void ReadCalculateShowRedirect(string optionEntry, string firstType, string secondType, Calculate calculate)
        {
            Console.WriteLine("Please enter a value to calculate");

            string value;
            do
            {
                value = Console.ReadLine();
                if(Double.Parse(value) <= 0)
                    Console.WriteLine("Please enter a valid value to calculate");
            } while (Double.Parse(value) <= 0);

            var calculatedValue = GetCalculatedValue(value, optionEntry, calculate);
            if (calculatedValue > 0)
                Console.WriteLine($"{value} {firstType} = {calculatedValue} {secondType}");

            AfterCalculationOptionSelection(optionEntry, calculate);
        }

        private static double GetCalculatedValue(string value, string optionEntry, Calculate Calculate)
        {
            double doubleValue = Double.Parse(value);

            if (doubleValue <= 0)
            {
                Console.WriteLine("Please enter a valid value to calculate");
                var value2 = Console.ReadLine();
                return GetCalculatedValue(value2, optionEntry, Calculate); ;
            }

            switch (int.Parse(optionEntry))
            {
                case 1:
                    return Calculate.MeterToCentimeter(doubleValue, true);
                case 2:
                    return Calculate.CentimeterToMeter(doubleValue, true);
                case 3:
                    return Calculate.CentimeterToMillimeter(doubleValue, true);
                case 4:
                    return Calculate.MillimeterToCentimeter(doubleValue, true);
                case 5:
                    return Calculate.MeterToInch(doubleValue, true);
                case 6:
                    return Calculate.InchToMeter(doubleValue, true);
                default:
                    break;
            }
            return 0;
        }

        private static void CloseApplication()
        {
            Console.WriteLine("\nBye, see you next time :)");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        private static void AfterCalculationOptionSelection(string optionEntry, Calculate calculate)
        {
            Console.WriteLine("\nPlease select one of the following options: " +
                "\n1.Opnieuw berekenen \n2.Terug \n3.Afsluiten");

            string afterCalcOptionEntry;
            Regex optionSelectionRegex = new Regex("[^1-3]");
            do
            {
                afterCalcOptionEntry = Console.ReadLine();

                if (optionSelectionRegex.IsMatch(afterCalcOptionEntry) == true)
                {
                    Console.WriteLine("Please enter a valid number to redirect");
                }
            } while (optionSelectionRegex.IsMatch(afterCalcOptionEntry) == true);

            switch (int.Parse(afterCalcOptionEntry))
            {
                case 1:
                    ExecuteSelectedOption(optionEntry, calculate);
                    break;
                case 2:
                    HomeScreen();
                    var homeScreenOptionEntry = Console.ReadLine();
                    ExecuteSelectedOption(homeScreenOptionEntry, calculate);
                    break;
                case 3:
                    CloseApplication();
                    break;
                default:
                    break;
            }
        }
    }
}
