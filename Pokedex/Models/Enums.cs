using System;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models{

    public enum ColorsEnum
    {
        [Display(Name = "Azul")]
        primary,
        [Display(Name = "Gris")]
        secondary,
        [Display(Name = "Verde")]
        success,
        [Display(Name = "Rojo")]
        danger,
        [Display(Name = "Amarillo")]
        warning,
        [Display(Name = "Verde Turquesa")]
        info,
        [Display(Name = "Blanco opaco")]
        light,
        [Display(Name = "Negro")]
        dark,
        [Display(Name = "Blanco")]
        white,
    }
    public enum SexTypeEnum
    {
        Masculino,
        Femenino
    }
}