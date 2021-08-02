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
    public partial class Mantenimiento_Usuarios_2_0 : Form
    {
        //Conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        int id = 0;
        bool editar = false;
        public Mantenimiento_Usuarios_2_0()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void Mantenimiento_Usuarios_2_0_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            Mostrar_datos();
            var LEstado = new[] {"Activo",
                        "Inactivo"};

            cmbEstado.DataSource = LEstado;
        }

        private void Mostrar_datos()
        {
            var tUsuarios = from p in entity.Usuario
                             select new
                             {
                                 p.IdUsuario,
                                 p.Usr,
                                 p.Pwd,
                             };
            this.mifiltro = (tUsuarios.CopyAnonymusToDataTable()).DefaultView;
            this.dgProductos.DataSource = mifiltro;

        }

        private void dgProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProductos.RowCount > 0)
            {
                try
                {
                    id = Convert.ToInt32(dgProductos.SelectedCells[0].Value);
                    var tabla = entity.Usuario.FirstOrDefault(x => x.IdUsuario == id);
                    //txtIdentidad.Text = tabla.;
                    txtUsr.Text = tabla.Usr;
                    //txt.Text = Convert.ToString(tabla.PrecioCosto);
                    //txtVenta.Text = Convert.ToString(tabla.PrecioVenta);
                    //txtCategoria.Text = Convert.ToString(tabla.Categoria);
                    //txtProveedor.Text = Convert.ToString(tabla.Proveedor);
                    //txtEstante.Text = Convert.ToString(tabla.Estante);
                    //txtVenta.Text = Convert.ToString(tabla.PrecioVenta);
                    //cmbImpuesto.Text = tabla.Tipo_Impuesto;
                    //txtId.Enabled = false;
                    //txtCategoria.Enabled = false;
                    //txtEstante.Enabled = false;
                    //txtProveedor.Enabled = false;
                    editar = true;
                }
                catch (Exception)
                {
                    // MessageBox.Show("Error");
                }
            }
        }
    }
}
