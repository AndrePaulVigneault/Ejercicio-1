using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    class MockMascota : IMascotaRepository
    {
        List<Mascota> Mascotas = new List<Mascota>();
        public MockMascota()
        {
            Mascotas.Add(new Mascota { Id = 1, Nombre = "Firulai", Raza = "dalmata", EstadoAdopcion = false });
            Mascotas.Add(new Mascota { Id = 2, Nombre = "Maya", Raza = "rottweiler", EstadoAdopcion = false });
            Mascotas.Add(new Mascota { Id = 3, Nombre = "Tequila", Raza = "rottweiler", EstadoAdopcion = false });
            Mascotas.Add(new Mascota { Id = 4, Nombre = "Scot", Raza = "Golden", EstadoAdopcion = false });
            Mascotas.Add(new Mascota { Id = 5, Nombre = "Chino", Raza = "Mierdero", EstadoAdopcion = false });
            Mascotas.Add(new Mascota { Id = 6, Nombre = "kip", Raza = "Labrador", EstadoAdopcion = false });
        }

        public bool Add(Mascota mascota)
        {
            var MascotaAgregar = Mascotas.FirstOrDefault(r => r.Id == mascota.Id);
            if (MascotaAgregar == null)
            {
                var last = Mascotas.LastOrDefault();
                if (last == null)
                {
                    mascota.Id = 1;
                }
                else
                {
                    mascota.Id = last.Id + 1;
                }
                Mascotas.Add(mascota);
                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                var RemoverPersona = Mascotas.FirstOrDefault(r => r.Id == Id);
                Mascotas.Remove(RemoverPersona);
                return true;
            }
            catch (Exception)
            {
                return false;
            };
        }

        public bool Edit(Mascota Mascota)
        {
            var EditPersona = Mascotas.FirstOrDefault(r => r.Id == Mascota.Id);
            if (EditPersona != null)
            {
                Mascotas.FirstOrDefault(r => r.Id == Mascota.Id).Nombre = Mascota.Nombre;
                Mascotas.FirstOrDefault(r => r.Id == Mascota.Id).Raza = Mascota.Raza;
                return true;
            }
            return false;
        }

        public Mascota Find(int Id)
        {
            var Mascota = Mascotas.Single(r => r.Id == Id);
            return Mascota;
        }

        public IQueryable<Mascota> GetAll() => Mascotas.AsQueryable();

        public void Save()
        {
        }
    }
}
