using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMiguenz02._02._2020.Entidades
{
    public interface IReloj
    {
        Relojes CargarReloj(Reloj item);

        void killEmAll();
    }
}
