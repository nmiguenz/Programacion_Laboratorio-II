using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class ComiqueriaException : Exception
    {
        public ComiqueriaException(string mensaje, Exception innerException): base(mensaje,innerException)
        {

        }
    }
}
