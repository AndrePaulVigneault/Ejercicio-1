using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    public class PersonaRepository : IPersonaRepository
    {
        internal DBContext _context;

        public PersonaRepository()
        {
        }

        public PersonaRepository(DBContext context)
        {
            _context = context;
        }

        public bool Add(Persona persona)
        {
            if (_context.Set<Persona>().Where(s => s.Cedula == persona.Cedula).FirstOrDefault() == null)
            {
                _context.Set<Persona>().Add(persona);
                return true;
            }
            return false;
        }

        public bool Delete(int cedula)
        {
            try
            {
                _context.Set<Persona>().Remove(_context.Set<Persona>().Where(s => s.Cedula == cedula).SingleOrDefault());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Persona persona)
        {
            if (_context.Set<Persona>().Where(s => s.Cedula == persona.Cedula).FirstOrDefault() != null)
            {
                _context.Entry(persona).State = EntityState.Modified;
                return true;
            }
            return false;
            
        }

        public Persona Find(int Id)
        {
            Persona persona = _context.Set<Persona>().Where(s => s.Cedula == Id).FirstOrDefault();
            return persona;
        }

        public IQueryable<Persona> GetAll()
        {
            IQueryable<Persona> query = _context.Set<Persona>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
