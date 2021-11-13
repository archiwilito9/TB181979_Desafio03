using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TB181979_Desafio03.Models
{
    public partial class producto
    {
        public int id { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un nombre.")]
        public String NombreProducto { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Debe ingresar un valor mayor a cero.")]
        public int Existencias { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Precio { get; set; }

        
    }
}