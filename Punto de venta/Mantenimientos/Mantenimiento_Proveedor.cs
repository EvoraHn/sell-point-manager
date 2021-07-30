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
    public partial class Mantenimiento_Proveedor : Form
    {//conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        int id = 0;
        bool editar = false;
        public Mantenimiento_Proveedor()
        {
            InitializeComponent();
        }
        private void Mantenimiento_Proveedor_Load(object sender, EventArgs e)
        {
            Mostrar_datos();
        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Proveedor
                             select new
                             {
                                 p.IdProveedor,
                                 p.Empresa,
                                 p.Vendedor,
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgDatos.DataSource = mifiltro;
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EnviarDatos()
        {
            Punto_de_venta.Clases.almacen_de_datos.Proveedor = txtId.Text;
            this.Close();
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EnviarDatos();
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    id = Convert.ToInt32(dgDatos.SelectedCells[0].Value);
                    var tabla = entity.Proveedor.FirstOrDefault(x => x.IdProveedor == id);
                    txtId.Text = tabla.IdProveedor.ToString();
                    txtNombre.Text = tabla.Vendedor;
                    txtEmpresa.Text = tabla.Empresa;
                    txtcelular.Text = tabla.Contacto;
                    txtTelefono.Text = tabla.Contacto1;
                    txtDescripcion.Text = tabla.Descripcion;
                    editar = true; btnEnviar.Enabled = true;
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
                    salida_datos = "(Empresa LIKE '%" + palabra + "%' OR Vendedor LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(Empresa LIKE '%" + palabra + "%' OR Vendedor LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }

        private void Limpiar()
        {
            txtId.Text = txtNombre.Text = txtDescripcion.Text = txtEmpresa.Text = txtcelular.Text 
            = txtTelefono.Text = string.Empty;
            editar = false;
            txtBuscar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                try
                {
                    if (txtNombre.Text.Equals("") | txtEmpresa.Text.Equals("") | txtcelular.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        var tablaP = entity.Proveedor.FirstOrDefault(x => x.IdProveedor == id);
                        tablaP.IdProveedor = tablaP.IdProveedor;
                        tablaP.Vendedor = txtNombre.Text;
                        tablaP.Empresa = txtEmpresa.Text;
                        tablaP.Contacto = txtcelular.Text;
                        tablaP.Contacto = txtTelefono.Text;
                        tablaP.Descripcion = txtDescripcion.Text;
                        entity.SaveChanges();
                        MessageBox.Show("¡Registro modificado correctamente!");
                        Limpiar();
                        Mostrar_datos();
                    }
                }
                catch (Exception) { MessageBox.Show("¡Error al editar!"); return; }

            }
            else
            {
                try
                {
                    if (txtNombre.Text.Equals("") | txtEmpresa.Text.Equals("") | txtcelular.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        Punto_de_venta.Bases_de_datos.Proveedor tabla = new Punto_de_venta.Bases_de_datos.Proveedor();
                        tabla.IdProveedor = tabla.IdProveedor;
                        tabla.Vendedor = txtNombre.Text;
                        tabla.Empresa = txtEmpresa.Text;
                        tabla.Contacto = txtcelular.Text;
                        tabla.Contacto = txtTelefono.Text;
                        tabla.Descripcion = txtDescripcion.Text;
                        entity.Proveedor.Add(tabla);
                        entity.SaveChanges();
                        MessageBox.Show("¡Registro guardado correctamente!");
                        Limpiar();
                        Mostrar_datos();
                    }
                }
                catch (Exception) { MessageBox.Show("¡Error al guardar!"); return; }

            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEnviar.Enabled = false;
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (editar || txtId.Text != "")
            {
                try
                {
                    var tablaP = entity.Proveedor.FirstOrDefault(x => x.IdProveedor == id);
                    entity.Proveedor.Remove(tablaP);
                    entity.SaveChanges();
                    MessageBox.Show("¡Registro eliminado correctamente!");
                    Limpiar();
                    Mostrar_datos();
                }
                catch (Exception)
                {
                    MessageBox.Show("¡No puedes eliminar un proveedor si ya está enlazado con un producto!"); return;
                }
            }
        }
    }
}
