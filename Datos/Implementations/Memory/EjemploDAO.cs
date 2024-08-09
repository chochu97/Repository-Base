using Datos.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.Memory
{
    public class EjemploDAO : IEjemploRepository
    {
        //singleton
        private static readonly EjemploDAO instance = new EjemploDAO();

        public static EjemploDAO Current
        {
            get
            {
                return instance;
            }
        }
        //singleton

        public List<Ejemplo> lista = new List<Ejemplo>();
        public void Add(Ejemplo obj)
        {
            lista.Add(obj);
        }

        public List<Ejemplo> GetAll()
        {
            return lista;
        }

        public Ejemplo GetById(int id)
        {
            return lista.FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            var ejemplo = lista.FirstOrDefault(e => e.Id == id);
            lista.Remove(ejemplo);
        }

        public void Update(Ejemplo obj)
        {
            var ejemplo = lista.FirstOrDefault(e => e.Id == obj.Id);
            lista.Remove(ejemplo);
            lista.Add(obj);

        }
    }
}
