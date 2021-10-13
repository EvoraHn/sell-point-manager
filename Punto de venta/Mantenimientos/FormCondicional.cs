using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Mantenimientos
{
    public partial class FormCondicional : Form
    {
        string Acceso = "";
        public FormCondicional(string modulo)
        {
            Acceso = modulo;
            InitializeComponent();
        }

        private void FormCondicional_Load(object sender, EventArgs e)
        {
            if (Acceso == "Administración")
            {
                button1.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Acceso == "Administración")
            {
                button1.Enabled = false;
            }
            MessageBox.Show(Acceso);
        }
    }
}
