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
            String connectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=votacion-sp-2018;Integrated Security=True";
            String consulta = String.Format("INSERT INTO votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno)" + "VALUES ({0},{1},{2},{3},{4})", 
                                            objeto.NombreLey, objeto.ContadorAfirmativo, objeto.ContadorNegativo, objeto.ContadorAbstencion, "Nicolas Miguenz");

            SqlConnection conexion = null;
            SqlCommand comando;

            try
            {
                //instacia de la conexion
                conexion = new SqlConnection(connectionStr);
                //instancia del comando
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                //Paso la instruccion SQL a procesar
                comando.CommandText = consulta;
                //
                comando.Connection = conexion;
                conexion.Open();
                //Ejecuta la consulta SQL
                comando.ExecuteNonQuery();
                Console.Beep();
            }
            catch (Exception e)
            {
                //relanza la excepcion capturada
                throw (e);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return true;
        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
