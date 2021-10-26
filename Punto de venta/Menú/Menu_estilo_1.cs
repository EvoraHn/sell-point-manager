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
        string modulo = "";
        public Menu_estilo_1()
        {
            InitializeComponent();  
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Mantenimientos.Mantenimiento_Productos(modulo));
        }
        public void abrirFormularioHijo(object formHijo)
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
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void logo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
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

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Ventas.Formulario_Ventas());
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Compras.Formulario_Compras());
        }

        private void Menu_estilo_1_Load(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Reporteria.PresentadordeReportes());
            
        }

        private void Menu_estilo_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.NumPad1)
            {
                btnInventario.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad3)
            {
                btnVentas.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad2)
            {
                btnComprar.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad5)
            {
                abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
            }
        }
    }
}
