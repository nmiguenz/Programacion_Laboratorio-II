using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMiguenz02._02._2020.Entidades;

namespace testUnitario
{
    [TestClass]
    public class UnitTest1 : IEvento
    {
        
        //Agregar un test unitario que pruebe el operador + y su excepción SinEspacioException.
        [TestMethod]
        public void TestMethod1()
        {
            Relojes reloj = new Relojes(4, this);
            reloj += Reloj.Primero;
            Assert.IsNotNull(reloj);
        }

        [TestMethod]
        [ExpectedException(typeof(SinEspacioException))]
        public void TestMethod2()
        {
            Relojes relojes1 = new Relojes(4, this);
            relojes1 += Reloj.Primero;
            relojes1 += Reloj.Segundo;
            relojes1 += Reloj.Tercero;
            relojes1 += Reloj.Cuarto;
            relojes1 += Reloj.Cuarto;
        }

        void IEvento.ImprimirReloj(Reloj reloj, string dato)
        {
            throw new NotImplementedException();
        }
    }
}
