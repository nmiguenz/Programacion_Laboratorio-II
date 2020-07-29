using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMiguenz02._02._2020.Entidades;

namespace testUnitario
{
    [TestClass]
    public class UnitTest1 : IEvento
    {
        public void ImprimirReloj(Reloj reloj, string dato)
        {
            throw new NotImplementedException();
        }

        //Agregar un test unitario que pruebe el operador +
        [TestMethod]
        public void TestMethod1()
        {
            Relojes reloj = new Relojes(4, this);
            reloj += Reloj.Primero;
            Assert.IsNotNull(reloj);  
        }

        //Agregar un test unitario que pruebe su excepción SinEspacioException.
        [TestMethod]
        [ExpectedException(typeof(SinEspacioException))]
        public void TestMethod2()
        {
            //Arrange
            Relojes relojes1 = new Relojes(4, this);

            try
            {
                //Act
                relojes1 += Reloj.Primero;
                relojes1 += Reloj.Segundo;
                relojes1 += Reloj.Tercero;
                relojes1 += Reloj.Cuarto;
                relojes1 += Reloj.Cuarto;
            }
            catch (Exception e)
            {

                throw new SinEspacioException(e.Message);
            }
            
        }
    }
}
