using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NMiguenz02._02._2020.Entidades
{
    public class Item
    {

        public delegate void EventoTiempo(Reloj r, string tiempo);
        public event EventoTiempo EventoReloj;

        Thread hilo;
        private DateTime inicio;
        Reloj reloj;

        public Thread Hilo
        {
            get
            {
                return this.hilo;
            }
        }

        public Item()
        {

        }

        //En su constructor se instanciará e iniciará un nuevo Thread para el atributo hilo y se asociará a
        //EventoTiempo el manejador ImprimirReloj de la interfaz IEvento.
        public Item(IEvento imprimir, Reloj r)
        {
            //Creamos un delegado indicándole el nombre del método que correrá, luego creamos una instancia de 
            //Thread indicandole el delegado que será ejecutado y por último damos inicio al proceso pero por 
            //medio del hilo. (en un subproceso).
            this.reloj = r;
            this.hilo = new Thread(EjecutarReloj);
            this.EventoReloj += imprimir.ImprimirReloj;
            this.hilo.Start();

        }

        public void EjecutarReloj()
        {
            this.inicio = DateTime.Now;

            //Iterará por tiempo indefinido.
            do
            {
                //Dentro de dicha iteración, lanzará el evento EventoTiempo con el parámetro del tiempo
                //transcurrido desde el inicio de la rutina hasta el momento actual(utilizar método de extensión).
                //iv.Utilizar un Sleep de 100 milisegundos
                this.EventoReloj.Invoke(reloj, this.inicio.TiempoTranscurrido());
                Thread.Sleep(100);

            } while (true);
        }

    }
}
