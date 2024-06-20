using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafeChest.Data;
using SafeChest.Models;

namespace SafeChest.Controllers
{
    public class HouseHoldGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseHoldGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseHoldGoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.HouseHoldGoods.ToListAsync());
        }

        // GET: HouseHoldGoods/ShowSearchForm()
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: HouseHoldGoods/ShowSearchForm()
        public async Task<IActionResult> ShowSearchResults(String ItemName)
        {
            return View("Index", await _context.HouseHoldGoods.Where(j => j.Item.Contains(ItemName)).ToListAsync());
        }

        // GET: HouseHoldGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseHoldGoods = await _context.HouseHoldGoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (houseHoldGoods == null)
            {
                return NotFound();
            }

            return View(houseHoldGoods);
        }

        // GET: HouseHoldGoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseHoldGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Value,Image,DatePurchased")] HouseHoldGoods houseHoldGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseHoldGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(houseHoldGoods);
        }

        // GET: HouseHoldGoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseHoldGoods = await _context.HouseHoldGoods.FindAsync(id);
            if (houseHoldGoods == null)
            {
                return NotFound();
            }
            return View(houseHoldGoods);
        }

        // POST: HouseHoldGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Value,Image,DatePurchased")] HouseHoldGoods houseHoldGoods)
        {
            if (id != houseHoldGoods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseHoldGoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseHoldGoodsExists(houseHoldGoods.Id))
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
            return View(houseHoldGoods);
        }

        // GET: HouseHoldGoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseHoldGoods = await _context.HouseHoldGoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (houseHoldGoods == null)
            {
                return NotFound();
            }

            return View(houseHoldGoods);
        }

        // POST: HouseHoldGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var houseHoldGoods = await _context.HouseHoldGoods.FindAsync(id);
            if (houseHoldGoods != null)
            {
                _context.HouseHoldGoods.Remove(houseHoldGoods);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseHoldGoodsExists(int id)
        {
            return _context.HouseHoldGoods.Any(e => e.Id == id);
        }
    }
}
