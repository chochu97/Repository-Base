using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEjemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EjemploLogic logic = new EjemploLogic();

            Ejemplo ej = new Ejemplo();
            ej.Id = 1;
            ej.NombreEjemplo = "Test";

            Ejemplo eje = new Ejemplo();
            eje.Id = 97;
            eje.NombreEjemplo = "Lucky";

            //logic.Add(eje);
            //logic.Add(ej);
            

            var lista = logic.GetAll();

            foreach (var item in lista)
            {
                Console.WriteLine("\nId: "+ item.Id + ", Nombre: " + item.NombreEjemplo);
            }
            Console.ReadKey();

           // logic.Remove(1);

            var secondList = logic.GetAll();

            foreach (var item in secondList)
            {
                Console.WriteLine("\nId: " + item.Id + ", Nombre: " + item.NombreEjemplo);
            }
            Console.ReadKey();

            eje.NombreEjemplo = "Chinese Calendar";
            logic.Update(eje);

            var newEj = logic.GetById(97);

            Console.WriteLine("\nId: " + newEj.Id + ", Nombre: " + newEj.NombreEjemplo);
            Console.ReadKey();

        }
    }
}
