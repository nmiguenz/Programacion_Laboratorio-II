using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1NMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int variable1;
            int variable2;
            int variable3;
            int variable4;
            int variable5;

            int maximo;
            int minimo;
            float acumPromedio;

            // VERSION 1
            // Pido el primer valor
            Console.WriteLine("Ingrese el primer valor: ");
            while (!int.TryParse(Console.ReadLine(), out variable1))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");
            }
            // Inicializo máximo y mínimo con la primer variable
            maximo = variable1;
            minimo = variable1;

            // Limpio la consola
            Console.Clear();

            //Pido el segundo numero
            Console.WriteLine("Ingrese el segundo valor: ");
            while (!int.TryParse(Console.ReadLine(), out variable2))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");
            }
            // Limpio pantalla y pido el tercer valor
            Console.Clear();
            Console.WriteLine("Ingrese el tercer valor: ");
            while (!int.TryParse(Console.ReadLine(), out variable3))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");
            }
            // Limpio pantalla y pido el cuarto valor
            Console.Clear();
            Console.WriteLine("Ingrese el cuarto valor: ");
            while (!int.TryParse(Console.ReadLine(), out variable4))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");
            }
            // Limpio pantalla y pido el quinto valor
            Console.Clear();
            Console.WriteLine("Ingrese el quinto valor: ");
            while (!int.TryParse(Console.ReadLine(), out variable5))
            {
                Console.WriteLine("Error. Ingrese un valor entero y numérico.");
            }
            // Calculo máximo, mínimo y promedio
            if (maximo < variable2)
                maximo = variable2;
            if (minimo > variable2)
                minimo = variable2;
            if (maximo < variable3)
                maximo = variable3;
            if (minimo > variable3)
                minimo = variable3;
            if (maximo < variable4)
                maximo = variable4;
            if (minimo > variable4)
                minimo = variable4;
            if (maximo < variable5)
                maximo = variable5;
            if (minimo > variable5)
                minimo = variable5;

            //Calculo el acumulado
            acumPromedio = variable1 + variable2 + variable3 + variable4 + variable5;

            // Imprimo por pantalla 
            Console.WriteLine("El valor máximo es {0}, el mínimo: {1} y el promedio es: {2}", maximo, minimo, acumPromedio / 5);

            //Utilizo esto para que quede en pantalla
            Console.ReadKey();
            Console.Clear();


            // VERSION 2
            acumPromedio = 0;
            int cont = 1;
            int auxI;
            while (cont < 6)
            {
                // Limpio pantalla y pido un valor, indicando con cont que valor es
                Console.WriteLine("Ingrese el " + cont + " valor: ");
                if (int.TryParse(Console.ReadLine(), out auxI))
                {
                    // Si pudo convertir el valor a int, me fijo que valor es
                    switch (cont)
                    {
                        case 1:
                            variable1 = auxI;
                            // Inicializo máximo y mínimo con la primer variable
                            maximo = variable1;
                            minimo = variable1;
                            break;
                        case 2:
                            variable2 = auxI;
                            break;
                        case 3:
                            variable3 = auxI;
                            break;
                        case 4:
                            variable4 = auxI;
                            break;
                        case 5:
                            variable5 = auxI;
                            break;
                    }
                    // Compruebo máximo, mínimo y acumulador de promedio
                    if (maximo < auxI)
                        maximo = auxI;
                    if (minimo > auxI)
                        minimo = auxI;
                    acumPromedio += auxI;

                    // Incremento el contador
                    cont++;

                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Error. Ingrese un valor entero y numérico.");
                }
            }
            Console.WriteLine("El valor máximo es {0}, el mínimo {1} y el promedio {2}", maximo, minimo, acumPromedio / 5);

            //--------------------------------------------------------------
            // FIN EJERCICIO Nº1
            Console.ReadKey();
            Console.Clear();
        }
    }
}
