using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor : Persona
    {
        #region ATRIBUTOS
        DateTime fechaIngreso;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Read Only. Devuelve la cantidade de días que pasaron desde que ingreso hasta el día de hoy
        /// </summary>
        public int Antiguedad
        {
            get
            {
                return (int)((DateTime.Today - this.fechaIngreso).TotalDays);
            }
        }
        #endregion

        #region MÉTODOS
        public Profesor(string nombre, string apellido, string documento) : base(nombre, apellido, documento)
        {

        }
        public Profesor(string nombre, string apellido, string documento, DateTime fechaIngreso):base(nombre, apellido, documento)
        {
            this.fechaIngreso = fechaIngreso;
        }

        /// <summary>
        /// Recopila los datos del profesor con el agregado de la antiguedad
        /// </summary>
        /// <returns>Datos del profesor</returns>
        public override string ExponerDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExponerDatos());
            sb.AppendLine(String.Format("Fecha de ingreso: {0} - Antiguedad: {1}", this.fechaIngreso, 
                (DateTime.Today - this.fechaIngreso).TotalDays));
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el documento tenga exactamente 8 caracteres.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>TRUE si cumple con la extension; FALSE si no lo hace</returns>
        protected override bool ValidarDocumentacion(string doc)
        {
            //Valido que cumpla con la extension del documento
            if (doc.Length == 8)
                return true;

            return false;
        }
        #endregion
    }
}
