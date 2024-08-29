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

            var income = _Repository.Get(id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CreateAt,Money,Remark")] Income income)
        {
            if (ModelState.IsValid)
            {
                _Repository.Add(income);

                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CreateAt,Money,Remark")] Income income)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _Repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int? id)
        {
            return _Repository.GetList().FirstOrDefault(x=> x.Id == id) != null;
        }
    }
}
