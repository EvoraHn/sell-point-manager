using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Punto_de_venta.Mantenimientos
{
    public partial class Mantenimiento_Productos : Form
    {   //Conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        string id = "000000";
        bool editar = false;

        public Mantenimiento_Productos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// al presionar una tecla
        /// el buscador muestra en el datagrid todas las coincidencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Codigo LIKE '%" + palabra + "%' OR Producto LIKE '%" + palabra +
                        "%' OR Categoria LIKE '%" + palabra + "%' OR Proveedor LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos += "AND(Codigo LIKE '%" + palabra + "%' OR Producto LIKE '%" + palabra +
                        "%' OR Categoria LIKE '%" + palabra + "%' OR Proveedor LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;

        }

        private void Mantenimiento_Productos_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            Mostrar_datos();

        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //metodo para llenar la tabla con datos y actualizar al hacer cambios
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Vista1
                             select new
                             {
                                 p.Codigo,
                                 p.Categoria,
                                 p.Proveedor,
                                 p.Producto,
                                 p.Precio,
                                 p.Costo
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgProductos.DataSource = mifiltro;

        }
        private void Limpiar()
        {
            //metodo de limpiar textbox
            txtId.Text = txtNombre.Text = txtProveedor.Text = txtCategoria.Text = txtCosto.Text = txtVenta.Text = txtEstante.Text = string.Empty;
            editar = false;
            txtBuscar.Focus();
        }
        private void Verificar()
        {
            txtId.ReadOnly = true;
            txtId.Enabled = false;
            if (txtNombre.Text.Equals("") | txtId.Text.Equals("") | txtProveedor.Text.Equals("") | txtCategoria.Text.Equals("")
                | txtCosto.Text.Equals("") | txtVenta.Text.Equals("") | txtEstante.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                return;
            }
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
                    txtNombre.Text=tabla.Nombre;
                    txtCosto.Text = Convert.ToString(tabla.PrecioCosto);
                    txtVenta.Text = Convert.ToString(tabla.PrecioVenta);
                    txtCategoria.Text = Convert.ToString(tabla.Categoria);
                    txtProveedor.Text = Convert.ToString(tabla.Proveedor);
                    txtEstante.Text = Convert.ToString(tabla.Estante);
                    txtVenta.Text = Convert.ToString(tabla.PrecioVenta);
                    editar = true;
                }
                catch (Exception)
                {
                   // MessageBox.Show("Error");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (editar)
            {
                try
                {   
                    Verificar();
                    var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                    tablaP.IdProducto = txtId.Text;
                    tablaP.Nombre = txtNombre.Text;
                    tablaP.PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                    tablaP.PrecioVenta = Convert.ToDecimal(txtVenta.Text);
                    tablaP.Categoria = Convert.ToInt32(txtCategoria.Text);
                    tablaP.Proveedor = Convert.ToInt32(txtProveedor.Text);
                    tablaP.Estante = Convert.ToInt32(txtEstante.Text);
                    entity.SaveChanges();
                }
                catch (Exception) { }

            }
            else
            {
                try
                {
                    txtId.ReadOnly = false;
                    Verificar();
                    Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
                    tabla.IdProducto = txtId.Text;
                    tabla.Nombre = txtNombre.Text;
                    tabla.PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                    tabla.PrecioVenta = Convert.ToDecimal(txtVenta.Text);
                    tabla.Categoria = Convert.ToInt32(txtCategoria.Text);
                    tabla.Proveedor = Convert.ToInt32(txtProveedor.Text);
                    tabla.Estante = Convert.ToInt32(txtEstante.Text);
                    entity.Producto.Add(tabla);
                    entity.SaveChanges();
                }
                catch  { }

            }
            Limpiar();

            Mostrar_datos();
            MessageBox.Show("¡Información guardada correctamente!");
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (editar || txtId.Text !="")
            {
                
                var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                tablaP.IdProducto = txtId.Text;
                tablaP.Nombre = txtNombre.Text;
                tablaP.PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                tablaP.PrecioVenta = Convert.ToDecimal(txtVenta.Text);
                tablaP.Categoria = Convert.ToInt32(txtCategoria.Text);
                tablaP.Proveedor = Convert.ToInt32(txtProveedor.Text);
                tablaP.Estante = Convert.ToInt32(txtEstante.Text);
                entity.Producto.Remove(tablaP);
                entity.SaveChanges();
                Limpiar();
                Mostrar_datos();
            }
        }
    }
}
