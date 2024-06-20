using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafeChest.Data;
using SafeChest.Models;

namespace SafeChest
{
    public class SafeChestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SafeChestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafeChests
        public async Task<IActionResult> Index()
        {
            return View(await _context.SafeChest.ToListAsync());
        }

        // GET: SafeChests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safeChest = await _context.SafeChest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safeChest == null)
            {
                return NotFound();
            }

            return View(safeChest);
        }

        // GET: SafeChests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SafeChests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Value,Picture,Date")] HouseHoldGoods houseHoldGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(safeChest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(safeChest);
        }

        // GET: SafeChests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safeChest = await _context.SafeChest.FindAsync(id);
            if (safeChest == null)
            {
                return NotFound();
            }
            return View(safeChest);
        }

        // POST: SafeChests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Value,Picture,Date")] SafeChest safeChest)
        {
            if (id != safeChest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safeChest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafeChestExists(safeChest.Id))
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
            return View(safeChest);
        }

        // GET: SafeChests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safeChest = await _context.SafeChest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (safeChest == null)
            {
                return NotFound();
            }

            return View(safeChest);
        }

        // POST: SafeChests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var safeChest = await _context.SafeChest.FindAsync(id);
            if (safeChest != null)
            {
                _context.SafeChest.Remove(safeChest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafeChestExists(int id)
        {
            return _context.SafeChest.Any(e => e.Id == id);
        }
    }
}
