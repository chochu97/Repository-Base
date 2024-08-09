using Datos.Contracts;
using Datos.Helpers;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Implementations.Sql
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

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Ejemplo] (Id, Nombre) VALUES (@Id, @Nombre); Select @@IDentity";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Ejemplo] SET Nombre = @Nombre WHERE Id = @Id";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Ejemplo] WHERE Id = @Id";
        }

        private string SelectOneStatement
        {
            get => "SELECT Id, Nombre FROM [dbo].[Ejemplo] WHERE Id = @Id";
        }

        private string SelectAllStatement
        {
            get => "SELECT Id, Nombre FROM [dbo].[Ejemplo]";
        }
        #endregion


        public void Add(Ejemplo obj)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Nombre", obj.NombreEjemplo)
            };

            SqlHelper.ExecuteNonQuery(InsertStatement, CommandType.Text, parameters);

            
        }

        public List<Ejemplo> GetAll()
        {
           List<Ejemplo> ejemplos = new List<Ejemplo>();
           
           using(SqlDataReader reader = SqlHelper.ExecuteReader(SelectAllStatement, CommandType.Text))
            {
                while (reader.Read())
                {
                    Ejemplo ej = new Ejemplo
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NombreEjemplo = reader["Nombre"].ToString()
                    };
                    ejemplos.Add(ej);
                }
            }

           return ejemplos;
        }

        public Ejemplo GetById(int id)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id)
            };

            using(SqlDataReader reader = SqlHelper.ExecuteReader(SelectOneStatement, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    return new Ejemplo
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        NombreEjemplo = reader["Nombre"].ToString()
                    };
                }
            }
            return null;
        }

        public void Remove(int id)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id)
            };

            SqlHelper.ExecuteNonQuery(DeleteStatement, CommandType.Text, parameters);
        }

        public void Update(Ejemplo obj)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@Nombre", obj.NombreEjemplo)
            };

            SqlHelper.ExecuteNonQuery(UpdateStatement, CommandType.Text, parameters);
        }
    }
}
