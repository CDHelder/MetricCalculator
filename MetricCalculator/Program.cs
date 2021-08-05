using MetricCalculator.Service;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace MetricCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeScreen();

            string optionEntry;
            Regex homeRegex = new Regex("[^1-7]");
            do
            {
                optionEntry = Console.ReadLine();

                if (homeRegex.IsMatch(optionEntry) == false)
                {
                    Console.WriteLine("Please enter a valid number to redirect");
                }
            } while (homeRegex.IsMatch(optionEntry) == false);

            ExecuteSelectedOption(optionEntry);
        }

        private static void HomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("\n1.Meter naar centimeter \n2.Centimeter naar meter \n" +
                "3.Centimeter naar millimeter \n4.Millimeter naar centimeter \n" +
                "5.Meter naar inch \n6.Inch naar meter \n7.Afsluiten \n");
        }

        private static void ExecuteSelectedOption(string optionEntry)
        {
            Console.Clear();

            //TODO: Vervang firsttype en second door optionEntry en die switch statement met int 1tm7
            switch (int.Parse(optionEntry))
            {
                case 1:
                    Console.WriteLine("Meter to Centimeter");
                    ReadCalculateShowRedirect(optionEntry, "Meter", "Centimeter");
                    break;
                case 2:
                    Console.WriteLine("Centimeter to Meter");
                    ReadCalculateShowRedirect(optionEntry, "Centimeter", "Meter");
                    break;
                case 3:
                    Console.WriteLine("Centimeter to Millimeter");
                    ReadCalculateShowRedirect(optionEntry, "Centimeter", "Millimeter");
                    break;
                case 4:
                    Console.WriteLine("Millimeter to Centimeter");
                    ReadCalculateShowRedirect(optionEntry, "Millimeter", "Centimeter");
                    break;
                case 5:
                    Console.WriteLine("Meter to Inch");
                    ReadCalculateShowRedirect(optionEntry, "Meter", "Inch");
                    break;
                case 6:
                    Console.WriteLine("Inch to Meter");
                    ReadCalculateShowRedirect(optionEntry, "Inch", "Meter");
                    break;
                case 7:
                    CloseApplication();
                    break;
                default:
                    break;
            }
        }

        private static void ReadCalculateShowRedirect(string optionEntry, string firstType, string secondType)
        {
            Console.WriteLine("Please enter a value to calculate");

            string value;
            do
            {
                value = Console.ReadLine();
                if(Double.Parse(value) <= 0)
                    Console.WriteLine("Please enter a valid value to calculate");
            } while (Double.Parse(value) <= 0);

            var calculatedValue = GetCalculatedValue(value, firstType, secondType);
            Console.WriteLine($"{value} {firstType} = {calculatedValue} {secondType}");
            AfterCalculationOptionSelection(optionEntry);
        }

        private static double GetCalculatedValue(string value, string firstType, string secondType)
        {
            double doubleValue = Double.Parse(value);

            if (doubleValue <= 0)
            {
                Console.WriteLine("Please enter a valid value to calculate");
                var value2 = Console.ReadLine();
                return GetCalculatedValue(value2, firstType, secondType); ;
            }

            switch (firstType+secondType)
            {
                case "MeterCentimeter":
                    return Calculate.MeterToCentimeter(doubleValue);
                case "CentimeterMeter":
                    return Calculate.CentimeterToMeter(doubleValue);
                case "CentimeterMillimeter":
                    return Calculate.CentimeterToMillimeter(doubleValue);
                case "MillimeterCentimeter":
                    return Calculate.MillimeterToCentimeter(doubleValue);
                case "MeterInch":
                    return Calculate.MeterToInch(doubleValue);
                case "InchMeter":
                    return Calculate.InchToMeter(doubleValue);
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

        private static void AfterCalculationOptionSelection(string optionEntry)
        {
            Console.WriteLine("\nPlease select one of the following options: " +
                "\n1.Opnieuw berekenen \n2.Terug \n3.Afsluiten");

            string afterCalcOptionEntry;
            Regex optionSelectionRegex = new Regex("[^1-3]");
            do
            {
                afterCalcOptionEntry = Console.ReadLine();

                if (optionSelectionRegex.IsMatch(afterCalcOptionEntry) == false)
                {
                    Console.WriteLine("Please enter a valid number to redirect");
                }
            } while (optionSelectionRegex.IsMatch(afterCalcOptionEntry) == false);

            switch (int.Parse(afterCalcOptionEntry))
            {
                case 1:
                    ExecuteSelectedOption(optionEntry);
                    break;
                case 2:
                    HomeScreen();
                    var homeScreenOptionEntry = Console.ReadLine();
                    ExecuteSelectedOption(homeScreenOptionEntry);
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
