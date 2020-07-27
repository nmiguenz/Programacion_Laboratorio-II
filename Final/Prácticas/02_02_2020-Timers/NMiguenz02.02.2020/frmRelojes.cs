using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NMiguenz02._02._2020.Entidades;

namespace NMiguenz02._02._2020
{
    public partial class frmRelojes : Form, IEvento
    {
        private IReloj IRelojes;
        public frmRelojes()
        {
            IRelojes = new Relojes(4,this);
            InitializeComponent();
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.StartStopReloj(Reloj.Primero);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.StartStopReloj(Reloj.Segundo);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.StartStopReloj(Reloj.Tercero);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.StartStopReloj(Reloj.Cuarto);
        }

        //El método StartStopReloj invocará al método de la interfaz CargarReloj, 
        //controlando la excepción que sea necesaria y mostrando el mensaje de error con un MessageBox.
        private void StartStopReloj(Reloj reloj)
        {
            try
            {
                IRelojes.CargarReloj(reloj);
            }
            catch (Exception e)
            {
                throw new SinEspacioException(e.Message);
            }
                
        }

        //ImprimirReloj mostrará en pantalla el valor recibido, dependiendo del valor del enumerado, 
        //siendo Reloj.Primero el label lblTimer1 (primero de izquierda a derecha) y así sucesibamente.
        public void ImprimirReloj(Reloj reloj, string dato)
        {
            if (this.InvokeRequired)
            {
                Item.EventoTiempo pos = new Item.EventoTiempo(ImprimirReloj);
                object[] obj = new object[] { reloj, dato };
                this.Invoke(pos, obj);
            }
            else
            {
                switch (reloj)
                {
                    case Reloj.Primero:
                        lbl1.Text = dato;
                        break;
                    case Reloj.Segundo:
                        lbl2.Text = dato;
                        break;
                    case Reloj.Tercero:
                        lbl3.Text = dato;
                        break;
                    case Reloj.Cuarto:
                        lbl4.Text = dato;
                        break;
                }
            }
        }

        private void frmRelojes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IRelojes.killEmAll();

        }
    }
}
