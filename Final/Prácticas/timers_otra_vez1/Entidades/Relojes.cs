using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Reloj {Primero, Segundo, Tercero, Cuarto};
    public class Relojes : IReloj
    {

        private int cantidad = 0;
        private Dictionary<Reloj, Item> hilos;
        private IEvento referencia;

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
            //Declaro un atriburo RELOJES que hace  referencia a la entidad para poder quitar el Hilo
            Relojes auxRelojes = this;
            //Chequeará si el Reloj recibido ya figura en el diccionario (utilizar métodos propios de
            //diccionarios, no iterar).
            if (this.hilos.ContainsKey(item))
            {
                //Si existe, comprobar el estado del hilo: si está corriendo frenarlo. Si está frenado, quitarlo
                //con el operador – y volver a agregarlo con el operador +.
                foreach (KeyValuePair<Reloj, Item> auxItem in hilos)
                {
                    if (auxItem.Key == item)
                    {
                        if (auxItem.Value.Hilo.IsAlive)
                        {
                            auxItem.Value.Hilo.Abort();
                        }
                        else
                        {
                            auxRelojes -= item;
                            auxRelojes += item;
                        }
                    }
                }
                return auxRelojes;   
            }
            //Si no existe, comprobar la cantidad máxima permitida (atributo &quot;cantidad&quot;). Si hay
            //lugar, agregarlo; caso contrario lanzar la excepción SinEspacioException con el mensaje & quot; El
            //cupo de relojes está completo.&quot;.
            else
            {
                if (this.cantidad < 4)
                {
                    auxRelojes += item;
                    this.cantidad++;

                }
                else
                {
                    throw new SinEspacioException("El cupo de relojes esta completo");
                }
                return auxRelojes;
            }
        }

        //killEmAll recorrerá todo el diccionario y cancelará todos los hilos activos. Al
        public void KillEmAll()
        {
            //para recorrer todo el DICCIONARIO, lo tengo que hacer por su KeyValuePair
            foreach (KeyValuePair<Reloj,Item> item in hilos)
            {
                if (item.Value.Hilo.IsAlive)
                    item.Value.Hilo.Abort();
            }
            this.Guardar("hilos.txt", this.hilos);

        }

        //Operador +: creará un nuevo objeto del tipo Item y lo cargará al diccionario &quot;hilos&quot;.
        public static Relojes operator +(Relojes r, Reloj item)
        {
            //Crear = instanciar
            Item objeto = new Item(item, r.referencia);
            r.hilos.Add(item, objeto);
            return r;
        }

        //Operador -: quitará un objeto del tipo Item del diccionario hilos.
        public static Relojes operator -(Relojes r, Reloj item)
        {
            //Remove quita el objeto a partir de la KEY
            r.hilos.Remove(item);
            return r;
        }

        public void Guardar(string archivo, Dictionary<Reloj, Item> hilos)
        {

            //Recibe como parametro el archivo a escribir
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo);
            StreamWriter sw = new StreamWriter(path);
            
            try
            {
                //agrego una linea de texto
                foreach (KeyValuePair<Reloj, Item> item in hilos)
                {
                    sw.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo guardar el archivo .txt", e);
            }
            finally
            {
                sw.Close();
            }

        }
    }
}
