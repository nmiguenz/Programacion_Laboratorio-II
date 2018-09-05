using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase5NMM
{
    class Producto
    {
        //ATRIBUTOS
        private string codigoDeBarra;
        private string marca;
        private float precio;

        // MÉTODOS
        public string GetMarca()
        {
            return marca;
        }

        public float GetPrecio()
        {

            return precio;
        }

        // Siempre que el metodo sea de clase usar "static" y acceder con el operador punto.
        public static string MostrarProducto(Producto p)
        {

            return string.Format("Marca: {0}, Codigo de barras: {1}, precio: {2}", p.marca, p.codigoDeBarra, p.precio);
        }

        public Producto(string codigo, string marca, float precio)
        {
            this.codigoDeBarra = codigo;
            this.marca = marca;
            this.precio = precio;
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }

        public static bool operator == (Producto p1, Producto p2)
        {
            return (p1.marca == p2.marca && p1.codigoDeBarra == p2.codigoDeBarra);
        }

        public static bool operator != (Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        /*
         * Igualdad (Producto, string). Retornará true, si la marca del producto coincide con la cadena pasada por parámetro, false,
caso contrario
         */
         public static bool operator == (Producto p1, string marca)
        {
            return p1.marca == marca;
        }

        public static bool operator !=(Producto p1, string marca)
        {
            return !(p1 == marca);
        }
    }
}
