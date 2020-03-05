using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;
using Pokedex.Services.Pokemons;
using Pokedex.Services.Regions;
using Pokedex.Services.Skills;
using Pokedex.Services.Types;
using Pokedex.ViewModels;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        
        private readonly IPokemonService _pokemonService;
        private readonly ISkillService _skillService;
        private readonly IRegionService _regionService;
        private readonly ITypeService _typeService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PokemonsController(IPokemonService pokemonService, ISkillService skillService, IRegionService regionService, ITypeService typeService, IWebHostEnvironment hostingEnvironment)
        {
            _pokemonService = pokemonService;
            _skillService = skillService;
            _regionService = regionService;
            _typeService = typeService;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            var pokemons = await _pokemonService.GetAllWithRegion();
            return View(pokemons);
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pokemon = await _pokemonService.GetByIdFull(id);           

            
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // GET: Pokemons/Create
        public async Task<IActionResult> Create()
        {
            ViewData["RegionId"] = new SelectList(await _regionService.GetAll(), "RegionId", "Name");
            ViewData["Skills"] = new SelectList(await _skillService.GetAll(), "SkillId", "Name");
            ViewData["Types"] = new SelectList(await _typeService.GetAll(), "TypeId", "Name");
            return View("Form");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PokemonViewModel pokemon)
        {
           
            if (ModelState.IsValid)
            {
                string photoPath = await UploadedFileProcess(pokemon.Photo);
                Pokemon pokemon1 = new Pokemon()
                {
                    Name = pokemon.Name,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight,
                    RegionId = pokemon.RegionId,
                    Sex = pokemon.Sex,
                    PhotoPath = photoPath
                };
               await  _pokemonService.Insert(pokemon1, pokemon.Skills, pokemon.Types);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(await _regionService.GetAll(), "RegionId", "Name");
            ViewData["Skills"] = new MultiSelectList(await _skillService.GetAll(), "SkillId", "Name");
            ViewData["Types"] = new MultiSelectList(await _typeService.GetAll(), "TypeId", "Name");
            return View("Form",pokemon);
        }

        // GET: Pokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var pokemon = await _pokemonService.GetByIdFull(id);
            
            if (pokemon == null)
            {
                return NotFound();
            }
            var pokemonViewModel = new PokemonViewModel
            {
                Height = pokemon.Height,
                Name = pokemon.Name,
                PokemonId = pokemon.PokemonId,
                RegionId = pokemon.RegionId,
                Sex = pokemon.Sex,
                Weight = pokemon.Weight,
                Skills = new List<int>(),
                Types = new List<int>()
            };
            
            pokemon.PokemonSkills.ForEach(p => { pokemonViewModel.Skills.Add(p.SkillId); });
            pokemon.PokemonTypes.ForEach(p => { pokemonViewModel.Types.Add(p.TypeId); });

            ViewData["RegionId"] = new SelectList(await _regionService.GetAll(), "RegionId", "Name", pokemon.RegionId);
            ViewData["Skills"] = new MultiSelectList(await _skillService.GetAll(), "SkillId", "Name", pokemonViewModel.Skills);
            ViewData["Types"] = new MultiSelectList(await _typeService.GetAll(), "TypeId", "Name", pokemonViewModel.Types);

            return View("Form", pokemonViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PokemonViewModel pokemon)
        {
            if (id != pokemon.PokemonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && pokemon.Skills != null && pokemon.Types != null)
            {
                try
                {
                    string photoPath = await UploadedFileProcess(pokemon.Photo);
                    Pokemon pokemon1 = new Pokemon()
                    {
                        PokemonId = pokemon.PokemonId,
                        Name = pokemon.Name,
                        Height = pokemon.Height,
                        Weight = pokemon.Weight,
                        RegionId = pokemon.RegionId,
                        Sex = pokemon.Sex,
                        PhotoPath = photoPath
                    };                   
                   
                    await _pokemonService.Update(pokemon1, pokemon.Skills, pokemon.Types);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PokemonExists(pokemon.PokemonId))
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
            if (pokemon.Skills == null)            
                ModelState.AddModelError(string.Empty, "Debe seleccionar almenos 1 habilidad.");
            if (pokemon.Types == null)
                ModelState.AddModelError(string.Empty, "Debe seleccionar almenos 1 tipo.");

           
            ViewData["RegionId"] = new SelectList(await _regionService.GetAll(), "RegionId", "Name", pokemon.RegionId);
            ViewData["Skills"] = new MultiSelectList(await _skillService.GetAll(), "SkillId", "Name", pokemon.Skills);
            ViewData["Types"] = new MultiSelectList(await _typeService.GetAll(), "TypeId", "Name", pokemon.Types);
            return View("Form",pokemon);
        }

        // GET: Pokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemon = await _pokemonService.GetByIdFull(id);
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
            var pokemon = await _pokemonService.GetById(id);
             await _pokemonService.Delete(pokemon);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PokemonExists(int id)
        {
            var pokemon = await _pokemonService.GetById(id);
            if (pokemon != null)
                return true;
            return false;
        }
        public async  Task<string> UploadedFileProcess( IFormFile photo)
        {
            string uniqueFileName = null;
            if (photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "css","PokemonImg");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                
                return uniqueFileName;
            }


            return uniqueFileName;





        }
    }
}
