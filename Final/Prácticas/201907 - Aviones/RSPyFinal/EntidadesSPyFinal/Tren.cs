using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSPyFinal
{
    public class Tren : Transporte
    {
        private string canVagones;
        protected EFabricante fabricante;

        public override string Transportar()
        {
            return "Vuela vuela avionsito";
        }

        public Tren(int velocidad,EFabricante fabricante, string cantidadVagones)
        {
            this.canVagones = cantidadVagones;
            this.fabricante = fabricante;
            this.velocidad = velocidad;
        }
    }
}
