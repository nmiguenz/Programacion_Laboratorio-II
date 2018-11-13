using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        string nombre;
        string apellido;
        DateTime fechaNac;
        int dni;
        string direccion;

        #region PROPIEDADES
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
        }
        #endregion

        #region CONSTRUCTORES
        Alumno()
        {
            this.fechaNac = DateTime.Now;
        }

        Alumno(string nombre, string apellido, DateTime fecha, int dni, string direccion): this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fecha;
            this.dni = dni;
            this.direccion = direccion;
        }
        #endregion
    }
}
