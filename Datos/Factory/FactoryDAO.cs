using Datos.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Factory
{
    public static class FactoryDAO
    {
        public static IEjemploRepository GetEjemploRepository()
        {
            int backendType = int.Parse(ConfigurationManager.AppSettings["BackendType"]);

            if(backendType == (int)BackendType.Memory)
            {
                return Datos.Implementations.Memory.EjemploDAO.Current;
            }
            else if(backendType == (int)BackendType.Sql)
            {
                return Datos.Implementations.Sql.EjemploDAO.Current;
            }
            else if(backendType == (int)BackendType.Texto)
            {
                return Datos.Implementations.Texto.EjemploDAO.Current;
            }
            else
            {
                return null;
            }
        }
    }

    public enum BackendType
    {
        Memory,
        Sql,
        Texto
    }
}
