using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, numero;

            Console.WriteLine("Ingrese numero: ");
            numero = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < (numero + 1); i++)
            {
                if (numero % i == 0)
                {
                    a++;
                }
            }
            if (a != 2)
            {
                Console.WriteLine("No es Primo");
            }
            else
            {
                Console.WriteLine("Si es Primo");
            }
            Console.ReadLine();
        }
    }
}
