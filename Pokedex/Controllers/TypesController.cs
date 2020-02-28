using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;
using Pokedex.Services.Types;

namespace Pokedex.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: Types
        public async Task<IActionResult> Index()
        {
            return View(await _typeService.GetAll());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _typeService.GetById(id);
                
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,Name")] Pokedex.Models.Type @type)
        {
            if (ModelState.IsValid)
            {
               await _typeService.Insert(@type);
                
                return RedirectToAction(nameof(Index));
            }
            return View(@type);
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _typeService.GetById(id);
            if (@type == null)
            {
                return NotFound();
            }
            return View(@type);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,Name")] Pokedex.Models.Type @type)
        {
            if (id != @type.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _typeService.Update(@type);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TypeExists(@type.TypeId))
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
            return View(@type);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _typeService.GetById(id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @type = await _typeService.GetById(id);
            await _typeService.Delete(@type);
           
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TypeExists(int id)
        {
            var type = await _typeService.GetById(id);
            if (type != null)
                return true;
            return false;
        }
    }
}
