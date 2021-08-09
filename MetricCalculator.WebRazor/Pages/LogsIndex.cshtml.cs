using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MetricCalculator.WebRazor.Data;
using MetricCalculator.WebRazor.Models;

namespace MetricCalculator.WebRazor.Pages
{
    public class LogsIndexModel : PageModel
    {
        private readonly MetricCalculatorDbContext _context;

        public LogsIndexModel(MetricCalculatorDbContext context)
        {
            _context = context;
        }

        public IList<Calculation> Calculation { get;set; }

        public async Task OnGetAsync()
        {
            Calculation = await _context.Logs
                .Include(c => c.Type).ToListAsync();
        }
    }
}
