using Datos.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.Texto
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

        private readonly string filePath = (ConfigurationManager.AppSettings["ArchivoTextoPath"]).ToString();

        public void Add(Ejemplo obj)
        {
            using(StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{obj.Id}, {obj.NombreEjemplo}");
            }
        }

        public List<Ejemplo> GetAll()
        {
            List<Ejemplo> ejemplos = new List<Ejemplo>();

            using(StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    Ejemplo obj = new Ejemplo
                    {
                        Id = int.Parse(data[0]),
                        NombreEjemplo = data[1]
                    };
                    ejemplos.Add(obj);
                }
            }
            return ejemplos;
        }

        public Ejemplo GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            List<Ejemplo> ejemplos = GetAll();
            ejemplos.RemoveAll(e => e.Id == id);
            WriteAll(ejemplos);
        }

        public void Update(Ejemplo obj)
        {
            List<Ejemplo> ejemplos = GetAll();

            for(int i = 0; i < ejemplos.Count; i++)
            {
                if (ejemplos[i].Id == obj.Id)
                {
                    ejemplos[i].NombreEjemplo = obj.NombreEjemplo;
                    break;
                }
            }
            WriteAll(ejemplos);
        }

        private void WriteAll(List<Ejemplo> list)
        {
            using(StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach(var ejemplo in list)
                {
                    writer.WriteLine($"{ejemplo.Id}, {ejemplo.NombreEjemplo}");
                }
            }
        }
    }
}
