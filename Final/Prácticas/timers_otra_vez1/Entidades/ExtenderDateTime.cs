using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtenderDateTime
    {
        public static string TiempoTranscurrido(this DateTime dt)
        {
            return (DateTime.Now - dt).ToString();
        }
    }
}
