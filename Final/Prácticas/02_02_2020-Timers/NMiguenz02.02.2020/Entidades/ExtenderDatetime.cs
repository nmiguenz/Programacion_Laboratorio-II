using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMiguenz02._02._2020.Entidades
{
    public static class ExtenderDatetime
    {
        public static string TiempoTranscurrido(this DateTime dt)
        {

            return (DateTime.Now - dt).ToString();
        }
    }
}