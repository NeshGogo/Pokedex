using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonType
    {

        public int PokemonId { get; set; }
        public int TypeId { get; set; }

        public virtual Pokemon Pokemon { get; set; }
        public virtual Type Type { get; set; }

    }
}
