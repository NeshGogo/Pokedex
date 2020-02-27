using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Data.Skills
{
    public class SkillRepository : SqlRepository<Skill>, ISkillRepository
    {
        public SkillRepository(PokedexDBContext context) : base(context)
        {
        }
    }
}
