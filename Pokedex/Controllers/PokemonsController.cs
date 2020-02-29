using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokedexDBContext _context;

        public PokemonsController(PokedexDBContext context)
        {
            _context = context;
        }

        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            var pokedexDBContext = _context.Pokemons.Include(p => p.Region);
            return View(await pokedexDBContext.ToListAsync());
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .Include(p => p.Region).Include(p => p.PokemonSkills).Include(p=> p.PokemonTypes)
                .FirstOrDefaultAsync(m => m.PokemonId == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name");
            ViewData["Skills"] = new SelectList(_context.Skills, "SkillId", "Name");
            ViewData["Types"] = new SelectList(_context.Types, "TypeId", "Name");
            return View();
        }

        // POST: Pokemons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PokemonId,Name,Height,Weight,Sex,RegionId")] Pokemon pokemon, List<int> skills, List<int> types)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                var pokemonskills = new List<PokemonSkill>();
                var pokemontype = new List<PokemonType>();

                foreach (var item in skills)
                {
                    PokemonSkill pokemonSkill = new PokemonSkill
                    {
                        PokemonId =pokemon.PokemonId,
                        SkillId = item

                    };
                    pokemonskills.Add(pokemonSkill);
                }
                foreach (var item in types)
                {
                    PokemonType pokemonType = new PokemonType
                    {
                        PokemonId = pokemon.PokemonId,
                        TypeId = item

                    };
                    pokemontype.Add(pokemonType);
                }
                _context.PokemonSkills.AddRange(pokemonskills);
                _context.PokemonTypes.AddRange(pokemontype);
          
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name", pokemon.RegionId);
            return View(pokemon);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name", pokemon.RegionId);
            return View(pokemon);
        }

        // POST: Pokemons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PokemonId,Name,Height,Weight,Sex,RegionId")] Pokemon pokemon)
        {
            if (id != pokemon.PokemonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonExists(pokemon.PokemonId))
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
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "Name", pokemon.RegionId);
            return View(pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemons
                .Include(p => p.Region)
                .FirstOrDefaultAsync(m => m.PokemonId == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(e => e.PokemonId == id);
        }
    }
}
