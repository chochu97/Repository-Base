using Datos.Contracts;
using Datos.Factory;
using Domain;
using Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EjemploLogic : IGenericLogic<Ejemplo>
    {
        private readonly IEjemploRepository repository;

        public EjemploLogic()
        {
            repository = FactoryDAO.GetEjemploRepository();
        }

        public void Add(Ejemplo obj)
        {
            repository.Add(obj);
        }

        public List<Ejemplo> GetAll()
        {
            return repository.GetAll();
        }

        public Ejemplo GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Update(Ejemplo obj)
        {
            repository.Update(obj);
        }
    }
}
