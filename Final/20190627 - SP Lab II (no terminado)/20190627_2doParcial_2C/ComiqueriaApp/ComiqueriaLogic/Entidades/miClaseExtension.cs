using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public static class MiClaseExtension
    {
        public static string FormatearPrecio(this double precio)
        {
            double decimales = Math.Round(precio, 2);

            return String.Format("$ {0}",decimales);

        }
    }
}

