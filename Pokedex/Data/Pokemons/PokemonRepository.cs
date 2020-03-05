using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Pokemons
{
    public class PokemonRepository : SqlRepository<Pokemon>, IPokemonRepository
    {
        private readonly PokedexDBContext context;

        public PokemonRepository(PokedexDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetAllWithRegion()
        {
            return await Task.FromResult(context.Pokemons.Include(p => p.Region));
        }

        public async Task<Pokemon> GetPokemonFull(int id)
        {
            return await context.Pokemons.Include(p => p.Region).Include(p => p.PokemonSkills).ThenInclude(ps => ps.Skill)
                .Include(p => p.PokemonTypes).ThenInclude(pt => pt.Type).FirstOrDefaultAsync(p => p.PokemonId == id);
              
        }
    }
}
