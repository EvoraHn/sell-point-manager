using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Reportes
{
    public partial class Tesrts : Form
    {
        public Tesrts()
        {
            InitializeComponent();
        }

        private void Tesrts_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'BPBDataSet1.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.BPBDataSet1.Producto);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
