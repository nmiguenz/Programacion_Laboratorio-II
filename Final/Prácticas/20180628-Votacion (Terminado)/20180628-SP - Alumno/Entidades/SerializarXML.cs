using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{
    public class SerializarXML<T> : IArchivos<T> where T : new()
    {
        public bool Guardar(string rutaArchivo, T objeto)
        {

            TextWriter writer = null;
            XmlSerializer ser;

            try
            {
                ser = new XmlSerializer(typeof(T));
                writer = new StreamWriter(rutaArchivo);
                ser.Serialize(writer, objeto);
            }
            catch (Exception e)
            {

                throw new ErrorArchivoException(e.Message, e);
            }
            finally
            {
                if(!(writer is null))
                {
                    writer.Close();
                }
            } 
            return true;
        }
        
        public T Leer(string rutaArchivo)
        {
            XmlSerializer ser;
            TextReader file = null;
            T objetoLeido;
            try
            {
                ser = new XmlSerializer(typeof(T));
                file = new StreamReader(rutaArchivo);
                objetoLeido = (T)ser.Deserialize(file);
            }
            catch (Exception e)
            {

                throw new ErrorArchivoException(e.Message, e);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
            return objetoLeido;
        }
    }
}
