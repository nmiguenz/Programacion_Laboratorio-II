using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSPyFinal
{
    public class Avion : Transporte
    {
        private string aerolinea;
        protected EFabricante fabricante;
        public override string Transportar(Transporte transporte)
        {
            return "Corre corre trensito";
        }

        public Avion(int velocidad, EFabricante fabricante, string aerolinea)
        {
            this.velocidad = velocidad;
            this.fabricante = fabricante;
            this.aerolinea = aerolinea;
        }
    }
}
