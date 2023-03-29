using System;
using System.Collections.Generic;

#nullable disable

namespace SEMANA10.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
    }
}
