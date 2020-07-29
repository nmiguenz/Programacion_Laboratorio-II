using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    //Clase GENERICA
    public class Xml<T> : IArchivos<T> where T : new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser;

            try
            {
                ser = new XmlSerializer(typeof(T));
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser.Serialize(writer, datos);
            }
            catch (Exception e)
            {

                throw new Exception("No se pudo guardar la serializacion", e);
            }
            finally
            {
                if(!(writer is null))
                {
                    writer.Close();
                }
            }
            
        }

        public void Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser;

            try
            {
                //Se indica ubicacion del archivo XML
                reader = new XmlTextReader(archivo);
                //TextReader writer = new StreamReader(archivo);

                //Se indica tipo de objeto a serializar
                ser = new XmlSerializer(typeof(T));

                //se deserializa el archivo contenido en el reader, y lo guardo en los datos
                datos = (T)ser.Deserialize(reader);
            }
            catch (Exception e)
            {

                //datos = default;
                throw new Exception("No se pudo leer el archivo XML", e);
               
            }
            finally
            {
                if(!(reader is null))
                {
                    reader.Close();
                }
            }
            
        }
    }
}
