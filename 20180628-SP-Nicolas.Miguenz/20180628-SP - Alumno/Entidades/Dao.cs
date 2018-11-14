using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class Dao<Votacion> : IArchivos<Votacion>
    {
        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            string connectionStr = "Data Source = ./SQLEXPRESS; Initial Catalog= votacion-sp-2018; Integrated Security=True";
            SqlConnection conexion;

            conexion = new SqlConnection(connectionStr);
            string consulta;

            try
            {
                consulta = String.Format("INSERT INTO Votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno) VALUES ('{0}',{1},{2},{3},'{4}')", objeto.)
            }
            

        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
