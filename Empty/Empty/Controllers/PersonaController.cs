using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio_1EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using WebPersonasMascotas.ViewModels.PersonaViewModel;

namespace WebPersonasMascotas.Controllers
{
    public class PersonaController : Controller
    {
        IPersonaRepository ContextPersona = new MockPersona();

        public IActionResult Index()
        {
            return View(new IndexViewModel() { Personas = ContextPersona.GetAll().ToList()});
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel createViewModel)
        {

            if(ContextPersona.Add(new Ejercicio_1EntityFramework.Persona() { Cedula = createViewModel.Cedula,
                                                                             Nombre = createViewModel.Nombre,
                                                                             FechaNacimiento = createViewModel.FechaNacimiento   }))
            {
                ContextPersona.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var Persona = ContextPersona.Find(id);
            if (Persona != null)
            {
                ContextPersona.Delete(id);
                ContextPersona.Save();
            }
            return RedirectToAction("Index");
        }
    }
}