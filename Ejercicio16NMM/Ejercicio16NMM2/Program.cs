using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16NMM2
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumnoUno = new Alumno("Gil", 1548, "Luciano");
            Console.WriteLine("Ingrese la primer nota del alumno {0}",alumnoUno.nombre);
            string valorStringUno = Console.ReadLine();
            byte.TryParse(valorStringUno, out byte numeroUno);
            Console.WriteLine("Ingrese la segunda nota del alumno Uno");
            string valorStringDos = Console.ReadLine();
            byte.TryParse(valorStringDos, out byte numeroDos);
            alumnoUno.Estudiar(numeroUno, numeroDos);
            Console.WriteLine(alumnoUno.Mostrar());
            Console.ReadKey();
            /*
            Alumno alumnoDos = new Alumno("Miguenz", 1547, "Nico");
            Alumno alumnoTres = new Alumno("Gil", 1523, "Luciano");
            */
        }
    }
}
