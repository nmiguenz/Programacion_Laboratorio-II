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

namespace Formularios
{
    public partial class Form1 : Form, IEvento
    {
        IReloj ireloj;
        public Form1()
        {
            InitializeComponent();
            //Instanciar en el constructor un objeto que cumpla con el tipo de la interfaz IReloj.
            ireloj = new Relojes(0,this);
        }

        public void ImprimirReloj(Reloj reloj, string dato)
        {
            if (this.InvokeRequired)
            {
                Item.EventoReloj pos = new Item.EventoReloj(this.ImprimirReloj);
                object[] obj = new object[] { reloj, dato };
                this.Invoke(pos, obj);
            }
            else
            {
                switch (reloj)
                {
                    case Reloj.Primero:
                        this.lbl1.Text = dato;
                        break;
                    case Reloj.Segundo:
                        this.lbl2.Text = dato;
                        break;
                    case Reloj.Tercero:
                        this.lbl3.Text = dato;
                        break;
                    case Reloj.Cuarto:
                        this.lbl4.Text = dato;
                        break;
                }

            }
        }

        private void btnTimer1_Click(object sender, EventArgs e)
        {
            this.StarStopReloj(Reloj.Primero);
        }

        private void btnTimer2_Click(object sender, EventArgs e)
        {
            this.StarStopReloj(Reloj.Segundo);
        }

        private void btnTimer3_Click(object sender, EventArgs e)
        {
            this.StarStopReloj(Reloj.Tercero);
        }

        private void btnTimer4_Click(object sender, EventArgs e)
        {
            this.StarStopReloj(Reloj.Cuarto);
        }

        //El método StartStopReloj invocará al método de la interfaz CargarReloj, controlando la excepción
        //que sea necesaria y mostrando el mensaje de error con un MessageBox.
        private void StarStopReloj(Reloj reloj) 
        {
            try
            {
                ireloj.CargarReloj(reloj);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ireloj.KillEmAll();
        }
    }
}
