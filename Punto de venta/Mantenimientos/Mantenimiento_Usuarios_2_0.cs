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
                    salida_datos = "(IdUsuario LIKE '%" + palabra + "%' OR Usr LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(IdUsuario LIKE '%" + palabra + "%' OR Usr LIKE '%" + palabra + "%' )";
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
                {}
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            Punto_de_venta.Bases_de_datos.Usuario tUsuarios = new Punto_de_venta.Bases_de_datos.Usuario();
            //tUsuarios.IdUsuario = 2;
            tUsuarios.Usr = txtUsr.Text;
            //tUsuarios.Identidad = txtId.Text;
            //tUsuarios.PrimerNombre = txtNombre.Text;
            //tUsuarios.SegundoNombre = txtnombre2.Text;
            //tUsuarios.PrimerApellido = txtApellido.Text;
            //tUsuarios.SegundoApellido = txtApellido2.Text;
            //tUsuarios.Estado = Convert.ToInt32(txtEstado.Text);
            //tUsuarios.Acceso = Convert.ToInt32(txtAcceso.Text);
            //tUsuarios.Contacto = txtContacto.Text;
            //tUsuarios.ContactoFamiliar = txtContacto2.Text;
            //Procedimiento Especial para contraseña
            //tUsuarios.Pwd = Hash.obtenerHash256(txtPass.Text);
            //tUsuarios.Pwd = "123";
            tUsuarios.Pwd = Hash.obtenerHash256(txtPwd.Text);
            entity.Usuario.Add(tUsuarios);

            entity.SaveChanges();
            MessageBox.Show("Datos Guardados Correctamente");

            //txtPass.Text = txtUsr.Text = txtNombre.Text = txtnombre2.Text = string.Empty;

            //chkEstado.Checked = false;
            //dpFechaNac.Value = DateTime.Today;

            //}
            //catch (DbEntityValidationException f)
            //{
            //    Console.WriteLine(f);

            //}
        }
    }
}
