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
    public class OnlinePaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OnlinePaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products/OnlinePayments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OnlinePayments.Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/OnlinePayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePayment = await _context.OnlinePayments
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (onlinePayment == null)
            {
                return NotFound();
            }

            return View(onlinePayment);
        }

        // GET: Products/OnlinePayments/Create
        public IActionResult Create()
        {
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName");
            return View();
        }

        // POST: Products/OnlinePayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,PaymentViaPhonePe,Location,Amount,OrderNumber")] OnlinePayment onlinePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onlinePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", onlinePayment.OrderNumber);
            return View(onlinePayment);
        }

        // GET: Products/OnlinePayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePayment = await _context.OnlinePayments.FindAsync(id);
            if (onlinePayment == null)
            {
                return NotFound();
            }
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", onlinePayment.OrderNumber);
            return View(onlinePayment);
        }

        // POST: Products/OnlinePayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,PaymentViaPhonePe,Location,Amount,OrderNumber")] OnlinePayment onlinePayment)
        {
            if (id != onlinePayment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onlinePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnlinePaymentExists(onlinePayment.PaymentId))
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
            ViewData["OrderNumber"] = new SelectList(_context.Orders, "OrderNumber", "OrderProductName", onlinePayment.OrderNumber);
            return View(onlinePayment);
        }

        // GET: Products/OnlinePayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onlinePayment = await _context.OnlinePayments
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (onlinePayment == null)
            {
                return NotFound();
            }

            return View(onlinePayment);
        }

        // POST: Products/OnlinePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onlinePayment = await _context.OnlinePayments.FindAsync(id);
            _context.OnlinePayments.Remove(onlinePayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnlinePaymentExists(int id)
        {
            return _context.OnlinePayments.Any(e => e.PaymentId == id);
        }
    }
}
