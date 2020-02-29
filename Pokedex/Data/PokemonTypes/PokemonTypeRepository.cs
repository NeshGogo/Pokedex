using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.PokemonTypes
{
    public class PokemonTypeRepository : SqlRepository<PokemonType>, IPokemonTypeRepository
    {
        public PokemonTypeRepository(PokedexDBContext context) : base(context)
        {
        }
    }
}
