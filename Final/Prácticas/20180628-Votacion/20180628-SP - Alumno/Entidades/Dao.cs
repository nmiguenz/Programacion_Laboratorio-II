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
            bool todoOk = false;
            string nombreAlumno = "Nicolas Miguenz";
            String connectionStr = "Data Source=LAPTOP-NICO\\SQLEXPRESS;Initial Catalog=votacion-sp-2018;Integrated Security=True";
            string consulta = String.Format("INSERT INTO Votaciones (nombreLey, afirmativos, negativos, abstenciones, nombreAlumno)" + "VALUES ('{0}','{1}','{2}','{3}','{4}')", 
                              objeto.NombreLey, objeto.ContadorAfirmativo, objeto.ContadorNegativo, objeto.ContadorAbstencion, nombreAlumno);

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
                todoOk = true;
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
            return todoOk;
        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }
    }
}
