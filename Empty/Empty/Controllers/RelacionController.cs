using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio_1EntityFramework;
using Ejercicio_1EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using WebPersonasMascotas.Data;
using WebPersonasMascotas.ViewModels.Relacion;
using WebPersonasMascotas.ViewModels.RelacionViewModel;

namespace WebPersonasMascotas.Controllers
{
    public class RelacionController : Controller
    {
        private readonly IPersona_MascotaRepository ContextRelacion;
        private readonly IPersonaRepository ContextPersona;
        private readonly IMascotaRepository ContextMascota;

        public RelacionController(IPersona_MascotaRepository _ContextRelacion, IPersonaRepository _ContextPersona, IMascotaRepository _ContextMascota)
        {
            ContextRelacion = _ContextRelacion;
            ContextPersona = _ContextPersona;
            ContextMascota = _ContextMascota;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel() { Relaciones = ContextRelacion.GetAll().ToList() });
        }

        public IActionResult Create()
        {
            IList<Persona> Personas = ContextPersona.GetAll().ToList();
            IList<Mascota> Mascotas = ContextMascota.GetAll().ToList();
            CreateViewModel createViewModel = new CreateViewModel();
            createViewModel.Personas = Personas;
            createViewModel.Mascotas = Mascotas;
            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel createViewModel)
        {
            int.TryParse(Request.Form["IdPersona"], out int IdPersona);
            int.TryParse(Request.Form["IdMascota"], out int IdMascota);
            Persona Per = ContextPersona.Find(IdPersona);
            Mascota masc = ContextMascota.Find(IdMascota);


            if (Per != null && masc != null)
            {
                if (ContextRelacion.Add(new Persona_Mascota()
                {
                    Persona = Per,
                    Mascota = masc
                }))
                {
                    ContextPersona.Save();
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("IdMascota", "La Relacion Ya Existe");
            IList<Persona> Personas = ContextPersona.GetAll().ToList();
            IList<Mascota> Mascotas = ContextMascota.GetAll().ToList();
            createViewModel.Personas = Personas;
            createViewModel.Mascotas = Mascotas;
            return View(createViewModel);
        }

        public IActionResult Edit(int id)
        {
            var Persona_Mascota = ContextRelacion.Find(id);
            return View(new EditViewModel()
            {
                id = id,
                Personas = ContextPersona.GetAll().ToList(),
                Mascotas = ContextMascota.GetAll().ToList(),
                IdMascota = Persona_Mascota.Mascota.Id.ToString(),
                IdPersona = Persona_Mascota.Persona.Cedula.ToString()

            });
        }

        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {
            int.TryParse(Request.Form["IdPersona"], out int IdPersona);
            int.TryParse(Request.Form["IdMascota"], out int IdMascota);
            Persona Per = ContextPersona.Find(IdPersona);
            Mascota masc = ContextMascota.Find(IdMascota);

            var relacion = ContextRelacion.Find(model.id);
            if (relacion != null)
            {
                relacion.Mascota = ContextMascota.Find(IdMascota);
                relacion.Persona = ContextPersona.Find(IdPersona);
                if (ContextRelacion.Edit(relacion))
                {
                    ContextMascota.Save();
                    return RedirectToAction("Index");
                }
               
            }

            IList<Persona> Personas = ContextPersona.GetAll().ToList();
            IList<Mascota> Mascotas = ContextMascota.GetAll().ToList();
            ModelState.AddModelError("IdMascota", "La Relacion Ya Existe");
            model.Personas = Personas;
            model.Mascotas = Mascotas;
            return View(model);

        }

    }
}