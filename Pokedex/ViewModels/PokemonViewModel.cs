using Microsoft.AspNetCore.Http;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.ViewModels
{
    public class PokemonViewModel
    {
        [Key]
        public int PokemonId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "El maximo de caracteres es 50")]
        public string Name { get; set; }

        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public float Height { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public float Weight { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public SexTypeEnum Sex { get; set; }

        [Display(Name = "Region")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int RegionId { get; set; }

       
        public IFormFile Photo { get; set; }

        public List<int> Skills { get; set; }
        public List<int> Types { get; set; }

    }
}
