using Pokedex.Data.Pokemons;
using Pokedex.Data.PokemonSkills;
using Pokedex.Data.PokemonTypes;
using Pokedex.Models;
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
        private readonly IPokemonSkillRepository _pokemonSkillRepository;
        private readonly IPokemonTypeRepository _pokemonTypeRepository;

        public PokemonService(IPokemonRepository pokemonRepository, IPokemonSkillRepository pokemonSkillRepository , IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonSkillRepository = pokemonSkillRepository;
            _pokemonTypeRepository = pokemonTypeRepository;
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

        public async Task<Pokemon> Insert(Pokemon pokemon)
        {
            return await _pokemonRepository.Insert(pokemon);
        }

        public async Task<Pokemon> Update(Pokemon pokemon)
        {
            return await _pokemonRepository.Update(pokemon);
        }

        public async Task<IEnumerable<Pokemon>> Where(Expression<Func<Pokemon, bool>> filter)
        {
            return await _pokemonRepository.Where(filter);
        }
    }
}
