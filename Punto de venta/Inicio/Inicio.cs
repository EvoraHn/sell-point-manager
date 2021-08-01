using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Punto_de_venta.Inicio
{
    public partial class Inicio : Form
    {   
        
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        DataView mifiltro;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(0, 0, "https://wa.me/qr/ZV523Y7QNQHCE1");
            Mostrar_datos();
            Reloj();
            cargarGrafico();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Vista1
                             where p.Existencias < 10
                             select new
                             {
                                 //p.Codigo,
                                 p.Producto,
                                 p.Existencias
                               
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgProductos.DataSource = mifiltro;

        }
        private void Reloj()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDía.Text = DateTime.Now.DayOfWeek.ToString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFechaCompleta.Text = DateTime.Now.ToShortDateString();
            
        }
        private void cargarGrafico()
        {
            var tMeses = from p in entity.VistaVentasPorMes
                         select new
                         {
                             p.Enero,
                             p.Febrero,
                             p.Marzo,
                             p.Abril,
                             p.Mayo,
                             p.Junio,
                             p.Julio,
                             p.Agosto,
                             p.Septiembre,
                             p.Octubre,
                             p.Noviembre,
                             p.Diciembre

                         };
            var tMeses1 = from p in entity.Producto
                         select new
                         {
                             p.IdProducto,
                             

                         };
            double Enero = Convert.ToDouble(tMeses.FirstOrDefault().Enero);
            double Febrero = Convert.ToDouble(tMeses.FirstOrDefault().Febrero);
            double Marzo = Convert.ToDouble(tMeses.FirstOrDefault().Marzo);
            double Abril = Convert.ToDouble(tMeses.FirstOrDefault().Abril);
            double Mayo = Convert.ToDouble(tMeses.FirstOrDefault().Mayo);
            double Junio = Convert.ToDouble(tMeses.FirstOrDefault().Junio);
            double Julio = Convert.ToDouble(tMeses.FirstOrDefault().Julio);
            double Agosto = Convert.ToDouble(tMeses.FirstOrDefault().Agosto);
            double Septiembre = Convert.ToDouble(tMeses.FirstOrDefault().Septiembre);
            double Octubre = Convert.ToDouble(tMeses.FirstOrDefault().Octubre);
            double Noviembre = Convert.ToDouble(tMeses.FirstOrDefault().Noviembre);
            double Diciembre = Convert.ToDouble(tMeses.FirstOrDefault().Diciembre);
            double[] puntos = { Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre};
            
            string[] series = { "Enero", "febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            
            //ctMeses.Titles.Add("Ventas Por mes en este año");
            for (int i = 0; i < series.Length; i++)
            {
                //titulos
                Series serie = ctMeses.Series.Add(series[i]);

                // cantidades 
                //serie.Label = "L "+ puntos[i].ToString();
                serie.Label = puntos[i].ToString();
                serie.Points.Add(puntos[i]);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
