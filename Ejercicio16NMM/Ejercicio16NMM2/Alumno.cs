using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ejercicio16NMM2
{
    class Alumno
    {
        private byte nota1;
        private byte nota2;
        private float notaFinal;
        public string apellido;
        public int legajo;
        public string nombre;

        public void CalcularFinal()
        {
            if (this.nota1 >= 4 && this.nota2 >= 4)
            {
                Random random = new Random();
                this.notaFinal = random.Next(11);
            }

            else
            {
                this.notaFinal = -1;
            }
                
        }

        public void Estudiar(byte notaUno, byte notaDos)
        {
            this.nota1 = notaUno;
            this.nota2 = notaDos;
        }
        
        public string Mostrar()
        {
            if (notaFinal != -1)
                return string.Format("Nombre: {0}, Apellido {1}, Legajo: {2}, Nota Final: {3}", nombre, apellido, legajo, notaFinal);

            else
                return string.Format("Nombre: {0}, Apellido {1}, Legajo: {2}, 'Alumno desaprobado'", nombre, apellido, legajo);
        }

        public Alumno (string surname, int legajo, string name)
        {
            this.nombre = name;
            this.apellido = surname;
            this.legajo = legajo;
            this.nota1 = 0;
            this.nota2 = 0;
            this.notaFinal = -1;
        }

    }
}
