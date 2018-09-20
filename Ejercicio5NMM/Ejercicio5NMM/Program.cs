using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;
            int numeroIncremental = 0;
            int acumMenor;
            int acumMayor;
            Console.WriteLine("Ingrese un numero para buscar cuales son los centros numéricos");
            int.TryParse(Console.ReadLine(), out numero);

            for(int i=0; i<numero; i++)
            {
                acumMenor = 0;
                for (int j=i-1; j>0;j--)
                {
                    acumMenor += j;
                }

                numeroIncremental = i++;
                acumMayor = 0;
                do
                {
                    acumMayor += numeroIncremental;
                } while (acumMayor <= acumMenor);

                if (Object.ReferenceEquals(acumMenor, acumMayor))
                {
                    Console.WriteLine("El centro numérico es: {0}", i);
                }
            }
            Console.ReadKey();
        }
    }
}
