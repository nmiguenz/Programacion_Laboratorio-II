using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Reloj {Primero, Segundo, Tercero, Cuarto}
    public class Relojes :  IReloj
    {

        private int cantidad;
        private IEvento referencia;
        private Dictionary<Reloj, Item> hilos;

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public IEvento Referencia { get => referencia; set => referencia = value; }
        public Dictionary<Reloj, Item> Hilos { get => hilos; set => hilos = value; }
    
        private Relojes()
        {
            Dictionary<Reloj, Item> diccionario = new Dictionary<Reloj, Item>();
        }

        public Relojes(int cantidad, IEvento referencia)
        {
            this.cantidad = cantidad;
            this.referencia = referencia;
        }

        public void KillEmAll()
        {

        }

        public Relojes CargarReloj(Item item)
        {
            //Chequeará si el Reloj recibido ya figura en el diccionario (utilizar métodos propios de
            //diccionarios, no iterar).

            throw new NotImplementedException();
        }

        public static Relojes operator +(Relojes r, Reloj item)
        {

            return r;
        }
        public static Relojes operator -(Relojes r, Reloj item)
        {
            return r;
        }

    }

}
