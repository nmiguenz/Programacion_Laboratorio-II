using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase5NMM
{
    class Estante
    {
        private int ubicacionEstante;
        private Producto[] productos;

        /// <summary>
        /// Inicializo un nuevo estante, segun la capacidad.
        /// </summary>
        /// <param name="capacidad"></param>
        private Estante(int capacidad)
        {
            productos = new Producto[capacidad];
        }

        // Los dos puntos lo que haces es heredar del private Estante() de arriba
        /// <summary>
        /// Inicializo un nuevo estante, asignando los atributos capacidad y ubicación.
        /// </summary>
        /// <param name="capacidad">Cantidad de productos que podrá contener el estante</param>
        /// <param name="ubicacion">Código de ubicación del estante</param>
        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.productos = new Producto[ubicacion];
        }

        /// <summary>
        /// Obtengo la lista de productos
        /// </summary>
        /// <returns></returns>
        public Producto[] GetProducto()
        {
            return this.productos;
        }

        /// <summary>
        /// Se muestran los datos del estante elegido
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder mystringBuielder = new StringBuilder();

            foreach (Producto producto in e.productos)
            {
                mystringBuielder.AppendFormat("Producto : {0}, ubicacion {1}", producto.GetMarca(), e.ubicacionEstante);
            }

            return mystringBuielder.ToString();
        }

        /// <summary>
        /// Analiza si el producto esta en el estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Estante e, Producto p)
        {
            // Recorro la lista de productos del estante
            foreach (Producto productoEstante in e.productos)
            {
                // Valido que la posición del arrey no sea null
                if (!object.ReferenceEquals(productoEstante, null))
                {
                    // Utilizo la sobrecarga del == de Producto
                    if (productoEstante == p)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Analiza si el producto NO esta en el Estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }


        public static bool operator +(Estante e, Producto p)
        {
            // Si el Estante no contiene el Producto...
            if (e != p)
            {
                // Recorro la lista de productos del estante
                for (int i = 0; i < e.productos.Length; i++)
                {
                    // Busco un espacio vacio
                    if (Object.ReferenceEquals(e.productos[i], null) )
                    {
                        e.productos[i] = p;
                        // Si se agrega el producto, rompo el lazo iterativo
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Saca un producto del estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto p)
        {
            // Recorro la lista de productos del estante...
            for (int i = 0; i < e.productos.Length; i++)
            {
                // Valido que la posición del Array no sea null
                if (!object.ReferenceEquals(e.productos[i], null))
                {
                    if (p == e.productos[i])
                    {
                        // Vacio el espacio que ocupaba dicho Producto
                        e.productos[i] = null;
                        // Rompo el lazo
                        break;
                    }
                }
            }
            return e;
        }
            
    }
}
