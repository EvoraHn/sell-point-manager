using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Printing;

namespace Punto_de_venta.Ventas
{
    public partial class Formulario_Ventas : Form
    {
        //Conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        string id = "000000";
        int idDetalle = 0;
        bool editar = false;
        public Formulario_Ventas()
        {
            InitializeComponent();
        }

        private void dgProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProductos.RowCount > 0)
            {
                try
                {
                    id = Convert.ToString(dgProductos.SelectedCells[0].Value);
                    var tabla = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                    txtId.Text = tabla.IdProducto;
                    txtProducto.Text = tabla.Nombre;
                    editar = true;
                }
                catch (Exception)
                { }
            }
        }
        private void dgFactura_SelectionChanged(object sender, EventArgs e)
        {
            if (dgFactura.RowCount > 0)
            {
                try
                {
                    idDetalle = Convert.ToInt32(dgFactura.SelectedCells[0].Value);
                    var tabla = entity.DetalleVentas.FirstOrDefault(x => x.id == Convert.ToInt32(idDetalle));   
                }
                catch (Exception)
                { }
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Codigo LIKE '%" + palabra + "%' OR Producto LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(Codigo LIKE '%" + palabra + "%' OR Producto LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;

        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Vista1
                             select new
                             {
                                 p.Codigo,
                                 p.Producto,
                                 p.Precio
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgProductos.DataSource = mifiltro;

        }
        private void Mostrar_datos_Factura()
        {
            int NumeroFactura = Convert.ToInt32(lblFactura.Text);
            var tFactura = from p in entity.DetalleVentas
                                where p.Venta == NumeroFactura
                           select new
                                {
                                    p.id,
                                    p.Producto,
                                    p.Cantidad,
                                };
            dgFactura.DataSource = tFactura.CopyAnonymusToDataTable();
        }
        private void Limpiar()
        {
            txtId.Text = txtProducto.Text =  string.Empty;
            txtCantidad.Text = "1" ;
            editar = false;
            txtBuscar.Focus();
        }
        //private void Grid_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        BtnVentas_Copy.Focus();
        //    }
        //    else if (e.Key == Key.RightCtrl)
        //    {
        //        Agregaralcarrito.Focus();
        //    }
        //    else
        //    {

        //    }
        //}
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try {
                if (lblFactura.Text == "00000")
                {
                    AgregarVenta();
                    Thread.Sleep(100);
                    AgregarDetalleDeVenta();
                }
                else
                {
                    AgregarDetalleDeVenta();
                }
            }
            catch (Exception) { MessageBox.Show("Error en la base de datos contacte con el administrador",
                "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);}
        }

        private void AgregarVenta()
        {
            Punto_de_venta.Bases_de_datos.Venta tabla = new Punto_de_venta.Bases_de_datos.Venta();
            tabla.Importe_Exento = Convert.ToDecimal(txtImporteExento.Text);
            tabla.Importe_Exonerado = Convert.ToDecimal(txtImporteExonerado.Text);
            tabla.Impuesto_Gravado_15_ = Convert.ToDecimal(txtIG15.Text);
            tabla.Impuesto_Gravado_18_ = Convert.ToDecimal(txtIG18.Text);
            tabla.Impuesto_Gravado_15_ = Convert.ToDecimal(txtIG15.Text);
            tabla.ISV15_ = Convert.ToDecimal(txtISV15.Text);
            tabla.ISV18_ = Convert.ToDecimal(txtISV18.Text);
            tabla.Total_Venta = Convert.ToDecimal(txtTotal.Text);
            tabla.Fecha_Venta = DateTime.Now;
            tabla.Estado = 1;
            entity.Venta.Add(tabla);
            entity.SaveChanges();
            lblFactura.Text = tabla.IdVenta.ToString();
        }
        private void AgregarDetalleDeVenta()
        {
            Punto_de_venta.Bases_de_datos.DetalleVentas tabla = new Punto_de_venta.Bases_de_datos.DetalleVentas();
            tabla.Cantidad = Convert.ToInt32(txtCantidad.Text);
            tabla.Producto = txtId.Text;
            tabla.Venta = Convert.ToInt32(lblFactura.Text);
            entity.DetalleVentas.Add(tabla);
            entity.SaveChanges();
            Mostrar_datos_Factura();
        }

        private void EliminarDetalleDeVenta()
        {
            try
            {
                var tabla = entity.DetalleVentas.FirstOrDefault(x => x.id == idDetalle);
                entity.DetalleVentas.Remove(tabla);
                entity.SaveChanges();
                Mostrar_datos_Factura();

            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona un producto de la factura para eliminarlo",
                 "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);return;
            }
        }
        private void Formulario_Ventas_Load(object sender, EventArgs e)
        {
            Mostrar_datos();
            
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            EliminarDetalleDeVenta();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblFactura.Text);
            imprimirFactura();
        }

        private void Formulario_Ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Space)
            {
               
                MessageBox.Show("Holis");
            }
            else if (e.Control ==true && e.KeyCode == Keys.OemMinus)
            {
                btnQuitar.Focus();
            }
            else
            {

            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial",9);
            int ancho = 150;
            int y = 20;
            e.Graphics.DrawString("--- Punto de Venta ---", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("#factura"+lblFactura.Text+" ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("--- Productos ---", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            //int NumeroFactura = Convert.ToInt32(lblFactura.Text);
            //var tFactura = from p in entity.DetalleVentas
            //               where p.Venta == NumeroFactura
            //               select new
            //               {
            //                   p.id,
            //                   p.Producto,
            //                   p.Cantidad,
            //               };
            //dgFactura.DataSource = tFactura.CopyAnonymusToDataTable();
            List<Punto_de_venta.Bases_de_datos.DetalleVentas> listFact = new List<Punto_de_venta.Bases_de_datos.DetalleVentas>();
            foreach (DataGridViewRow row in dgFactura.Rows)
            {
                e.Graphics.DrawString(row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString() + " "+ row.Cells[2].Value.ToString() + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                //e.Graphics.DrawString(dgFactura.CurrentRow.Cells[0].Value.ToString() + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            }
          
               
           

        }

        private void imprimirFactura()
        {
            printDocument1 = new printDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += printDocument1_PrintPage;
            //Dialogo
            printDocument1.Print();

        }
    }
}
