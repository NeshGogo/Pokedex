using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pokedex.Data;
using Pokedex.Data.Pokemons;
using Pokedex.Data.PokemonSkills;
using Pokedex.Data.PokemonTypes;
using Pokedex.Models;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pokedex.Services.Pokemons
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly PokedexDBContext _context;
        private readonly IPokemonSkillRepository _pokemonSkillRepository;
        private readonly IPokemonTypeRepository _pokemonTypeRepository;

        public PokemonService(IPokemonRepository pokemonRepository, PokedexDBContext context, 
                    IPokemonSkillRepository pokemonSkillRepository, IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonSkillRepository = pokemonSkillRepository;
            _pokemonTypeRepository = pokemonTypeRepository;
            _context = context;
        }
        public async Task<List<Pokemon>> GetAllWithRegion()
        {
            var pokemons = await _pokemonRepository.GetAllWithRegion();
            return pokemons.ToList();

        }
        public async Task<bool> Delete(Pokemon pokemon)
        {
            return await _pokemonRepository.Delete(pokemon);
        }

        public async Task<IEnumerable<Pokemon>> GetAll()
        {
            return await _pokemonRepository.GetAll();
        }

        public async Task<Pokemon> GetById(int? id)
        {
            if (!id.HasValue)
                return null;
            return await _pokemonRepository.GetById(id.Value);
        }
        public async Task<Pokemon> GetByIdFull(int? id)
        {
            if (!id.HasValue)
                return null;
            var pokemon = await _pokemonRepository.GetPokemonFull(id.Value);
   

            return pokemon;
        }

        public async Task<Pokemon> Insert(Pokemon pokemon, List<int> skills, List<int> types)
        {
            var pokemonskills = new List<PokemonSkill>();
            var pokemontypes = new List<PokemonType>();
            var pokemonresult = await _pokemonRepository.Insert(pokemon);
            skills.ForEach(a => {
                PokemonSkill pokemonSkill = new PokemonSkill
                {
                    PokemonId = pokemonresult.PokemonId,
                    SkillId = a
                };
                pokemonskills.Add(pokemonSkill);
            });
            types.ForEach(a => {
                PokemonType pokemonType = new PokemonType
                {
                    PokemonId = pokemonresult.PokemonId,
                    TypeId = a
                };
                pokemontypes.Add(pokemonType);
            });
           
            await _pokemonSkillRepository.InsertRage(pokemonskills);
            await _pokemonTypeRepository.InsertRage(pokemontypes);
            return pokemonresult;
        }

        public async Task<Pokemon> Update(Pokemon pokemon, List<int> skills, List<int> types)
        {
            if (pokemon.PhotoPath == null)
            {
                var result = await _context.Pokemons.FindAsync(pokemon.PokemonId);
                pokemon.PhotoPath = result.PhotoPath;
            }
            var pokemonskills = new List<PokemonSkill>();
            var pokemontypes = new List<PokemonType>();
            skills.ForEach(a => {
                PokemonSkill pokemonSkill = new PokemonSkill
                {
                    PokemonId = pokemon.PokemonId,
                    SkillId = a,
                    Pokemon = pokemon
                };
                pokemonskills.Add(pokemonSkill);
            });
            types.ForEach(a => {
                PokemonType pokemonType = new PokemonType
                {
                    PokemonId = pokemon.PokemonId,
                    TypeId = a,
                    Pokemon = pokemon
                };
                pokemontypes.Add(pokemonType);
            });

            var resultpokemon = await _pokemonRepository.Update(pokemon);


            var resul1 = await _pokemonSkillRepository.DeleteRange(await _pokemonSkillRepository.Where(p=> p.PokemonId == pokemon.PokemonId));
            var resul2 = await _pokemonTypeRepository.DeleteRange(await _pokemonTypeRepository.Where(p => p.PokemonId == pokemon.PokemonId));
            var resul3 = await _pokemonSkillRepository.InsertRage(pokemonskills);
            var resul4 = await _pokemonTypeRepository.InsertRage(pokemontypes);



            return resultpokemon;
        }

        public async Task<IEnumerable<Pokemon>> Where(Expression<Func<Pokemon, bool>> filter)
        {
            return await _pokemonRepository.Where(filter);
        }
    }
}
