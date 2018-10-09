using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        string apellido;
        string nombre;
        string documento;
        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Read only. Devuelve el apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        /// <summary>
        /// Read only. Devuelve el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        /// <summary>
        /// Get: Devuelve el documento
        /// Set: setea el documento si la validacion es verdadera.
        /// </summary>
        public string Documento
        {
            get
            {
                return this.documento;
            }

            set
            {
                if (ValidarDocumentacion(value))
                    this.documento = value;
            }
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// Recopila los datos de la persona
        /// </summary>
        /// <returns>Devuelve los datos de la persona</returns>
        public virtual string ExponerDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("Nombre {0}", this.nombre));
            sb.AppendLine(String.Format("Apellido {0}", this.apellido));
            sb.AppendLine(String.Format("Documento {0}", this.documento));
            return sb.ToString();
        }

        /// <summary>
        /// Constructor de persona con parámetros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="documento"></param>
        public Persona(string nombre, string apellido, string documento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
        }

        /// <summary>
        /// Método a implementar en clases hijas
        /// Verifica la validez del documento
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>TRUE si el documento es valido, FALSE si no lo es</returns>
        protected abstract bool ValidarDocumentacion(string doc);
        #endregion
    }
}
