using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio15NMM
{
    class Calculadora
    {
        public static float Calcular (int numero1, int numero2, char operador)
        {
            float resultado = -32767;
            switch (operador){
                case '+':
                    resultado = numero1 + numero2;
                    break;
                case '-':
                    resultado = numero1 - numero2;
                    break;
                case '*':
                    resultado = numero1 * numero2;
                    break;
                case '/':
                    if (ValidarDivison(numero2) == true)
                        resultado = numero1 / numero2;
                    break;
            }
            if (operador == -32767)
                return 0;

            return resultado;
        }

        static bool ValidarDivison (int numero2)
        {
            if (numero2 != 0)
                return true;
            else
                return false;
        }
    }
}
