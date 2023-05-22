using Microsoft.AspNetCore.Mvc.Rendering;

namespace Parcial1.Models.ViewModels
{
    public class FormularioVM
    {
        public Form oForm { get; set; }
        
        public List<SelectListItem>? oListCategorium { get; set; }
    }
}
