using MetricCalculator.Service;
using MetricCalculator.WebRazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricCalculator.WebRazor.Data
{
    public class MetricCalculatorDbContext : DbContext
    {
        public MetricCalculatorDbContext(DbContextOptions<MetricCalculatorDbContext> options) : base(options)
        {

        }

        public DbSet<Calculation> Logs { get; set; }
        public DbSet<CalculationType> CalculationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Calculation>().ToTable("Logs");

            builder.Entity<CalculationType>().ToTable("CalculationTypes");
            builder.Entity<CalculationType>().HasData(GetAllCalculationTypes());

        }

        private static List<CalculationType> GetAllCalculationTypes()
        {
            List<CalculationType> methodList = new();
            for (int i = 0; i < typeof(Calculate).GetMethods().Count(); i++)
            {
                methodList.Add(new CalculationType { Id = i + 1, Name = typeof(Calculate).GetMethods()[i].Name });
            }
            methodList.RemoveRange(methodList.Count() - 4, 4);
            return methodList;

        }
    }
}
