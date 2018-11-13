using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
    public static class ToSql
    {
        public static DateTime FechaExtension(this DateTime fecha)
        {
            DateTime fechaNac;
            fechaNac = fecha;
            return fechaNac;
        }    
    }

    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();

           
        }
    }
}
