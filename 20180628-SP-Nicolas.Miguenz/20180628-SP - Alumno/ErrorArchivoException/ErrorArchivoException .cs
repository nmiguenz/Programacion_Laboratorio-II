using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepcion
{
    public class ErrorArchivoException:Exception
    {
        public ErrorArchivoException():base ("Error archivo exception.")
        {

        }
    }
}
