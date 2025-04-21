using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IonLineMonitoringApp.Models;

namespace IonLineMonitoringApp.Controllers
{
    public class ShiftDataController : Controller
    {
        private readonly AppDbContext _context;

        public ShiftDataController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ShiftData
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ShiftDatas.Include(s => s.Line).Include(s => s.Product);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ShiftData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftData = await _context.ShiftDatas
                .Include(s => s.Line)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShiftDataId == id);
            if (shiftData == null)
            {
                return NotFound();
            }

            return View(shiftData);
        }

        // GET: ShiftData/Create
        public IActionResult Create()
        {
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: ShiftData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftDataId,LineId,ProductId,Shift,Date,LineSpeed,TotalProduction,TotalEnergy")] ShiftData shiftData)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(shiftData);
                await _context.SaveChangesAsync();
            //}
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", shiftData.LineId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", shiftData.ProductId);
            // return View(shiftData);
            return RedirectToAction(nameof(Index));

        }

        // GET: ShiftData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftData = await _context.ShiftDatas.FindAsync(id);
            if (shiftData == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", shiftData.LineId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", shiftData.ProductId);
            return View(shiftData);
        }

        // POST: ShiftData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftDataId,LineId,ProductId,Shift,Date,LineSpeed,TotalProduction,TotalEnergy")] ShiftData shiftData)
        {
            if (id != shiftData.ShiftDataId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(shiftData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftDataExists(shiftData.ShiftDataId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
         //   }
            ViewData["LineId"] = new SelectList(_context.Lines, "LineId", "LineId", shiftData.LineId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", shiftData.ProductId);
            return RedirectToAction(nameof(Index));

            //return View(shiftData);
        }

        // GET: ShiftData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftData = await _context.ShiftDatas
                .Include(s => s.Line)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShiftDataId == id);
            if (shiftData == null)
            {
                return NotFound();
            }

            return View(shiftData);
        }

        // POST: ShiftData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftData = await _context.ShiftDatas.FindAsync(id);
            if (shiftData != null)
            {
                _context.ShiftDatas.Remove(shiftData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftDataExists(int id)
        {
            return _context.ShiftDatas.Any(e => e.ShiftDataId == id);
        }
    }
}
