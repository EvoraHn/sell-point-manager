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
                                 p.Codigo,
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
            lblFechaCompleta.Text = DateTime.Now.Date.ToString();
            
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
            double vars = Convert.ToDouble(tMeses.FirstOrDefault().Enero);
            double[] puntos = { vars};
            //double[] puntos = { 10,20 };
            //var tMeses = from y in entity.VistaVentasPorMes
            //             .GroupBy(x => x.IdVenta)
            //             .Select(p => new
            //             {
            //                 IdVenta = p.FirstOrDefault().IdVenta,
            //                 Enero = p.First().Enero

            //             });

            //list.OrderBy(l => l.Id).GroupBy(l => new { GroupName = l.F1 }).Select(r => r.Key.GroupName)

            string[] series = { "Enero","Febrero" };
            //string[] series = { "Enero", "febrero", "Marzo", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            //int[] puntos = { 23, 10, 70 };
            //double[] puntos = { Convert.ToDouble(tMeses) };
            ctMeses.Titles.Add("Ventas Por Mes");
            for (int i = 0; i < series.Length; i++)
            {
                //titulos
                Series serie = ctMeses.Series.Add(series[i]);
                // cantidades 
                serie.Label = puntos[i].ToString();
                serie.Points.Add(puntos[i]);
            }
        }
    }
}
