using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricCalculator.Service;
using MetricCalculator.WebRazor.Data;
using MetricCalculator.WebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MetricCalculator.Web.Views.Home
{
    public class CalculateRazorModel : PageModel
    {
        private readonly MetricCalculatorDbContext dbContext;
        private readonly Calculate calculate;

        public CalculateRazorModel(MetricCalculatorDbContext dbContext, Calculate calculate)
        {
            this.dbContext = dbContext;
            this.calculate = calculate;
        }

        [BindProperty]
        public Calculation Calculation { get; set; }

        public IActionResult OnGet()
        {
            Calculation = new();
            ViewData["CalculationTypes"] = dbContext.CalculationTypes.ToList();
            return Page();
        }

        public IActionResult OnGet(double afterValue)
        {
            Calculation = new();
            Calculation.AfterValue = afterValue;
            ViewData["CalculationTypes"] = dbContext.CalculationTypes.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Calculation != null)
            {
                switch (Calculation.CalculationTypeId)
                {
                    case 1:
                        Calculation.AfterValue = calculate.MeterToCentimeter(Calculation.BeforeValue, false);
                        break;
                    case 2:
                        Calculation.AfterValue = calculate.CentimeterToMeter(Calculation.BeforeValue, false);
                        break;
                    case 3:
                        Calculation.AfterValue = calculate.CentimeterToMillimeter(Calculation.BeforeValue, false);
                        break;
                    case 4:
                        Calculation.AfterValue = calculate.MillimeterToCentimeter(Calculation.BeforeValue, false);
                        break;
                    case 5:
                        Calculation.AfterValue = calculate.MeterToInch(Calculation.BeforeValue, false);
                        break;
                    case 6:
                        Calculation.AfterValue = calculate.InchToMeter(Calculation.BeforeValue, false);
                        break;
                    default:
                        break;
                }

                Calculation.DateTimeCalculated = DateTime.Now;

                dbContext.Logs.Add(Calculation);
                if (dbContext.SaveChanges() > 0)
                {
                    return OnGet(Calculation.AfterValue);
                }
            }

            return Page();
        }

        //public IActionResult Calculate(double afterValue)
        //{
        //    ViewBag.CalculationTypes = _dbContext.CalculationTypes.ToList();
        //    var model = new Calculation { AfterValue = afterValue };
        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Calculate(Calculation calculation)
        //{
        //    if (calculation != null)
        //    {
        //        switch (calculation.CalculationTypeId)
        //        {
        //            case 1:
        //                calculation.AfterValue = _Calculate.MeterToCentimeter(calculation.BeforeValue, false);
        //                break;
        //            case 2:
        //                calculation.AfterValue = _Calculate.CentimeterToMeter(calculation.BeforeValue, false);
        //                break;
        //            case 3:
        //                calculation.AfterValue = _Calculate.CentimeterToMillimeter(calculation.BeforeValue, false);
        //                break;
        //            case 4:
        //                calculation.AfterValue = _Calculate.MillimeterToCentimeter(calculation.BeforeValue, false);
        //                break;
        //            case 5:
        //                calculation.AfterValue = _Calculate.MeterToInch(calculation.BeforeValue, false);
        //                break;
        //            case 6:
        //                calculation.AfterValue = _Calculate.InchToMeter(calculation.BeforeValue, false);
        //                break;
        //            default:
        //                break;
        //        }

        //        calculation.DateTimeCalculated = DateTime.Now;

        //        _dbContext.Logs.Add(calculation);
        //        if (_dbContext.SaveChanges() > 0)
        //        {
        //            return Calculate(calculation.AfterValue);
        //        }
        //    }

        //    return Calculate();
        //}
    }
}
