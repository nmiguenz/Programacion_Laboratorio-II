using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public static class ExtenderPrecio
    {
        public static string FormatearPrecio(this double precioFinal)
        {
            double redondeado = Math.Round(precioFinal, 2);
            return String.Format("$ '{0}'", redondeado);
        }
    }
}