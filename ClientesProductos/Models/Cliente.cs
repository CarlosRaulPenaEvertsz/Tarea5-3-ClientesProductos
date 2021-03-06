//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientesProductos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente
    {
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El Apellido es Obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La Direcci�n es Obligatoria")]
        public string Direccion { get; set; }
        [EmailAddress(ErrorMessage = "El Email es Obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Tel�fono es Obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Celular es Obligatorio")]
        public string Movil { get; set; }
        public string ImageUrl { get; set; }
    }
}
