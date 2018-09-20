using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int añoInicio;
            int añoFin;
            Console.WriteLine("Ingrese año de inicio");
            int.TryParse(Console.ReadLine(), out añoInicio);
            Console.WriteLine("Ingrese año final");
            int.TryParse(Console.ReadLine(), out añoFin);

            for (int i=añoInicio; i<=añoFin; i++)
            {
                if(i % 4 == 0 && (i % 100 != 0 || i % 400 == 0))
                {
                    Console.WriteLine("{0}", i);
                }
            }
            Console.ReadKey();
        }
    }
}
