using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contracts
{
    public interface IGenericRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
