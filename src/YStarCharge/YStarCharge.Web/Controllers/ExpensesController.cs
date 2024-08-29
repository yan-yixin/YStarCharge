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
        private readonly IExpensesRepository _Repository;

        public ExpensesController(IExpensesRepository expenses)
        {
            _Repository = expenses;
        }

        public IActionResult Index()
        {
            return View(_Repository.GetList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = _Repository.Get(id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CreateAt,Money,To,Remark")] Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _Repository.Add(expenses);
                return RedirectToAction(nameof(Index));
            }
            return View(expenses);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = _Repository.Get(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return View(expenses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CreateAt,Money,To,Remark")] Expenses expenses)
        {
            if (id != expenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Repository.Update(expenses);
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenses = _Repository.Get(id);
            if (expenses == null)
            {
                return NotFound();
            }

            return View(expenses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var expenses = _Repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExpensesExists(int id)
        {
            return _Repository.GetList().Any(e => e.Id == id);
        }
    }
}
