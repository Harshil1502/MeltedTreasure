using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCandle.Data;
using MvcCandle.Models;

namespace MvcCandle.Controllers
{
    public class CandlesController : Controller
    {
        private readonly MvcCandleContext _context;

        public CandlesController(MvcCandleContext context)
        {
            _context = context;
        }

        // GET: Candles
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public async Task<IActionResult> Index(string candleShape, string searchString)
        {
            IQueryable<string> shapeQuery = from m in _context.Candle
                                            orderby m.Shape
                                            select m.Shape;

            var candles = from m in _context.Candle
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                candles = candles.Where(s => s.Fragrance.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(candleShape))
            {
                candles = candles.Where(x => x.Shape == candleShape);
            }

            var candleShapeVM = new CandleShapeViewModel
            {
                Shapes = new SelectList(await shapeQuery.Distinct().ToListAsync()),
                Candles = await candles.ToListAsync()
            };

            return View(candleShapeVM);
        }

        // GET: Candles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candle = await _context.Candle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candle == null)
            {
                return NotFound();
            }

            return View(candle);
        }

        // GET: Candles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fragrance,Color,Shape,Size,Price,Rating")] Candle candle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candle);
        }

        // GET: Candles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candle = await _context.Candle.FindAsync(id);
            if (candle == null)
            {
                return NotFound();
            }
            return View(candle);
        }

        // POST: Candles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fragrance,Color,Shape,Size,Price,Rating")] Candle candle)
        {
            if (id != candle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandleExists(candle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candle);
        }

        // GET: Candles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candle = await _context.Candle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candle == null)
            {
                return NotFound();
            }

            return View(candle);
        }

        // POST: Candles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candle = await _context.Candle.FindAsync(id);
            _context.Candle.Remove(candle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandleExists(int id)
        {
            return _context.Candle.Any(e => e.Id == id);
        }
    }
}
