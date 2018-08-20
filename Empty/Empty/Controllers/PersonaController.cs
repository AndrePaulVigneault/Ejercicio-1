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
        private readonly IPersonaRepository ContextPersona;

        public PersonaController(IPersonaRepository _ContextPersona)
        {
            ContextPersona = _ContextPersona;
        }

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

        public IActionResult Edit(int id)
        {
            var Persona = ContextPersona.Find(id);
            return View(new EditViewModel()
            {
                Cedula = Persona.Cedula, FechaNacimiento = Persona.FechaNacimiento, Nombre = Persona.Nombre
            });
        }


        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {

            var persona = ContextPersona.Find(model.Cedula);
            if (persona != null)
            {
                persona.FechaNacimiento = model.FechaNacimiento;
                persona.Nombre = model.Nombre;
                ContextPersona.Edit(persona);
                ContextPersona.Save();
            }
            return RedirectToAction("Index");
        }
    }
}