﻿using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Pokemons
{
    public class PokemonRepository : SqlRepository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(PokedexDBContext context) : base(context)
        {
        }
    }
}
