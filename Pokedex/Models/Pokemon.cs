using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Pokemon
    {
        [Key]
        public int PokemonId { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="Este campo es requerido")]
        [MaxLength(50, ErrorMessage ="El maximo de caracteres es 50")]
        public string Name { get; set; }      

        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public float Height { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public float Weight { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public sexType Sex { get; set; }
        
        [Display(Name = "Region")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int RegionId { get; set; }


        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
        public virtual ICollection<PokemonSkill> PokemonSkills { get; set; }
        public virtual Region Region { get; set; }

    }


     public enum sexType
    {
        Masculino,
        Femenino
    }
}
