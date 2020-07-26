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
    public class SerializarXML<T> : IArchivos<T>
    {
        public bool Guardar(string rutaArchivo, T objeto)
        {

            XmlTextWriter writer = null;
            XmlSerializer ser;

            try
            {
                ser = new XmlSerializer(typeof(T));
                writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8);
                ser.Serialize(writer, objeto);
                writer.Close();
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
            XmlSerializer reader;
            StreamReader file = null;
            T objetoLeido;
            try
            {
                //Instancia del objeto XmlSerializer
                reader = new XmlSerializer(typeof(T));
                //Lee la ruta del archivo
                file = new StreamReader(rutaArchivo);
                //Deserializacion del objeto del tipo necesario
                objetoLeido = (T)reader.Deserialize(file);
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
