using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorArchivoException : Exception
    {
        public ErrorArchivoException() { }

        public ErrorArchivoException(string message) : base(message)
        {

        }

        public ErrorArchivoException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
