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

        private Estante(int capacidad)
        {
            productos = new Producto[capacidad];
        }

        // Los dos puntos lo que haces es heredar del private Estante() de arriba
        public Estante(int capacidad, int ubicacion) : this(capacidad)
        {
            this.productos = new Producto[ubicacion];
        }

        public Producto[] GetProducto()
        {
            return productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder mystringBuielder = new StringBuilder();

            foreach (Producto producto in e.productos)
            {
                mystringBuielder.AppendFormat("Producto : {0}, ubicacion {1}", producto.GetMarca(), e.ubicacionEstante);
            }

            return mystringBuielder.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            foreach (Producto productoEstante in e.productos)
            {
                if (productoEstante == p)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return false;
        }

        public static bool operator +(Estante e, Producto p)
        {
            // Si el Estante no contiene el Producto...
            if (e != p)
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (Object.ReferenceEquals(e.productos[i], null) )
                    {
                        e.productos[i] = p;

                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator -(Estante e, Producto p)
        {
            if (e !=)
        }
            
    }
}
