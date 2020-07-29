using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using Archivos;
using System.Threading;

using Patentes;

namespace _20181122_SP
{
    public partial class FrmPpal : Form
    {


        Queue<Patente> cola;
        //Declarar un atributo del tipo lista de Threads
        List<Thread> hilos;
        

        public FrmPpal()
        {
            InitializeComponent();
            this.cola = new Queue<Patente>();
            //Inicializarlo en el constructor
            this.hilos = new List<Thread>();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            // asociar el evento VistaPatente para los objetos vistaPatente1 y vistaPatente2 con el manejador
            this.vistaPatente1.finExposicion += ProximaPatente;
            this.vistaPatente2.finExposicion += ProximaPatente;
        }

        // Asegurarse de que todos los hilos estén terminados. Agregar el método FinalizarSimulacion que cumpla esa función.
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FinalizarSimulacion();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            //En cada botón leer del origen que corresponda (SQL, XML, TXT) agregar los datos a la cola de Patentes.
            //También capturar las excepciones y llamar al método IniciarSimulacion.
            try
            {
                List<Patente> list;
                Xml<List<Patente>> xmlItem = new Xml<List<Patente>>();

                //Leo cada elemento y lo agrego a una lista auxiliar
                xmlItem.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\patentes.xml", out list);

                //agrego en la COLA los elementos guardados en la lista
                this.cola = new Queue<Patente>(list.AsEnumerable());
            }
            catch (Exception exc)
            {

                throw new Exception("No se pudo leer el archivo XML", exc);
            }
            //llamar al método IniciarSimulacion.
            this.IniciarSimulacion();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                Texto text = new Texto();
                text.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\patentes.txt", out this.cola);
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
            this.IniciarSimulacion();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sql = new Sql();

                //La direccion de la tabla se pasa por parametr
                sql.Leer("patentes", out this.cola);
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
            this.IniciarSimulacion();
        }

        private void FinalizarSimulacion()
        {
            
            foreach (Thread item in hilos)
            {
                if(!(item is null))
                {
                    if (item.IsAlive)
                        item.Abort();
                }
            }
        }

        //Agregar el manejador del evento de la clase VistaPatente con el nombre ProximaPatente.
        private void ProximaPatente(Patentes.VistaPatente vp)
        {
            //si hay elementos en la cola de patentes
            if (this.cola.Count > 0)
            {
                //Instanciará un hilo parametrizado para el método MostrarPatente del objeto VistaPatente recibido
                Thread t = new Thread(new ParameterizedThreadStart(vp.MostrarPatente));
                
                //Inicializará el hilo recién creado con el próximo elemento de la cola.
                t.Start(this.cola.Dequeue());

                //Agregará el hilo a la lista.
                this.hilos.Add(t);
            }
        }
        
        private void IniciarSimulacion()
        {
            //Finalizará los hilos activos.
            this.FinalizarSimulacion();

            //Llamará al método ProximaPatente para cada uno de los objetos del tipo VistaPatente del formulario
            this.ProximaPatente(this.vistaPatente1);
            this.ProximaPatente(this.vistaPatente2);
        }
    }
}
