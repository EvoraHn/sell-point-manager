using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Ventas
{
    public partial class Formulario_Cancelar_Factura : Form
    {
        //Conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        DataView mifiltro2;
        int id = 0;
        string producto = "";
        
        public Formulario_Cancelar_Factura()
        {
            InitializeComponent();
        }
        private void Formulario_Cancelar_Factura_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            Mostrar_datos();
            //Mostrar_detalles();
            var Habilitado = new[] {"Activo",
                        "Inactivo"};

            txtEstado.DataSource = Habilitado;
        }
        private void Mostrar_datos()
        {
            var tFacturas = from p in entity.Venta
                             where p.Estado == 1
                             select new
                             {
                                 p.IdVenta,
                                 p.Fecha_Venta,
                                 p.Total_Venta,
                                 p.Estado
                             };

            this.mifiltro = (tFacturas.CopyAnonymusToDataTable()).DefaultView;
            this.dgFactura.DataSource = mifiltro;

        }
        private void Mostrar_detalles()
        {
            int detalle = Convert.ToInt32(txtId.Text);
            var tDetalle = from p in entity.DetalleVentas
                            where p.Venta == detalle 
                            
                            select new
                            {
                                p.Producto,
                                p.Venta,
                                p.Cantidad
                            };

            this.mifiltro2 = (tDetalle.CopyAnonymusToDataTable()).DefaultView;
            this.dgDetalles.DataSource = mifiltro2;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(IdVenta LIKE '%" + palabra + "%' OR Total_Venta LIKE '%" + palabra + "%' OR Fecha_Venta LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(IdVenta LIKE '%" + palabra + "%' OR Total_Venta LIKE '%" + palabra + "%' OR Fecha_Venta LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;

        }

        private void dgFactura_SelectionChanged(object sender, EventArgs e)
        {
            if (dgFactura.RowCount > 0)
            {
                try
                {
                    id = Convert.ToInt32(dgFactura.SelectedCells[0].Value);
                    var tabla = entity.Venta.FirstOrDefault(x => x.IdVenta == id);
                    if (tabla.Estado == 1)
                    {
                        txtEstado.Text = "Activo";
                    }
                    else
                    {
                        txtEstado.Text = "Inactivo";
                    }
                    txtId.Text = tabla.IdVenta.ToString();
                   
                    //txtEstado.Text = tabla.Estado.ToString();
                    
                    

                }
                catch (Exception)
                { }   
            }
        }


        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEstado.Text.Equals("") | txtId.Text.Equals(""))
                {
                    MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                    return;
                }
                else
                {
                    var tablaP = entity.Venta.FirstOrDefault(x => x.IdVenta == id);
                    if (txtEstado.Text == "Activo")
                    {
                        tablaP.Estado = 1;
                    }
                    else
                    {
                        Mostrar_detalles();
                        tablaP.Estado = 2;
                        entity.SaveChanges();
                        Thread.Sleep(100);
                        regresarProducto();
                        Thread.Sleep(100);
                        Mostrar_datos();
                        Limpiar();
                        MessageBox.Show("¡Factura inhabilitada correctamente!");

                    }
                    Mostrar_datos();
                }
            }
            catch (Exception) { }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Mostrar_detalles();
        }
        private void regresarProducto()
        {
            foreach (DataGridViewRow dr in dgDetalles.Rows)
            {
                Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
                producto = (dr.Cells[0].Value).ToString();
                var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == producto);
                double n = Convert.ToDouble(dr.Cells[2].Value);
                int numeroEntero = Convert.ToInt32(Math.Truncate(n));
                tablaP.Cantidad += numeroEntero ;
                entity.SaveChanges();
            }
        }
        private void Limpiar ()
        {
            txtBuscar.Text = string.Empty;
            Mostrar_detalles();
        }
    }
}
