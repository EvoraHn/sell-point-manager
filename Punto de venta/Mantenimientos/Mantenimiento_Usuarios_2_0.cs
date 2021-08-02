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
            var LAcceso = new[] {"Auditoría",
                        "Admin","Caja"};
            cmbAcceso.DataSource = LAcceso;
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
                    txtUsr.Text = tabla.Usr;
                    txtCelular.Text = tabla.Contacto;
                    TxtFamiliar.Text = tabla.ContactoFamiliar;
                    txtIdentidad.Text = tabla.Identidad;
                    txtPNombre.Text = tabla.PrimerNombre;
                    txtSNombre.Text = tabla.SegundoNombre;
                    txtSApellido.Text = tabla.SegundoApellido;
                    txtPApellido.Text = tabla.PrimerApellido;
                    cmbAcceso.Text = tabla.Acceso;
                    cmbEstado.Text = tabla.Estado;
                    editar = true;
                }
                catch (Exception)
                {}
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                var tUsuarios = entity.Usuario.FirstOrDefault(x => x.IdUsuario == id);
                tUsuarios.Usr = txtUsr.Text;
                tUsuarios.Identidad = txtIdentidad.Text;
                tUsuarios.PrimerNombre = txtPNombre.Text;
                tUsuarios.SegundoNombre = txtSNombre.Text;
                tUsuarios.PrimerApellido = txtPApellido.Text;
                tUsuarios.SegundoApellido = txtSApellido.Text;
                tUsuarios.Estado = cmbEstado.Text;
                tUsuarios.Acceso = cmbAcceso.Text;
                tUsuarios.Contacto = txtCelular.Text;
                tUsuarios.ContactoFamiliar = TxtFamiliar.Text;

                if (txtPwd.Text == txtConfirmacionPwd.Text)
                {
                    tUsuarios.Pwd = Hash.obtenerHash256(txtPwd.Text);
                    entity.SaveChanges();
                    MessageBox.Show("Datos Modificados Correctamente");
                    Mostrar_datos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Las Contraseñas no Coinciden, intenta de nuevo"); return;
                }
                
            }
            else
            {
                Punto_de_venta.Bases_de_datos.Usuario tUsuarios = new Punto_de_venta.Bases_de_datos.Usuario();
                tUsuarios.Usr = txtUsr.Text;
                tUsuarios.Identidad = txtIdentidad.Text;
                tUsuarios.PrimerNombre = txtPNombre.Text;
                tUsuarios.SegundoNombre = txtSNombre.Text;
                tUsuarios.PrimerApellido = txtPApellido.Text;
                tUsuarios.SegundoApellido = txtSApellido.Text;
                tUsuarios.Estado = cmbEstado.Text;
                tUsuarios.Acceso = cmbAcceso.Text;
                tUsuarios.Contacto = txtCelular.Text;
                tUsuarios.ContactoFamiliar = TxtFamiliar.Text;

                if (txtPwd.Text == txtConfirmacionPwd.Text)
                {
                    tUsuarios.Pwd = Hash.obtenerHash256(txtPwd.Text);
                    entity.Usuario.Add(tUsuarios);

                    entity.SaveChanges();
                    MessageBox.Show("Datos Guardados Correctamente");
                    Mostrar_datos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Las Contraseñas no Coinciden, intenta de nuevo"); return;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            editar = false;
            Limpiar();
        }


        private void Limpiar()
        {
            txtCelular.Text = txtConfirmacionPwd.Text = txtIdentidad.Text = txtPApellido.Text = txtPNombre.Text =
            txtPwd.Text = txtSApellido.Text = txtSNombre.Text = txtUsr.Text = TxtFamiliar.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dgProductos.SelectedCells[0].Value);
            
            if (editar || id != 0)
            {
                try
                {
                    var tabla = entity.Usuario.FirstOrDefault(x => x.IdUsuario == id);
                    entity.Usuario.Remove(tabla);
                    entity.SaveChanges();
                    MessageBox.Show("¡Registro eliminado correctamente!");
                    Limpiar();
                    Mostrar_datos();

                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Eliminar Usuario!"); return;
                }
            }
        }
    }
}
