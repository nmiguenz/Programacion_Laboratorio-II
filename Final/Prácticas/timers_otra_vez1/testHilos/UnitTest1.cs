using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace testHilos
{
    [TestClass]
    public class UnitTest1 : IEvento
    {
        public void ImprimirReloj(Reloj reloj, string dato)
        {
            throw new NotImplementedException();
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
                //relojes1 += Reloj.Cuarto;
            }
            catch (Exception e)
            {

                throw new SinEspacioException(e.Message);
            }

        }
    }
}
