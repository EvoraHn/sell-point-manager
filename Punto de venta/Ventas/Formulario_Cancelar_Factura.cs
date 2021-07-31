using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        int id = 0;
        bool editar = false;
        public Formulario_Cancelar_Factura()
        {
            InitializeComponent();
        }

       

        private void Formulario_Cancelar_Factura_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            Mostrar_datos();
            var Habilitado = new[] {"Activo",
                        "Inactivo"};

            txtEstado.DataSource = Habilitado;
        }
        private void Mostrar_datos()
        {
            var tFacturas = from p in entity.Venta
                             //where p.Estado == 1
                             orderby p.IdVenta
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
                            where p.Venta== detalle
                            
                            select new
                            {
                                p.Producto,
                                p.Cantidad,
                            };

            this.mifiltro = (tDetalle.CopyAnonymusToDataTable()).DefaultView;
            this.dgDetalles.DataSource = mifiltro;

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
                    Mostrar_detalles();
                    //txtEstado.Text = tabla.Estado.ToString();
                    editar = true;
                }
                catch (Exception)
                { }
            }
        }

        private void devolver_Productos()
        {
            //foreach ( )
            //{
            //    Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
            //    id = Convert.ToInt32(txtId.Text);
            //    var tablaP = entity.DetalleVentas.FirstOrDefault(x => x.Venta == id);
            //    tabla.Cantidad = 
            //    entity.SaveChanges();


            //}
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
                    if(txtEstado.Text == "Activo")
                    {
                        tablaP.Estado = 1;
                    }
                    else
                    {
                        tablaP.Estado = 2;
                        MessageBox.Show("¡Factura inhabilitada correctamente!");
                    }
                    entity.SaveChanges();
                    Mostrar_datos();
                    
                }
            }
            catch (Exception) { MessageBox.Show("¡Error al editar!"); return; }
        }
    }
}
