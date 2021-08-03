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
        bool errorV = false;
        bool cotizacion = false;
        //tabla temporal
        DataTable dtTemporal = new DataTable();
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
            txtBuscar.Text = txtId.Text = txtProducto.Text =  string.Empty;
            txtCantidad.Text = "1" ;
            txtBuscar.Focus();
        }
        private void LimpiarTodo()
        {
            txtId.Text = txtProducto.Text=txtCAI.Text = txtCliente.Text = txtRTN.Text =
            txtDescuentos.Text = txtFechaLimite.Text = txtImporteExento.Text = txtImporteExonerado.Text
            =txtISV15.Text =txtISV18.Text = txtIG18.Text = txtIG15.Text = txtTotal.Text =
            txtSubtotal.Text=txtBuscar.Text= string.Empty;
            txtDescuentos.Text = "0";
            txtImporteExonerado.Text = "0";
            dgFactura.Rows.Clear();
            dgFactura.RowCount = 0;
            txtCantidad.Text = "1";
            lblFactura.Text = "00000";
            txtBuscar.Focus();
            
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == string.Empty || Convert.ToInt32(txtCantidad.Text) < 1)
            {
                txtCantidad.Text = "1";
            }
            AgregarProducto();
            Limpiar();
        }

        private void AgregarProducto()
        {
            int indice = dgProductos.CurrentCell.RowIndex;
            int indiceF = dgFactura.RowCount == 0 ? 0 : dgFactura.CurrentCell.RowIndex;

            string codigo = dgProductos.Rows[indice].Cells[0].Value.ToString();
            string producto = dgProductos.Rows[indice].Cells[1].Value.ToString();
            string precio = dgProductos.Rows[indice].Cells[2].Value.ToString();
            string cantidad = dgFactura.RowCount == 0 ? "1" : dgFactura.Rows[indiceF].Cells[3].Value.ToString();
            
            //HacerCuentas();
            foreach (DataGridViewRow dr in dgFactura.Rows)
            {
                string id = (dr.Cells[1].Value).ToString();
            
                if (id == producto)
                {
                   
                    int quantity = Convert.ToInt32(dr.Cells[3].Value);
                    cantidad = (Convert.ToInt32(txtCantidad.Text) + quantity).ToString();
                    dgFactura.Rows.RemoveAt(dr.Index);
                    break;
                }
                else
                {
                    cantidad = txtCantidad.Text;
                }
               
            }
            dgFactura.Rows.Add(codigo, producto, precio, cantidad);
            HacerCuentas();
        }

        private void QuitarProducto()
        {
            try
            {
                if (dgFactura.SelectedRows.Count > 0)
                {
                    int indice = dgFactura.CurrentCell.RowIndex;
                    int indiceF = dgFactura.RowCount == 0 ? 0 : dgFactura.CurrentCell.RowIndex;
                    int cantidadf = dgFactura.RowCount == 0 ? 0 : Convert.ToInt32(dgFactura.Rows[indice].Cells[3].Value);
                    
                    if (cantidadf <= 1)
                    {
                        dgFactura.Rows.RemoveAt(indice);
                    }
                    else
                    {
                        string codigo = dgFactura.Rows[indice].Cells[0].Value.ToString();
                        string producto = dgFactura.Rows[indice].Cells[1].Value.ToString();
                        string precio = dgFactura.Rows[indice].Cells[2].Value.ToString();
                        string cantidad = dgFactura.RowCount == 0 ? "0" : dgFactura.Rows[indiceF].Cells[3].Value.ToString();

                        //HacerCuentas();
                        foreach (DataGridViewRow dr in dgFactura.Rows)
                        {
                            string id = (dr.Cells[1].Value).ToString();

                            if (id == producto)
                            {

                                int quantity = 1;
                                cantidad = (Convert.ToInt32(cantidad) - quantity).ToString();
                                dgFactura.Rows.RemoveAt(dr.Index);
                                break;
                            }
                            else
                            {
                                //cantidad = txtCantidad.Text;
                            }

                        }
                        dgFactura.Rows.Add(codigo, producto, precio, cantidad);
                        HacerCuentas();
                        dgFactura.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un producto de la factura para eliminarlo",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona un producto de la factura para eliminarlo",
                 "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
        }

        private void HacerCuentas()
        {
            decimal subtot = 0;
            decimal isv15 = 0;
            decimal isv18 = 0;
            decimal exento = 0;
            decimal iG15 = 0;
            decimal iG18 = 0;
            decimal descuento = txtDescuentos.Text == string.Empty ? 0 : Convert.ToDecimal(txtDescuentos.Text);
            decimal exonerado = txtImporteExonerado.Text == string.Empty ? 0 : Convert.ToDecimal(txtImporteExonerado.Text);
            try
            {
                foreach (DataGridViewRow dr in dgFactura.Rows)
                {
                    decimal cantidad = Convert.ToDecimal((dr.Cells[3].Value).ToString());
                    string fkid = (dr.Cells[0].Value).ToString(); ;
                    var pel = entity.Producto.FirstOrDefault(x => x.IdProducto == fkid);
                    subtot += pel.PrecioVenta * cantidad;

                     
                    if (pel.Tipo_Impuesto != null)
                    {
                        isv15 += pel.Tipo_Impuesto.Equals(null) ? 0 : pel.Tipo_Impuesto.Equals("15%") ? (pel.PrecioVenta * cantidad) * (Convert.ToDecimal(pel.Tipo_Impuesto.Substring(0, 2)) / 100)
                          : 0;
                        iG15 += pel.Tipo_Impuesto.Equals("15%") ? (pel.PrecioVenta * cantidad)
                            : 0;

                        isv18 += pel.Tipo_Impuesto.Equals("18%") ? pel.PrecioVenta * (Convert.ToDecimal(pel.Tipo_Impuesto.Substring(0, 2)) / 100)
                            : 0;

                        iG18 += pel.Tipo_Impuesto.Equals("18%") ? pel.PrecioVenta
                            : 0;

                        exento += pel.Tipo_Impuesto.Equals("E  ") ? pel.PrecioVenta
                            : 0;
                        
                    }
                    else
                    {
                        //MessageBox.Show("sin impuesto");
                    }
                }
                txtSubtotal.Text = subtot.ToString("N2");
                txtISV18.Text = isv18.ToString("N2");
                txtISV15.Text = isv15.ToString("N2");
                txtIG15.Text = iG15.ToString("N2");
                txtIG18.Text = iG18.ToString("N2");
                txtImporteExento.Text = exento.ToString("N2");
                txtTotal.Text = (subtot + isv15 + isv18 - (descuento + exonerado)).ToString("N2");
                //if ( (descuento+exonerado) < subtot)
                //{
                //    txtTotal.Text = (subtot + isv15 + isv18 - (descuento + exonerado)).ToString("N2");
                //}
                //else
                //{
                //    //MessageBox.Show("Error en descuentos y exonerados",
                //    //"No puede dar más descuentos de lo que suman los productos,¡Revise!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //return;
                //}

            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar factura",
                "Contacte con el administrador", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
        }

        private void verificarIntegridad()
        {
            double descuento = 0;
            double total = 0;
            double exonerado = 0;

            try
            {
                 descuento = txtDescuentos.Text == " " ? 0 : Convert.ToDouble(txtDescuentos.Text);
                 total = txtTotal.Text == " " ? 0 : Convert.ToDouble(txtTotal.Text);
                 exonerado = txtImporteExonerado.Text == " " ? 0 : Convert.ToDouble(txtImporteExonerado.Text);
            }
            catch { };

            if ((descuento + exonerado) > total)
            {
                MessageBox.Show("los descuentos y Exonerados no pueden ser mayores al total",
                "Error al imprimir factura", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                 errorV = true; return;
            }
            else
            {

                if (dgFactura.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Para imprimir debe tener mínimo un producto en la factura",
                    "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning); errorV = true; return;
                }
                else
                {
                    if (lblFactura.Text == "00000")
                    {
                        errorV = false;
                        cotizacion = false;
                        AgregarVenta();
                        Thread.Sleep(100);
                        AgregarDetalleDeVenta();
                        Thread.Sleep(100);
                        DisminuirInventario();
                        MessageBox.Show("¡Venta guardada correctamente!",
                        "¡Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    }
                }
            }
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
            foreach (DataGridViewRow dr in dgFactura.Rows)
            {
                Punto_de_venta.Bases_de_datos.DetalleVentas tabla = new Punto_de_venta.Bases_de_datos.DetalleVentas();
                string fkid = (dr.Cells[0].Value).ToString(); ;
                var Product = entity.Producto.FirstOrDefault(x => x.IdProducto == fkid);
                tabla.Producto = (dr.Cells[0].Value).ToString(); 
                tabla.Cantidad = Convert.ToInt32(dr.Cells[3].Value);
                tabla.Venta = Convert.ToInt32(lblFactura.Text);
                entity.DetalleVentas.Add(tabla);
                entity.SaveChanges();
                
            }
        }
        private void DisminuirInventario()
        {
            foreach (DataGridViewRow dr in dgFactura.Rows)
            {
                Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
                id =(dr.Cells[0].Value).ToString();
                var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                tablaP.Cantidad = tablaP.Cantidad - Convert.ToInt32(dr.Cells[3].Value);
                entity.SaveChanges();


            }
        }
        private void Formulario_Ventas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            Mostrar_datos();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarProducto();
            HacerCuentas();
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            verificarIntegridad();
            if (errorV)
            {
                return;
            }
            else
            {
                imprimirFactura();
                LimpiarTodo();
            }
            
            //if (dgFactura.SelectedRows.Count <= 0)
            //{
            //    MessageBox.Show("Para imprimir debe tener mínimo un producto en la factura",
            //    "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            //}
            //else
            //{
            //    if (lblFactura.Text == "00000")
            //    {
            //        AgregarVenta();
            //        Thread.Sleep(100);
            //        AgregarDetalleDeVenta();
            //        Thread.Sleep(100);
            //        DisminuirInventario();
            //        //imprimirFactura();
            //    }
            //    else
            //    {
            //        //AgregarDetalleDeVenta();
            //        //Thread.Sleep(100);
            //        //DisminuirInventario();
            //        //imprimirFactura();
            //    }
            //    imprimirFactura();
            //    LimpiarTodo();

            //}
                
        }

        private void Formulario_Ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Add)
            {
                btnAgregar.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Subtract)
            {
                btnQuitar.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                btnImprimir.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.G)
            {
                btnSoloGuardar1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                btnCotizacion.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.N)
            {
                BtnNuevaFactura1.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Delete)
            {
                btnQuitarTodo.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Space)
            {
                txtBuscar.Focus();
            }
        }
        /// <summary>
        /// Impresión de Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Configuración para la factura( tipo de letra,
            //ancho total de la factura, separación entre textos
            //tipos de alineado
            Font font = new Font("Arial",9);
            int ancho = 150;
            int y = 20;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StringFormat stringFormatrigth = new StringFormat();
            stringFormatrigth.Alignment = StringAlignment.Far;
            stringFormatrigth.LineAlignment = StringAlignment.Far;

            StringFormat stringFormatLeft = new StringFormat();
            stringFormatLeft.Alignment = StringAlignment.Near;
            stringFormatLeft.LineAlignment = StringAlignment.Near;

            //----------------------- Logo de la empresa -------------------------------------------------------
            Bitmap myPng = Properties.Resources.LOGO_3;
            e.Graphics.DrawImage(myPng, new RectangleF(25, y += 10, 100, 100));

            //----------------------- Encabezado de Factura ----------------------------------------------------
            if (cotizacion)
            {
            e.Graphics.DrawString("--- Cotización ---", font, Brushes.Black, new RectangleF(0, y += 100, ancho, 20), stringFormat);
            e.Graphics.DrawString("" + DateTime.Now + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), stringFormat);

            }
            else
            {
                e.Graphics.DrawString("--- Punto de Venta ---", font, Brushes.Black, new RectangleF(0, y += 100, ancho, 20), stringFormat);
                e.Graphics.DrawString("" + DateTime.Now + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), stringFormat);
                e.Graphics.DrawString("CAI: " + txtCAI.Text + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 40), stringFormatLeft);
                e.Graphics.DrawString("Fecha Límite: " + txtFechaLimite.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
                e.Graphics.DrawString("Factura: #" + lblFactura.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20), stringFormatLeft);
                e.Graphics.DrawString("Cliente: " + txtCliente.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20), stringFormatLeft);
                e.Graphics.DrawString("RTN: " + txtRTN.Text + " ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20), stringFormatLeft);

            }

            //---------------------------- Productos -----------------------------------------------------------
            e.Graphics.DrawString("------ Productos ------", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 20), stringFormat);
            foreach (DataGridViewRow row in dgFactura.Rows)
            {
                e.Graphics.DrawString(row.Cells[1].Value.ToString() + " " , font, Brushes.Black, new RectangleF(0, y += 20, ancho, 80), stringFormatLeft);
                e.Graphics.DrawString(row.Cells[2].Value.ToString() + " X " + row.Cells[3].Value.ToString(), font, Brushes.Black, new RectangleF(0, y += 25, ancho,20), stringFormatrigth);
            }
            //-------------------------- Pie de Factura --------------------------------------------------------
            e.Graphics.DrawString("Subtotal: " + txtSubtotal.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Importe Exonerado: " + txtImporteExonerado.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Descuento: " + txtDescuentos.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Importe Exento: " + txtImporteExento.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Importe Grabado 18%: " + txtIG18.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("I.S.V 18%: " + txtISV18.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Importe Grabado 15%: " + txtIG15.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("I.S.V 15%: " + txtISV15.Text + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
            e.Graphics.DrawString("Total: " + (Convert.ToDecimal(txtTotal.Text)- Convert.ToDecimal(txtDescuentos.Text)- Convert.ToDecimal(txtImporteExonerado.Text)).ToString() + " ", font, Brushes.Black, new RectangleF(0, y += 40, ancho, 40), stringFormatLeft);
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

      

        private void txtDescuentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 45 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros positivos en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void BtnNuevaFactura_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros enteros positivos en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnQuitarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgFactura.SelectedRows.Count > 0)
                {
                    int indice = dgFactura.CurrentCell.RowIndex;
                    dgFactura.Rows.RemoveAt(indice);
                }
                else
                {
                    MessageBox.Show("Selecciona un producto de la factura para eliminarlo",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Selecciona un producto de la factura para eliminarlo",
                 "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
        
    }

        private void btnSoloGuardar_Click(object sender, EventArgs e)
        {
            verificarIntegridad();
            if (errorV)
            {
                return;
            }
            else
            {
                LimpiarTodo();
            }
        }

        

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            if (dgFactura.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Para imprimir una cotización debe tener por lo menos un producto seleccionado",
                "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            else
            {
                if (lblFactura.Text == "00000")
                {
                    cotizacion = true;
                    imprimirFactura();

                }

            }
        }

        private void txtImporteExonerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 45 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros positivos en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Punto_de_venta.Ventas.Formulario_Cancelar_Factura frm = new Punto_de_venta.Ventas.Formulario_Cancelar_Factura();
            frm.Show();
        }
    }
}
