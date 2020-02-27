using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonSkill
    {
        [Key]
        public int PokemonSkillId { get; set; }

        [MaxLength(70, ErrorMessage = "El maximo de caracteres permitidos es de 70")]
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        public  virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}
