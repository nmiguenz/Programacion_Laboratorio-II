using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepcion;

namespace Entidades
{
    class SerializarXML<T>:IArchivos<T>
    {
        public T Leer(string rutaArchivo)
        {
            T leido;
            XmlTextReader reader;
            XmlSerializer serializa;

            reader = new XmlTextReader(rutaArchivo);

            serializa = new XmlSerializer(typeof(T));

            leido = (T)serializa.Deserialize(reader);

            reader.Close();
            return leido;
        }
        public bool Guardar(string rutaArchivo, T objeto)
        {
            bool retorno = false;
            XmlTextWriter writer=null;
            XmlSerializer serializador;

            try
            {
                writer = new XmlTextWriter(rutaArchivo, Encoding.UTF8);
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(writer, objeto);
                retorno = true;
            }
            catch(Exception ex)
            {
                throw new ErrorArchivoException();
            }
            finally
            {
                writer.Close();
            }
            return retorno;            
        }

        
    }
}
