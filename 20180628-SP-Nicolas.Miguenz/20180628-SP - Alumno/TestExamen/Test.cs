using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepcion;
using Entidades;
using System.Collections.Generic;

namespace TestExamen
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestSerializar()
        {
            Votacion vot = new Votacion();
            SerializarXML<Votacion> serializarXML = new SerializarXML<Votacion>();

            try
            {
                serializarXML.Guardar("Votacion.xml", vot);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ErrorArchivoException));
            }

            try
            {
                serializarXML.Leer("Votacion.xml");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ErrorArchivoException));
            }
            
        }

        private int contadorEvento = 0;

        [TestMethod]
        public void TestCompruevaSenadoresLasVecesNecesarias()
        {
            Dictionary<string, Votacion.EVoto> senadores = new Dictionary<string, Votacion.EVoto>
            {
                { "1", Votacion.EVoto.Esperando },
                { "2", Votacion.EVoto.Esperando }
            };
            Votacion votacion = new Votacion("Ley", senadores);
            votacion.EventoVotoEfectuado += ManejadorContador;

            votacion.Simular();

            Assert.AreEqual(2, contadorEvento);

        }

        void ManejadorContador(string senador, Votacion.EVoto voto)
        {
            contadorEvento++;
        }
    }    
}
