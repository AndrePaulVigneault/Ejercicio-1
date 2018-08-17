using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ejercicio_1EntityFramework
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Find(int Id);
        bool Add(T persona);
        bool Delete(int Id);
        bool Edit(T persona);
        void Save();
    }
}
