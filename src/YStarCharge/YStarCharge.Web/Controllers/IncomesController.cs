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
    public class IncomesController : Controller
    {
        private readonly IIncomeRepository _Repository;

        public IncomesController(IIncomeRepository repository)
        {
            _Repository = repository;
        }

        // GET: Incomes
        public IActionResult Index()
        {
            return View(_Repository.GetIncomes().ToList());
        }

        // GET: Incomes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = _Repository.Get(id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IsSelected,CreateAt,Money,Remark")] Income income)
        {
            if (ModelState.IsValid)
            {
                _Repository.Add(income);
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        // GET: Incomes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = _Repository.Get(id);
            if (income == null)
            {
                return NotFound();
            }
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IsSelected,CreateAt,Money,Remark")] Income income)
        {
            if (id != income.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Repository.Update(income);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExists(income.Id))
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
            return View(income);
        }

        // GET: Incomes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = _Repository.Delete(id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var income = _Repository.Get(id);
            if (income != null)
            {
                _Repository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int id)
        {
            return _Repository.GetIncomes().Any(e => e.Id == id);
        }
    }
}
