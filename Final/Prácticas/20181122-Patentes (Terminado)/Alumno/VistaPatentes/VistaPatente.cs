using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Entidades;

namespace Patentes
{
    //Agregar dos delegados al NameSpace (por fuera de la clase) con el siguiente formato void
    //FinExposicionPatente(VistaPatente vp) y void MostrarPatente(object patente).
    public delegate void FinExposicionPatente(VistaPatente vp);
    public delegate void MostrarPatente(object patente);
    public partial class VistaPatente : UserControl
    {
        //Evento
        public event FinExposicionPatente finExposicion;
        public VistaPatente()
        {
            InitializeComponent();

            picPatente.Image = fondosPatente.Images[(int)Patente.Tipo.Mercosur];
        }

        //Dentro del método MostrarPatente se deberá lograr que se muestre la patente durante un tiempo X y luego
        //notificar por medio de un evento que finalizó dicha exposición.
        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    Random r = new Random();

                    // Llamar al hilo principal 
                    if (this.InvokeRequired)
                    {
                        //El delegado
                        MostrarPatente d = new MostrarPatente(this.MostrarPatente);
                        this.Invoke(d, new object[] {patente});
                    }
                    else
                    {
                        if(patente is Patente)
                        {
                            this.lblPatenteNro.Text = ((Patente)patente).CodigoPatente;
                        }
                    }
                    Thread.Sleep(r.Next(2000, 5000));

                    // Agregar evento de que finalizó la exposición de la patente
                    finExposicion.Invoke(this);
                }
                catch (Exception) { }
            }
            else
            {
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();
            }
        }

    }
}
