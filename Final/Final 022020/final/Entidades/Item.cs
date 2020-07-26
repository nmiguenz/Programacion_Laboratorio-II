using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

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

        //En su constructor se instanciará e iniciará un nuevo Thread para el atributo "hilo" y se asociará a
        //EventoTiempo el manejador ImprimirReloj de la interfaz IEvento.
        public Item(Reloj r, IEvento imprimir)
        {
            //No se si esta bien????
            hilo.Start();
            
            // Asocio el EVENTO al manejador
            this.EventoTiempo += imprimir.ImprimirReloj;

        }

        public void EjecutarReloj()
        {
            DateTime horaInicio = DateTime.Now;

            //Iterará por tiempo indefinido.
            do
            {
                //Dentro de dicha iteración, lanzará el evento EventoTiempo con el parámetro del tiempo
                //transcurrido desde el inicio de la rutina hasta el momento actual(utilizar método de extensión).
                //iv.Utilizar un Sleep de 100 milisegundos
                this.EventoTiempo.Invoke(reloj, horaInicio.TiempoTranscurrido());
                Thread.Sleep(100);

            } while (true);

        }


    }
}
