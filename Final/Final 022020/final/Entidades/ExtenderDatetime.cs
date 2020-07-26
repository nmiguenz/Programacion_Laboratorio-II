using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtenderDatetime
    {
        public static string TiempoTranscurrido(this DateTime dt)
        {
            DateTime horaActual = DateTime.Now;
            TimeSpan time = horaActual-dt;
            return time.ToString("dd MMMM yyyy");
        }
    }
}
