using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [MaxLength(70, ErrorMessage = "El maximo de caracteres permitidos es de 70")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Color")]
        public ColorsEnum Colors { get; set; }
    }

    

}
