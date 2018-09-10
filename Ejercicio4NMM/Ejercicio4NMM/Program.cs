using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Un número perfecto es un entero positivo, que es igual a la suma de todos los enteros positivos
                (excluido el mismo) que son divisores del número.
                El primer número perfecto es 6, ya que los divisores de 6 son 1, 2 y 3; y 1 + 2 + 3 = 6.
                Escribir una aplicación que encuentre los 4 primeros números perfectos.
                Nota: Utilizar estructuras repetitivas y selectivas.
             */
            int resto;
            int divisor;
            int acumulador;
            int resultado = 0;

            //NO PUEDO HACER QUE TERMINE EN LA CANTIDAD DE NUMEROS QUE QUIERO!!!
            //FALTA PONER UN WHILE

            for (int i = 2; i <= int.MaxValue; i++)
            {

                acumulador = 0;
                divisor = i / 2;

                for (int j = 1; j <= divisor; j++)
                {
                    resto = i % j;

                    if (resto == 0)
                        acumulador = acumulador + j;
                }

                    

                if (acumulador == i)
                {
                    resultado++;
                    Console.WriteLine("{0}", i);
                }
                        

            }

            Console.ReadKey();

        }
    }
}
