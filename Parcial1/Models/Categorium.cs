using System;
using System.Collections.Generic;

namespace Parcial1.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Forms = new HashSet<Form>();
        }

        public int IdCategoria { get; set; }
        public string TiposCategoria { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}
