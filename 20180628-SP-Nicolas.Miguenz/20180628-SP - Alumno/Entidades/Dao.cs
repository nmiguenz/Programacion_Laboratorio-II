using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class Dao : IArchivos<Votacion>
    {
        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            string connectionStr = "Data Source = ./SQLEXPRESS; Initial Catalog= votacion-sp-2018; Integrated Security=True";
            string consulta;
            consulta = String.Format("INSERT INTO Votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno) " +
                                    "VALUES ('{0}',{1},{2},{3})", objeto.NombreLey, objeto.ContadorAfirmativo,
                                    objeto.ContadorNegativo, objeto.ContadorAbstencion, "Nicolás Miguenz");
            SqlConnection conexion = null;
            SqlCommand comando;

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Relanza la excepcion capturada
                throw (e);
            }
            finally
            {
                if (!(conexion == null))
                    conexion.Close();
            }
            return true;
        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
