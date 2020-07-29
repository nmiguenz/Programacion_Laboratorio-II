    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMiguenz02._02._2020.Entidades
{
    public class SinEspacioException : Exception
    {
        public SinEspacioException(string mensaje, Exception inner) : base(mensaje,inner)
        {

        }
        public SinEspacioException(string mensaje) : base (mensaje)
        {

        }
    }
}
