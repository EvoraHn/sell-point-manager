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
        //variable para determinar si el individuo tiene o no acceso a modificar
        string Acceso = "";

        public Mantenimiento_Productos(string modulo)
        {
            Acceso = modulo;
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
            var Tipo_Impuesto = new[] {"15%",
                        "18%", "E  "};

            cmbImpuesto.DataSource = Tipo_Impuesto;
            Restricción();
        }
        private void Restricción()
        {
            if (Acceso == "Administración")
            {
                btnEliminar.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
            }
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
                                 p.Costo,
                                 p.Existencias
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgProductos.DataSource = mifiltro;

        }
        private void Limpiar()
        {
            //metodo de limpiar textbox
            cmbImpuesto.Text = "15%";
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
                    cmbImpuesto.Text = tabla.Tipo_Impuesto;
                    txtId.Enabled = false;
                    txtCategoria.Enabled = false;
                    txtEstante.Enabled = false;
                    txtProveedor.Enabled = false;
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
                    if (txtNombre.Text.Equals("") | txtId.Text.Equals("") | txtProveedor.Text.Equals("") | txtCategoria.Text.Equals("")
                        | txtCosto.Text.Equals("") | txtVenta.Text.Equals("") | txtEstante.Text.Equals("") | cmbImpuesto.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else {
                        if (Convert.ToDecimal(txtVenta.Text) > Convert.ToDecimal(txtCosto.Text))
                        {
                            var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                            tablaP.IdProducto = txtId.Text;
                            tablaP.Nombre = txtNombre.Text;
                            tablaP.Cantidad = tablaP.Cantidad;
                            tablaP.PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                            tablaP.PrecioVenta = Convert.ToDecimal(txtVenta.Text);
                            tablaP.Categoria = Convert.ToInt32(txtCategoria.Text);
                            tablaP.Proveedor = Convert.ToInt32(txtProveedor.Text);
                            tablaP.Estante = Convert.ToInt32(txtEstante.Text);
                            tablaP.Tipo_Impuesto = cmbImpuesto.Text;
                            entity.SaveChanges();
                            MessageBox.Show("¡Registro modificado correctamente!");
                            Limpiar();
                            Mostrar_datos();
                        }
                        else
                        {
                            MessageBox.Show("El precio de venta no puede ser menor al precio de costo",
                            "¡Revisa los Precios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                catch (Exception) { MessageBox.Show("¡Error al editar!"); return; }

            }
            else
            {
                try
                {
                    if (txtNombre.Text.Equals("") | txtId.Text.Equals("") | txtProveedor.Text.Equals("") | txtCategoria.Text.Equals("")
                       | txtCosto.Text.Equals("") | txtVenta.Text.Equals("") | txtEstante.Text.Equals("") | cmbImpuesto.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                       if (Convert.ToDecimal(txtVenta.Text) > Convert.ToDecimal(txtCosto.Text))
                        {
                            Punto_de_venta.Bases_de_datos.Producto tabla = new Punto_de_venta.Bases_de_datos.Producto();
                            tabla.IdProducto = txtId.Text;
                            tabla.Nombre = txtNombre.Text;
                            tabla.Cantidad = 0;
                            tabla.PrecioCosto = Convert.ToDecimal(txtCosto.Text);
                            tabla.PrecioVenta = Convert.ToDecimal(txtVenta.Text);
                            tabla.Categoria = Convert.ToInt32(txtCategoria.Text);
                            tabla.Proveedor = Convert.ToInt32(txtProveedor.Text);
                            tabla.Estante = Convert.ToInt32(txtEstante.Text);
                            tabla.Tipo_Impuesto = cmbImpuesto.Text;
                            entity.Producto.Add(tabla);
                            entity.SaveChanges();
                            MessageBox.Show("¡Registro guardado correctamente!");
                            Limpiar();
                            Mostrar_datos();
                        }
                       else
                        {
                            MessageBox.Show("El precio de venta no puede ser menor al precio de costo",
                            "¡Revisa los Precios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           
                            return;

                        }
                    }
                }
                catch (Exception) { MessageBox.Show("¡Error al guardar!"); return; }

            }
            
            
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (editar || txtId.Text !="")
            {
                try {
                    var tablaP = entity.Producto.FirstOrDefault(x => x.IdProducto == id);
                    entity.Producto.Remove(tablaP);
                    entity.SaveChanges();
                    MessageBox.Show("¡Registro eliminado correctamente!");
                    Limpiar();
                    Mostrar_datos();
                    
                }
                catch (Exception){
                    MessageBox.Show("¡No puedes eliminar un producto si ya está en facturas!"); return;
                }
            }
        }

        private void btnEstante_Click(object sender, EventArgs e)
        {
            Punto_de_venta.Mantenimientos.Mantenimiento_Estantes Formulario = new Punto_de_venta.Mantenimientos.Mantenimiento_Estantes();
            
            Formulario.Show();
            
        }
        public void Traer_Datos()
        {
            txtEstante.Text = Punto_de_venta.Clases.almacen_de_datos.Estante;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Punto_de_venta.Mantenimientos.Mantenimiento_Categoria Formulario = new Punto_de_venta.Mantenimientos.Mantenimiento_Categoria();

            Formulario.Show();

        }

        private void txtTraerEstante_Click(object sender, EventArgs e)
        {
            txtEstante.Text = Punto_de_venta.Clases.almacen_de_datos.Estante;
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Punto_de_venta.Mantenimientos.Mantenimiento_Proveedor Formulario = new Punto_de_venta.Mantenimientos.Mantenimiento_Proveedor();

            Formulario.Show();
        }

        private void btnTraerProveedor_Click(object sender, EventArgs e)
        {
            txtProveedor.Text = Punto_de_venta.Clases.almacen_de_datos.Proveedor;
        }

        private void btnTraerCategoria_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = Punto_de_venta.Clases.almacen_de_datos.Categoria;
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 45 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros positivos en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 45 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor ingresa solo numeros positivos en este campo",
                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
