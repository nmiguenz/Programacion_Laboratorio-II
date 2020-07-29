using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivos<Queue<Patente>>
    {
        public void Guardar(string archivo, Queue<Patente> datos)
        {
            
            //Recibe como parametro el archivo a escribir
            StreamWriter sw = new StreamWriter(archivo);

            try
            {
                //agrego una linea de texto
                foreach (Patente item in datos)
                {
                    sw.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo guardar el archivo .txt", e);
            }
            finally
            {
                sw.Close();
            }

        }

        public void Leer(string archivo, out Queue<Patente> datos)
        {
            //Asigno el parametro OUT
            datos = new Queue<Patente>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
            {
                while (!file.EndOfStream)
                {
                    try
                    {
                        datos.Enqueue(file.ReadLine().ValidarPatente());
                    }
                    catch (Exception e)
                    {
                        throw new PatenteInvalidaException(e.Message);
                    }
                }
            }

        }
    }
}
