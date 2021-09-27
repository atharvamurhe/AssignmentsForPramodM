using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstCoreAppUsingMVC.Data;
using MyFirstCoreAppUsingMVC.Models;

namespace MyFirstCoreAppUsingMVC.Controllers
{
    public class EnumTestsController : Controller
    {
        private readonly MyFirstCoreAppUsingMVCContext _context;

        public EnumTestsController(MyFirstCoreAppUsingMVCContext context)
        {
            _context = context;
        }

        // GET: EnumTests
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnumTest.ToListAsync());
        }

        // GET: EnumTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumTest = await _context.EnumTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enumTest == null)
            {
                return NotFound();
            }

            return View(enumTest);
        }

        // GET: EnumTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnumTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namw,GetGender")] EnumTest enumTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enumTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enumTest);
        }

        // GET: EnumTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumTest = await _context.EnumTest.FindAsync(id);
            if (enumTest == null)
            {
                return NotFound();
            }
            return View(enumTest);
        }

        // POST: EnumTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namw,GetGender")] EnumTest enumTest)
        {
            if (id != enumTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enumTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnumTestExists(enumTest.Id))
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
            return View(enumTest);
        }

        // GET: EnumTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumTest = await _context.EnumTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enumTest == null)
            {
                return NotFound();
            }

            return View(enumTest);
        }

        // POST: EnumTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enumTest = await _context.EnumTest.FindAsync(id);
            _context.EnumTest.Remove(enumTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnumTestExists(int id)
        {
            return _context.EnumTest.Any(e => e.Id == id);
        }
    }
}
