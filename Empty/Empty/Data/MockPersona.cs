using DbContextLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    public class MockPersona:IPersonaRepository
    {
        List<Persona> Personas = new List<Persona>();
        public MockPersona()
        {
            Personas.Add(new Persona { Cedula = 12344, Nombre = "armando", FechaNacimiento = new DateTime(1998,05,11)});
            Personas.Add(new Persona { Cedula = 4354, Nombre = "Chino", FechaNacimiento = new DateTime(1992, 06, 28) });
            Personas.Add(new Persona { Cedula = 7845, Nombre = "Andre", FechaNacimiento = new DateTime(1990, 06, 23) });
            Personas.Add(new Persona { Cedula = 6784, Nombre = "ed", FechaNacimiento = new DateTime(1900, 08, 28) });
            Personas.Add(new Persona { Cedula = 36523, Nombre = "lung", FechaNacimiento = new DateTime(1992, 05, 28) });
            Personas.Add(new Persona { Cedula = 57074, Nombre = "ali", FechaNacimiento = new DateTime(1996, 07, 10) });
        }

        public bool Add(Persona persona)
        {
            var personaAgregar = Personas.FirstOrDefault(r => r.Cedula == persona.Cedula);
            if (personaAgregar == null)
            {
                Personas.Add(persona);
                return true;
            }
            return false;
        }

        public bool Delete(int personaId)
        {
            try
            {
                var RemoverPersona = Personas.FirstOrDefault(r => r.Cedula == personaId);
                Personas.Remove(RemoverPersona);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Persona persona)
        {
            var RemoverPersona = Personas.FirstOrDefault(r => r.Cedula == persona.Cedula);
            if (RemoverPersona != null)
            {
                Personas.FirstOrDefault(r => r.Cedula == persona.Cedula).Nombre = persona.Nombre;
                Personas.FirstOrDefault(r => r.Cedula == persona.Cedula).FechaNacimiento = persona.FechaNacimiento;
                return true;
            }
            return false;

        }

        public Persona Find(int Id)
        {
            var persona = Personas.Single(r => r.Cedula == Id);
            return persona;
        }

        public IQueryable<Persona> GetAll() => Personas.AsQueryable();

        public void Save()
        {
            
        }
    }
}
