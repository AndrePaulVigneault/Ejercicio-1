using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    public class MockPersona:IPersonaRepository
    {
        List<Persona> Personas = new List<Persona>();

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
            throw new NotImplementedException();
        }
    }
}
