using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SinEspacioException : Exception
    {
        public SinEspacioException(string mensaje) : base(mensaje)
        {

        }

        public SinEspacioException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

    }
}
