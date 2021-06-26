using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Menú
{
    public partial class Menu_estilo_1 : Form
    {
        public Menu_estilo_1()
        {
            InitializeComponent();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Mantenimientos.Mantenimiento_Productos());

     
        }
        private void abrirFormularioHijo(object formHijo)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.RemoveAt(0);
                Form fh = formHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelPrincipal.Controls.Add(fh);
                this.panelPrincipal.Tag = fh;
                fh.Show();
            

               
        }

       

        private void cerrarXToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void logo_Click(object sender, EventArgs e)
        {
            //if (panelBotones.Width == 273)
            //{
            //    panelBotones.Width = 100;
            //    panelPrincipal.Width = 1173;
            //    panelMenu.Width = 1173;

            //}
            //else
            //    panelBotones.Width = 273;
            //    panelPrincipal.Width = 1000;
            //    panelMenu.Width = 1000;
        }

       
    }
}
