using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ComiqueriaLogic
{
    public class Dao
    {
        private static SqlCommand loadPersonsCommand;
        public bool Guardar(string descripcion, double precio, int stock)
        {
            String connectionStr = "Data Source=LAPTOP-NICO\\SQLEXPRESS;Initial Catalog=Comiqueria;Integrated Security=True";
            String consulta = String.Format("INSERT INTO Productos (Descripcion, Precio, Stock) VALUES ('{0}', '{1}', '{2}')",
                                            descripcion, precio, stock);

            SqlConnection conexion = null;
            SqlCommand comando;
            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                if (!(conexion is null))
                    conexion.Close();
            }
            return true;
        }

        /*
        public static Producto loadProducto(string id)
        {
            Producto producto = new Producto();
            loadPersonsCommand = new SqlCommand();
            loadPersonsCommand.CommandType = System.Data.CommandType.Text;
            loadPersonsCommand.CommandText = "SELECT * FROM Comiqueria.Productos WHERE Codigo = " + id;

            loadPersonsCommand.Connection = DbConnection.GetConnection();
            SqlDataReader dataReader = loadPersonsCommand.ExecuteReader();

            while (dataReader.Read())
            {
                persona = new Persona(dataReader["id"].ToString(),
                    dataReader["FirstName"].ToString(),
                    dataReader["MiddleName"].ToString(),
                    dataReader["LastName"].ToString());
            }
            return persona;

        }

        public bool UpdatePrecio()
        {
            SqlConnection conexion = null;
            SqlCommand comando;

            loadPersonsCommand = new SqlCommand();
            loadPersonsCommand.CommandType = System.Data.CommandType.Text;
            loadPersonsCommand.Connection = DbConnection.GetConnection();

            loadPersonsCommand.CommandText = "UPDATE Person.Person set FirstName='" + p.FirstName + "'," +
                                            "MiddleName='" + p.MiddleName + "'," +
                                            "LastName='" + p.LastName + "' " +
                                            "WHERE BusinessEntityID = " + p.ID;
            try
            {
                loadPersonsCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return true;
        }
        */
    }
}
