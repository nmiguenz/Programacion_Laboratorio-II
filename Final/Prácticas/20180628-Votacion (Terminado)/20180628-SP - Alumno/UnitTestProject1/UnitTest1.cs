using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        int count = 0;
        //Realizar un test que compruebe que si hay un error al querer serializar un objeto del tipo Votacion
        //lance la excepción ErrorArchivoException.
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivoException))]
        public void Testxml()
        {
            try
            {
                //Arrange
                SerializarXML<Votacion> ser = new SerializarXML<Votacion>();
                
                //Act
                ser.Guardar("", new Votacion("Medios",null));
            }
            catch (Exception e)
            {
                throw new ErrorArchivoException(e.Message);
            }
        }

        //10.2. Realizar un test que compruebe que el evento de la clase Votacion tantas veces como Senadores
        //haya.O sea, si hay 2 senadores el evento será invocado 2 veces.
        [TestMethod]
        public void LanzamientoDeEvento_Votacion()
        {
            //Arrange
            Dictionary<string, Votacion.EVoto> participantes = new Dictionary<string, Votacion.EVoto>();

            participantes.Add("1", Votacion.EVoto.Abstencion);
            participantes.Add("2", Votacion.EVoto.Afirmativo);
            participantes.Add("3", Votacion.EVoto.Negativo);
            participantes.Add("4", Votacion.EVoto.Abstencion);
            int suma = 0;

            Votacion votos = new Votacion("ley", participantes);
            votos.EventoVotoEfectuado += ManejadorVotos;

            //Act
            votos.Simular();
            suma = votos.ContadorAbstencion + votos.ContadorAfirmativo + votos.ContadorNegativo;

            //Assert
            //Assert.AreEqual(suma, count);
            Assert.IsTrue(count == suma);
        }

        public void ManejadorVotos(string senador, Votacion.EVoto voto)
        {
            count++;
        }
    }
}
