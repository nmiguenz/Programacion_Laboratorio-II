using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMiguenz02._02._2020.Entidades
{
    public enum Reloj
    {
        Primero,
        Segundo,
        Tercero, 
        Cuarto
    };
    
    public class Relojes : IReloj
    {
        
        int cantidad;
        Dictionary<Reloj,Item> hilos;
        IEvento referencia;

        private Relojes()
        {
            this.hilos = new Dictionary<Reloj, Item>();
        }

        public Relojes(int cantidad, IEvento referencia) : this()
        {
            this.cantidad = cantidad;
            this.referencia = referencia;
        }

        public Relojes CargarReloj(Reloj item)
        {
            Relojes auxReloj = this;
            if (hilos.ContainsKey(item))
            {
                foreach (KeyValuePair<Reloj, Item> auxItem in hilos)
                {
                    if(auxItem.Key == item)
                    {

                        if (hilos[item].Hilo.IsAlive)
                        {
                            hilos[item].Hilo.Abort();
                        }
                        else
                        {
                            //Si está frenado, quitarlo con el operador – y volver a agregarlo con el operador +
                            auxReloj -= item;
                            auxReloj += item;
                        }
                    }
                }
                return auxReloj;
            }
            else
            {
                if (this.cantidad <= 4)
                {
                    auxReloj += item;
                }
                else
                {
                    throw new SinEspacioException("El cupo de relojes está completo");
                }
                return auxReloj;
            }
            
        }

        //Operador +: creará un nuevo objeto del tipo Item y lo cargará al diccionario hilos
        public static Relojes operator +(Relojes r, Reloj item)
        {
         
            Item valor = new Item(r.referencia, item);
            r.hilos.Add(item, valor);
           
            return r;
        }

        //Operador -: quitará un objeto del tipo Item del diccionario hilos
        public static Relojes operator -(Relojes r, Reloj item)
        {
            r.hilos.Remove(item);
            return r;
        }

        /*killEmAll recorrerá todo el diccionario y cancelará todos los hilos activos.
        Al mismo tiempo guardará en 2 formatos el tiempo transcurrido de cada reloj(generar todo lo necesario).*/
        public void killEmAll()
        {
            foreach (KeyValuePair<Reloj, Item> item in this.hilos)
            {
                if (item.Value.Hilo.IsAlive)
                {
                    item.Value.Hilo.Abort();
                }
            }
        }

        
    }
}
