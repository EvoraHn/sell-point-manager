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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            //DataSet1 dataPrueba = new DataSet1();
            //DataSet1.ProductoDataTable PTest = new DataSet1.ProductoDataTable();
            //// TODO: esta línea de código carga datos en la tabla 'dataSet1.Producto' Puede moverla o quitarla según sea necesario.
            //this.productoTableAdapter.Fill(PTest);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(PTest);
            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
