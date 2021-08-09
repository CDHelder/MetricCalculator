using MetricCalculator.Service;
using MetricCalculator.Web.Data;
using MetricCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MetricCalculatorDbContext _dbContext;
        private readonly Calculate _Calculate;

        public HomeController(MetricCalculatorDbContext dbContext, Calculate calculate)
        {
            this._dbContext = dbContext;
            this._Calculate = calculate;
        }

        public IActionResult Calculate()
        {
            ViewBag.CalculationTypes = _dbContext.CalculationTypes.ToList();
            return View();
        }

        //public IActionResult Calculate(double afterValue)
        //{
        //    ViewBag.CalculationTypes = _dbContext.CalculationTypes.ToList();
        //    var model = new Calculation { AfterValue = afterValue };
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Calculate(Calculation calculation)
        {
            if (calculation != null)
            {
                switch (calculation.CalculationTypeId)
                {
                    case 1:
                        calculation.AfterValue = _Calculate.MeterToCentimeter(calculation.BeforeValue, false);
                        break;
                    case 2:
                        calculation.AfterValue = _Calculate.CentimeterToMeter(calculation.BeforeValue, false);
                        break;
                    case 3:
                        calculation.AfterValue = _Calculate.CentimeterToMillimeter(calculation.BeforeValue, false);
                        break;
                    case 4:
                        calculation.AfterValue = _Calculate.MillimeterToCentimeter(calculation.BeforeValue, false);
                        break;
                    case 5:
                        calculation.AfterValue = _Calculate.MeterToInch(calculation.BeforeValue, false);
                        break;
                    case 6:
                        calculation.AfterValue = _Calculate.InchToMeter(calculation.BeforeValue, false);
                        break;
                    default:
                        break;
                }

                calculation.DateTimeCalculated = DateTime.Now;

                _dbContext.Logs.Add(calculation);
                if (_dbContext.SaveChanges() > 0)
                {
                    //return Calculate(calculation.AfterValue);
                }
            }

            return Calculate();
        }

        public IActionResult LogsIndex()
        {
            var model = _dbContext.Logs.ToList();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
