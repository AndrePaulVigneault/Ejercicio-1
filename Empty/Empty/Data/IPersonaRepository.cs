using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    public interface IPersonaRepository : IGenericRepository<Persona> 
    {
    }
}
