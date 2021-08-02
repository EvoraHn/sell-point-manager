using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.Entity.Validation;

namespace Punto_de_venta.Mantenimientos
{
    public partial class Mantenimiento_Usuarios : Form
    {
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Punto_de_venta.Bases_de_datos.BPBEntities1();
        public Mantenimiento_Usuarios()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Usuarios_Load(object sender, EventArgs e)
        {
           /* var tPerfil = from p in entity.Usuario
                          where p.Estado == 1
                          select new
                          {
                              
                          };
            DataTable dtPerfil = tPerfil.CopyAnonymusToDataTable();*/

            //cmbPerfil.DataSource = dtPerfil;
            //cmbPerfil.DisplayMember = dtPerfil.Columns[1].ColumnName;
            //cmbPerfil.ValueMember = dtPerfil.Columns[0].ColumnName;
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
                tUsuarios.Pwd = Hash.obtenerHash256(txtPass.Text);
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

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {

        }
    }
    public class Hash{
        public static string obtenerHash256(string text)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashString = new SHA256Managed();

            byte[] hash = hashString.ComputeHash(bytes);
            string hashStr = string.Empty;

            foreach (byte x in hash)
            {
                hashStr += String.Format("{0:x2}", x);
            }

            return hashStr;

        }
    }

}

    

