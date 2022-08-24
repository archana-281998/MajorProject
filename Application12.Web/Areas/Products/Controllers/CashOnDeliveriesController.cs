using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application12.Web.Data;
using Application12.Web.Models;

namespace Application12.Web.Areas.Products.Controllers
{
    [Area("Products")]
    public class CashOnDeliveriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CashOnDeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products/CashOnDeliveries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CashOnDeliveries.Include(c => c.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/CashOnDeliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashOnDelivery = await _context.CashOnDeliveries
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashOnDelivery == null)
            {
                return NotFound();
            }

            return View(cashOnDelivery);
        }

        // GET: Products/CashOnDeliveries/Create
        public IActionResult Create()
        {
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName");
            return View();
        }

        // POST: Products/CashOnDeliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,Amount,OrderNumber")] CashOnDelivery cashOnDelivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashOnDelivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", cashOnDelivery.OrderNumber);
            return View(cashOnDelivery);
        }

        // GET: Products/CashOnDeliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashOnDelivery = await _context.CashOnDeliveries.FindAsync(id);
            if (cashOnDelivery == null)
            {
                return NotFound();
            }
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", cashOnDelivery.OrderNumber);
            return View(cashOnDelivery);
        }

        // POST: Products/CashOnDeliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,Amount,OrderNumber")] CashOnDelivery cashOnDelivery)
        {
            if (id != cashOnDelivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashOnDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashOnDeliveryExists(cashOnDelivery.Id))
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
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", cashOnDelivery.OrderNumber);
            return View(cashOnDelivery);
        }

        // GET: Products/CashOnDeliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashOnDelivery = await _context.CashOnDeliveries
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashOnDelivery == null)
            {
                return NotFound();
            }

            return View(cashOnDelivery);
        }

        // POST: Products/CashOnDeliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashOnDelivery = await _context.CashOnDeliveries.FindAsync(id);
            _context.CashOnDeliveries.Remove(cashOnDelivery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashOnDeliveryExists(int id)
        {
            return _context.CashOnDeliveries.Any(e => e.Id == id);
        }
    }
}
