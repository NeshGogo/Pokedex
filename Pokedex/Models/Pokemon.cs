using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public List<PokemonType> Types { get; set; }

        [Display(Name = "Debilidades")]        
        public List<PokemonType> Weaknesses { get; set; }

        [Display(Name = "Habilidades")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public virtual ICollection<PokemonSkill> Skills { get; set; }
    }


     public enum sexType
    {
        Masculino,
        Femenino
    }
}
