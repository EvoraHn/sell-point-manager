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

namespace Punto_de_venta.Inicio
{
    public partial class Login : Form
    {
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Punto_de_venta.Bases_de_datos.BPBEntities1();
        public Login()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";
            txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DateTime fechaLimite = new DateTime(2021, 10, 18, 1, 1, 1);
            DateTime fechaActual = DateTime.Now;
            if ((DateTime.Compare(fechaActual, fechaLimite)) < 0)
            { 
                if ((txtUsuario.Text == string.Empty) | (txtContraseña.Text == string.Empty))
                {
                    MessageBox.Show("Favor llenar los campos de usuario y contraseña antes de iniciar sesión");
                }
                else
                {
                    string pass = Hash.obtenerHash256(txtContraseña.Text);

                    var tUsuarios = entity.Usuario.FirstOrDefault(x => x.Usr == txtUsuario.Text && x.Pwd == pass);

                    if (tUsuarios == null)
                    {
                        MessageBox.Show("Usuario o Contraseña incorrecto");
                        return;
                    }
                    else {

                        //frmMenu fMenu = new frmMenu(tUsuarios.IdUsuario);
                        //this.Hide();
                        //fMenu.Show();

                        Punto_de_venta.Menú.Menu_estilo_2 Formulario = new Punto_de_venta.Menú.Menu_estilo_2(tUsuarios.IdUsuario);
                        this.Hide();
                        Formulario.ShowDialog();
                        limpiar();
                        this.Show();
                        //this.Close();
                        //this.Dispose();
                    }

                } 
            }
            else
            {
                MessageBox.Show("Su licencia Expiró (para cambiar revise el login)");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class Hash
    {
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
