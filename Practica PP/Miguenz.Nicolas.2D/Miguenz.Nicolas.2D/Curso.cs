using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        #region ATRIBUTOS
        List<Alumno> alumnos;
        short anio;
        Divisiones division;
        Profesor profesor;
        #endregion

        #region PROPIEDADES
        public string AnioDivision
        {
            get
            {
                return String.Format("{0}°{1}", this.anio, this.division.ToString());
            }
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Constructor privado con instancia de la lista
        /// </summary>
        private Curso()
        {
            this.alumnos = new List<Alumno>();
        }

        public Curso(short anio, Divisiones division, Profesor profesor) : this()
        {
            this.anio = anio;
            this.division = division;
            this.profesor = profesor;
        }

        /// <summary>
        /// Recopila informacion del curso incluyendo a los alumnos y el profesor
        /// </summary>
        /// <param name="c">Curso del cual se recopila la informacion</param>
        public static explicit operator string (Curso c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Curso: {0}", c.AnioDivision));
            sb.AppendLine("PROFESOR");
            sb.AppendLine(c.profesor.ExponerDatos());
            sb.AppendLine("ALUMNOS");
            foreach (Alumno alum in c.alumnos)
            {
                sb.AppendLine(alum.ExponerDatos());
                sb.AppendLine("-----------------");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Verifica que el alumno pertenezca al curso mediante anio y division
        /// </summary>
        /// <param name="c">Curso en el cual se busca al alumno</param>
        /// <param name="a">Alumno en particular que se buscará en el curso</param>
        /// <returns>TRUE si pertenece al curso; FALSE si no</returns>
        public static bool operator ==(Curso c, Alumno a)
        {
            foreach(Alumno alum in c.alumnos)
            {
                if (String.Compare(alum.AnioDivision, c.AnioDivision) == 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que el alumno pertenezca al curso mediante anio y division
        /// </summary>
        /// <param name="c">Curso en el cual se busca al alumno</param>
        /// <param name="a">Alumno en particular que se buscará en el curso</param>
        /// <returns>False si encuentra al alumno; True lo contrario</returns>
        public static bool operator !=(Curso c, Alumno a)
        {
            return !(c == a);
        }

        /// <summary>
        /// Agrega alumnos a la lista de alumnos del curso siempre y cuando compartan la misma division y anio 
        /// </summary>
        /// <param name="c">Curso al cual se agrega el alumno</param>
        /// <param name="a">Alumno que se va a agregar al curso</param>
        /// <returns>Devuelve el curso</returns>
        public static Curso operator +(Curso c, Alumno a)
        {
            if (String.Compare(c.AnioDivision, a.AnioDivision) == 0)
                c.alumnos.Add(a);

            return c;
        }
        #endregion
    }
}
