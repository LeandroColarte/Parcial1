using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Models;
using Parcial1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Parcial1.Controllers
{
    public class HomeController : Controller
    {
        private readonly FormularioContext _DBContext;

        public HomeController(FormularioContext context )
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Form> Lista = _DBContext.Forms.Include(c => c.oCategorium).ToList();
            return View(Lista);
        }
        [HttpGet]
        public IActionResult Formulario_detalle(int idForm)
        {
            FormularioVM oFormularioVM = new FormularioVM()
            {
                oForm = new Form(),
                oListCategorium = _DBContext.Categoria.Select(Categorium => new SelectListItem(){
                    Text = Categorium.TiposCategoria,
                    Value = Categorium.IdCategoria.ToString()
                }).ToList()
            };

            if(idForm != 0)
            {
                oFormularioVM.oForm = _DBContext.Forms.Find(idForm);
            }

            return View(oFormularioVM);
        }

        [HttpPost]
        public IActionResult Formulario_detalle(FormularioVM oFormularioVM)
        {
            if(oFormularioVM.oForm.IdForm == 0)
            {
                _DBContext.Forms.Add(oFormularioVM.oForm);
            }
            else
            {
                _DBContext.Forms.Update(oFormularioVM.oForm);
            }

            _DBContext.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idForm)
        {
            Form oForm = _DBContext.Forms.Include(c => c.oCategorium).Where(e => e.IdForm == idForm).FirstOrDefault();

            return View(oForm);
        }

        [HttpPost]
        public IActionResult Eliminar(Form oForm)
        {
            _DBContext.Forms.Remove(oForm);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}