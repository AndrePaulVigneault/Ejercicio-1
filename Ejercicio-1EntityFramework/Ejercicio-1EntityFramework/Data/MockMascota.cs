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

        public bool Add(Mascota mascota)
        {
            var MascotaAgregar = Mascotas.FirstOrDefault(r => r.Id == mascota.Id);
            if (MascotaAgregar == null)
            {
                var last = Mascotas.LastOrDefault(r => r.Id == mascota.Id);
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
            throw new NotImplementedException();
        }
    }
}
