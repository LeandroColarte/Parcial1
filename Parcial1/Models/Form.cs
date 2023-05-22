using System;
using System.Collections.Generic;

namespace Parcial1.Models
{
    public partial class Form
    {
        public int IdForm { get; set; }
        public string? Cuit { get; set; }
        public string? RazonSocial { get; set; }
        public string? Domicilio { get; set; }
        public string? Email { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? oCategorium { get; set; }
    }
}