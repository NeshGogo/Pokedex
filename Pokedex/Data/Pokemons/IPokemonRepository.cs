using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Pokemons
{
    public interface IPokemonRepository: IRepository<Pokemon>
    {
        public Task<Pokemon> GetPokemonFull(int id);
        public Task<IEnumerable<Pokemon>> GetAllWithRegion();
    }
}
