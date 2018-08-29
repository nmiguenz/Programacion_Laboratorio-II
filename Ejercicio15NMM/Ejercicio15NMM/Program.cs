using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15NMM
{
    class Program
    {
        static void Main(string[] args)
        {
      
            Console.WriteLine("Ingrese el primer numero");
            string valorStringUno = Console.ReadLine();
            int.TryParse(valorStringUno, out int numeroUno);
            Console.WriteLine("Ingrese el segundo numero");
            string valorStringDos = Console.ReadLine();
            int.TryParse(valorStringDos, out int numeroDos);
            Console.WriteLine("Qué operación quiere realizar?");
            string valorOperador = Console.ReadLine();
            char.TryParse(valorOperador, out char opera);
            Console.WriteLine(Calculadora.Calcular(numeroUno, numeroDos, opera));
        
            Console.ReadKey();
        }
    }
}
