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
    public class SerializarXML<T>:IArchivos<T>
    {
        public T Leer(string rutaArchivo)
        {
            T leido;
            XmlTextReader reader = null;
            XmlSerializer serializa;

            try
            {
                reader = new XmlTextReader(rutaArchivo);
                serializa = new XmlSerializer(typeof(T));
                leido = (T)serializa.Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException();
            }
            finally
            {

                reader.Close();
            }
            
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
                //Segun la forma en que ponga la excepcion
                //throw new ErrorArchivoException(ex.Message, ex);
            }
            finally
            {
                writer.Close();
            }
            return retorno;            
        }

        
    }
}
