using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Compras
{
    public partial class Formulario_Compras : Form
    {
        //conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        string id = "";
        public Formulario_Compras()
        {
            InitializeComponent();
        }

        private void Formulario_Compras_Load(object sender, EventArgs e)
        {
            Mostrar_datos();
        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Producto
                             select new
                             {
                                 p.IdProducto,
                                 p.Nombre,
                                 p.Cantidad,
                                 p.PrecioVenta
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgDatos.DataSource = mifiltro;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != string.Empty || dgDatos.ColumnCount > 0)
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                if (cantidad > 0)
                {

                    //Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
                    var tabla = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                    tabla.Cantidad += cantidad;
                    entity.SaveChanges();
                    Guardar_Compra();
                    Mostrar_datos();
                    Limpiar();
                    MessageBox.Show("Se agregó más producto al inventario",
                   "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                else
                {
                    MessageBox.Show("no puedes comprar cantidades negativas",
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ingresa la cantidad que deseas comprar",
                   "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    id = (dgDatos.SelectedCells[0].Value).ToString();
                    var tabla = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                    txtId.Text = tabla.IdProducto.ToString();
                    txtNombre.Text = tabla.Nombre;
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
                    salida_datos = "(Nombre LIKE '%" + palabra + "%' OR IdProducto LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(Nombre LIKE '%" + palabra + "%' OR IdProducto LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros enteros en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void Limpiar()
        {
            txtBuscar.Text = txtNombre.Text = txtCantidad.Text = txtId.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            //Punto_de_venta.Menú.Menu_estilo_1 frm = new Punto_de_venta.Menú.Menu_estilo_1();
            //frm.abrirFormularioHijo(new Punto_de_venta.Mantenimientos.Mantenimiento_Productos());
            //this.Dispose();
            //abrirFormularioHijo(new Punto_de_venta.Mantenimientos.Mantenimiento_Productos());
        }

        private void Guardar_Compra()
        {
            int indice = dgDatos.CurrentCell.RowIndex;
            decimal precio = Convert.ToDecimal(dgDatos.Rows[indice].Cells[3].Value);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Punto_de_venta.Bases_de_datos.Compra tabla = new Punto_de_venta.Bases_de_datos.Compra();
            tabla.Producto = txtId.Text;
            tabla.PrecioUnitario = precio;
            tabla.Cantidad = cantidad;
            tabla.Total = cantidad * precio;
            entity.Compra.Add(tabla);
            entity.SaveChanges();
        }
    }
}
