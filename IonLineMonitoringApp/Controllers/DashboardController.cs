using IonLineMonitoringApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IonLineMonitoringApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> MonthlyKPIs()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var kpiData = await _context.ShiftDatas
                .Where(s => s.Date.Month == currentMonth && s.Date.Year == currentYear)
                .Include(s => s.Line)
                .Include(s => s.Product)
                .GroupBy(s => new { s.Line.LineName, s.Product.ProductName })
                .Select(g => new MonthlyKPIViewModel
                {
                    LineName = g.Key.LineName,
                    ProductName = g.Key.ProductName,
                    TotalProduction = g.Sum(x => x.TotalProduction),
                    TotalEnergy = g.Sum(x => x.TotalEnergy),
                    Month = currentMonth,
                    Year = currentYear
                })
                .ToListAsync();

            return View(kpiData);
        }
        public IActionResult Index()
        {
            var shiftDataList = _context.ShiftDatas
                .Include(s => s.Line)
                .Include(s => s.Product)
                .ToList(); // return full entity, not anonymous

            return View(shiftDataList);
        }



    }
}
