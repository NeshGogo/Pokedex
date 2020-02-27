using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonSkill
    {
        public int PokemonSkillId { get; set; }
        public int PokemonId { get; set; }
        public int SkillId { get; set; }

        
        public  virtual Pokemon Pokemon { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
