using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class SinEspacioException : Exception
    {
        public SinEspacioException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

        public SinEspacioException(string mensaje) : this(mensaje, null)
        {

        } 

    }
}
