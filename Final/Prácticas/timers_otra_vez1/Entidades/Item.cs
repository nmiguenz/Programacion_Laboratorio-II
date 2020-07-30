using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Item
    {
        public delegate void EventoReloj(Reloj r, string tiempo);
        public event EventoReloj EventoTiempo;

        private Thread hilo;
        private DateTime inicio;
        private Reloj reloj;

        public Thread Hilo
        {
            get
            {
                return this.hilo;
            }
        }

        public Item(Reloj r, IEvento imprimir)
        {
            //En su constructor se instanciará e iniciará un nuevo Thread para el atributo hilo 
            this.hilo = new Thread(EjecutarReloj);
            hilo.Start();
            this.reloj = r;

            //y se asociará a EventoTiempo el manejador ImprimirReloj de la interfaz IEvento.
            this.EventoTiempo += imprimir.ImprimirReloj;

        }

        /// <summary>
        /// EjecutarReloj:
        //Guardará la fecha de inicio de la rutina.
       //Iterará por tiempo indefinido.
       //Dentro de dicha iteración, lanzará el evento EventoTiempo con el parámetro del tiempo transcurrido desde
        //el inicio de la rutina hasta el momento actual (utilizar método de extensión).
        //Utilizar un Sleep de 100 milisegundos.
        /// </summary>
        public void EjecutarReloj()
        {
            this.inicio = DateTime.Now;
            do
            {
                //Cuando quiero pasarle argumentos al EVENTO, uso INVOKE
                this.EventoTiempo.Invoke(reloj, this.inicio.TiempoTranscurrido());
                Thread.Sleep(100);
                
            } while (true);
        }

    }
}
