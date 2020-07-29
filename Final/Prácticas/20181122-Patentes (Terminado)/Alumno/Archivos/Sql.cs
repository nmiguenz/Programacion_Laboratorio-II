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
        #region Constructores
        public Sql()
        {
            // CREO UN OBJETO SQLCONECTION
            this.conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=patentes-sp-2018;Integrated Security=True");
            // CREO UN OBJETO SQLCOMMAND
            this.comando = new SqlCommand();
            // INDICO EL TIPO DE COMANDO
            this.comando.CommandType = System.Data.CommandType.Text;
            // ESTABLEZCO LA CONEXION
            this.comando.Connection = this.conexion;
        }
        #endregion

        /// <summary>
        /// Guarda las patentes que se agregan a la cola en la tabla (patentes) de la DBO
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="datos"></param>
        /*
        public void Guardar(string tabla, Queue<Patente> datos)
        {
            string str = "";
            foreach (Patente item in datos)
            {
                // LE PASO LA INSTRUCCION SQL
                str = "INSERT INTO" + tabla + "(patente,tipo)" + "VALUES" + "('"+ item.CodigoPatente + "','"+ item.TipoCodigo.ToString() + "')";
                    
            }
            try
            {
                // LE PASO LA INSTRUCCION SQL
                this.comando.CommandText = str;
                // ABRO LA CONEXION A LA BD
                this.conexion.Open();
                //EJECUTO EL COMANDO
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e)
            {
                //relanza la excepcion capturada
                throw new Exception("No se pudo hacer el INSERT", e);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
        */

        public void Guardar(string tabla, Queue<Patente> datos)
        {
            //string sql = "INSERT INTO " + tabla + " (patente,tipo) VALUES";
            //foreach (Patente p in datos)
            //{
            //    sql = sql + "('" + p.CodigoPatente + "','" + p.TipoCodigo.ToString() + "'),";
            //}
            string sql = "INSERT INTO " + tabla + " (patente,tipo) ";
            foreach (Patente p in datos)
            {
                sql = sql + "SELECT '" + p.CodigoPatente + "','" + p.TipoCodigo.ToString() + "' UNION ALL ";
            }

            try
            {
                //Recupera la cadena any
                sql = sql.Substring(0, sql.Length - 11);
                // LE PASO LA INSTRUCCION SQL
                this.comando.CommandText = sql;
                // ABRO LA CONEXION A LA BD
                this.conexion.Open();
                // EJECUTO EL COMMAND
                this.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                    this.conexion.Close();
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
