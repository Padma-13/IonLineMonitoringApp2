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
    public class LineController : Controller
    {
        private readonly AppDbContext _context;

        public LineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Line
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lines.ToListAsync());
        }

        // GET: Line/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // GET: Line/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Line/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineId,LineName")] Line line)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(line);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(line);
        }

        // GET: Line/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }
            return View(line);
        }

        // POST: Line/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineId,LineName")] Line line)
        {
            if (id != line.LineId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(line);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineExists(line.LineId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            //return RedirectToAction(nameof(Index));
            //}
            //return View(line);
            return RedirectToAction(nameof(Index));

        }

        // GET: Line/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var line = await _context.Lines
                .FirstOrDefaultAsync(m => m.LineId == id);
            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        // POST: Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var line = await _context.Lines.FindAsync(id);
            if (line != null)
            {
                _context.Lines.Remove(line);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineExists(int id)
        {
            return _context.Lines.Any(e => e.LineId == id);
        }
    }
}
