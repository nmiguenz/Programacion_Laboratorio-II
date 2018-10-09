using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno : Persona
    {
        #region ATRIBUTOS
        short anio;
        Divisiones division;
        #endregion

        #region PROPIEDADES
        public string AnioDivision
        {
            get
            {
                return String.Format("{0}º{1}", this.anio, this.division.ToString());
            }
        }
        #endregion

        #region MÉTODOS
        public Alumno(string nombre, string apellido, string documento, short anio, Divisiones division) : base(nombre, apellido, documento)
        {
            this.anio = anio;
            this.division = division;
        }

        /// <summary>
        /// Recopila informacion del alumno
        /// </summary>
        /// <returns></returns>
        public override string ExponerDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExponerDatos());
            sb.AppendLine(String.Format("Division {0}", this.AnioDivision));
            return sb.ToString();
        }

        /// <summary>
        /// Valida que la documentacion cumpla con el siguiente formato:  XX-XXXX-X
        /// </summary>
        /// <param name="doc">Documentacion a analizar</param>
        /// <returns>TRUE si el documento es valido, FALSE si no lo es</returns>
        protected override bool ValidarDocumentacion(string doc)
        {
            //Valido que cumpla con la extension del documento
            if (doc.Length == 9)
            {
                for(int i= 0; i<doc.Length; i++)
                {
                    //Valido los guiones
                    if(i== 2 || i==7)
                    {
                        if (doc[i] != '-')
                            return false;
                    }
                    else
                    {
                        if (!char.IsNumber(doc[i]))
                            return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
