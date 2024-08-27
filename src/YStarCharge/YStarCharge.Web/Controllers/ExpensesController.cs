using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YStarCharge.Web.Data;
using YStarCharge.Web.Models;

namespace YStarCharge.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly SqlDBContext _context;

        public ExpensesController(SqlDBContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsSelected,CreateAt,Money,To,Remark")] Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenses);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return View(expenses);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsSelected,CreateAt,Money,To,Remark")] Expenses expenses)
        {
            if (id != expenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpensesExists(expenses.Id))
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
            return View(expenses);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses != null)
            {
                _context.Expenses.Remove(expenses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
