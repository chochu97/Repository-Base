using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Contracts
{
    public interface IGenericLogic<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Remove(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
