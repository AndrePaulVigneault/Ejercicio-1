using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContextLibrary;
using Ejercicio_1EntityFramework.Data;
using Microsoft.AspNetCore.Mvc;
using WebPersonasMascotas.ViewModels;
using WebPersonasMascotas.ViewModels.MascotaViewModel;

namespace WebPersonasMascotas.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IMascotaRepository ContextMascota;

        public MascotaController(IMascotaRepository _ContextMascota)
        {
            ContextMascota = _ContextMascota;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel() { Mascotas = ContextMascota.GetAll().ToList() });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel createViewModel)
        {

            if (ContextMascota.Add(new Mascota()
            {
                EstadoAdopcion = false,
                Nombre = createViewModel.Nombre,
                Raza = createViewModel.Raza
                
            }))
            {
                ContextMascota.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var Persona = ContextMascota.Find(id);
            if (Persona != null)
            {
                ContextMascota.Delete(id);
                ContextMascota.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var mascota = ContextMascota.Find(id);
            return View(new EditViewModel()
            {
                Id = mascota.Id,
                Raza = mascota.Raza,
                Nombre = mascota.Nombre
            });
        }


        [HttpPost]
        public IActionResult Edit(EditViewModel model)
        {

            var mascota = ContextMascota.Find(model.Id);
            if (mascota != null)
            {
                mascota.Raza = model.Raza;
                mascota.Nombre = model.Nombre;
                ContextMascota.Edit(mascota);
                ContextMascota.Save();
            }
            return RedirectToAction("Index");
        }
    }
}