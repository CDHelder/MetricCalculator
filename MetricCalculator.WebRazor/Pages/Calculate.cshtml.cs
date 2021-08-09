using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MetricCalculator.WebRazor.Data;
using MetricCalculator.WebRazor.Models;
using MetricCalculator.Service;

namespace MetricCalculator.WebRazor.Pages
{
    public class CalculateModel : PageModel
    {
        private readonly MetricCalculatorDbContext _context;
        private readonly Calculate calculate;

        public CalculateModel(MetricCalculatorDbContext context, Calculate calculate)
        {
            _context = context;
            this.calculate = calculate;
        }

        public IActionResult OnGet()
        {
            ViewData["CalculationTypeId"] = new SelectList(_context.CalculationTypes.ToList(), "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Calculation Calculation { get; set; }

        [TempData]
        public string LastCalculationAfter { get; set; }
        [TempData]
        public string LastCalculationBefore { get; set; }
        [TempData]
        public string LastCalculationTypeName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Calculation == null)
            {
                return Page();
            }

            CalculateAfterValue();

            _context.Logs.Add(Calculation);
            await _context.SaveChangesAsync();

            LastCalculationAfter = Calculation.AfterValue.ToString();
            LastCalculationBefore = Calculation.BeforeValue.ToString();
            LastCalculationTypeName = _context.CalculationTypes.FirstOrDefault(u => u.Id == Calculation.CalculationTypeId).Name;
            return RedirectToPage("/Calculate");
        }

        private void CalculateAfterValue()
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
        }
    }
}
