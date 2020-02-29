﻿using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.PokemonSkills
{
    public class PokemonSkillRepository : SqlRepository<PokemonSkill>, IPokemonSkillRepository
    {
        public PokemonSkillRepository(PokedexDBContext context) : base(context)
        {
        }
    }
}