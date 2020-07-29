using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Archivos
{
    public class Sql : IArchivos<Queue<Patente>>
    {
        SqlCommand comando;
        SqlConnection conexion = null;


        //Sql recibirá el nombre de la tabla a consultar (patentes) y una cola con los datos.
        public Sql()
        {
            String connectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=patentes-sp-2018;Integrated Security=True";
            //instacia de la conexion
            conexion = new SqlConnection(connectionStr);

            //instancia del comando
            this.comando = new SqlCommand();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = conexion;
        }

        /// <summary>
        /// Guarda las patentes que se agregan a la cola en la tabla (patentes) de la DBO
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="datos"></param>
        public void Guardar(string tabla, Queue<Patente> datos)
        {
            try
            {
                this.conexion.Open();
                foreach (Patente item in datos)
                {

                    //Paso la instruccion SQL a procesar
                    this.comando.CommandText = String.Format("INSERT INTO ({0})" + "VALUES ('{1}')", tabla, item);
                    
                    //Ejecuta la consulta SQL
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                //relanza la excepcion capturada
                throw new Exception("No se pudo hacer el INSERT", e);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="datos"></param>
        public void Leer(string tabla, out Queue<Patente> datos)
        {
            Queue<Patente> cola = new Queue<Patente>();
            Patente auxPatente = new Patente();
            string auxCodigo = "";

            SqlDataReader oDr;
            this.comando.CommandText = String.Format("SELECT * FROM {0}", tabla);

            try
            {
                this.conexion.Open();
                oDr = this.comando.ExecuteReader();

                while (oDr.Read())
                {
                    //Que pasa si quiero leer mas de un dato?????
                    auxCodigo = oDr["patente"].ToString();
                    auxPatente = auxCodigo.ValidarPatente();
                    cola.Enqueue(auxPatente);
                }
                datos = cola;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo leer la base de datos", e);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
    }
}
