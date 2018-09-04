using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero;

            //Ingrese un numero

            Console.WriteLine("Ingrese un numero mayor a 0: ");
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");

            }

            // verifica que el numero sea mayor a 0

            if (numero > 0)
            {
                // Imprime el cuadrado y el cubo del numero ingresado
                Console.WriteLine("El cuadrado del numero: {0}, es: {1} y el cubo: {2}", numero, numero * numero, numero * numero * numero);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error. El valor ingresado es menor o igual a 0");
                Console.ReadKey();
            }
                
        }
    }
}
