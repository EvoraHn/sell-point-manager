using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta.Menú
{
    public partial class Menu_estilo_2 : Form
    {
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Punto_de_venta.Bases_de_datos.BPBEntities1();
        long idUsuario = 0;
        string modulo = "Tienes Acceso";
        //string modulo =  "" ;
        public Menu_estilo_2(long _idUsuario)
        {
            InitializeComponent();
            idUsuario = _idUsuario;
            

        }
        //llamado a abrir un nuevo formulario
        private void btnInventario_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Mantenimientos.Mantenimiento_Productos(modulo));
        }
        //proceso para abrir un formulario dentro de un contenedor
        public void abrirFormularioHijo(object formHijo)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Ventas.Formulario_Ventas());
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Compras.Formulario_Compras());
        }

        private void Menu_estilo_1_Load(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
            this.KeyPreview = true;




            var tInfoUsuario = from u in entity.Usuario
                               join per in entity.Perfiles on u.FKPerfil equals per.IdPerfil
                               where u.IdUsuario == idUsuario
                               select new
                               {
                                   u.Usr,
                                   u.FKPerfil,
                                   per.DescripcionPerfil
                               };


            DataTable dtInfoUsuario = tInfoUsuario.CopyAnonymusToDataTable();
            short fkPerfil = Convert.ToInt16(dtInfoUsuario.Rows[0].ItemArray[1]);

            var tPerfilMod = from mods in entity.PerfilModulo
                             where mods.FKPerfilId == fkPerfil
                             select mods;
            //short[] arrMod = new short[] { };
            List<short> lMod = new List<short>();

            DataTable dtpm = tPerfilMod.CopyAnonymusToDataTable();

            for (int x = 0; x < dtpm.Rows.Count; x++)
            {
                lMod.Add(Convert.ToInt16(dtpm.Rows[x].ItemArray[1]));
                //arrMod[x] = Convert.ToInt16(dtpm.Rows[x].ItemArray[1]);

            }


            var tmodulos = from pm in entity.Modulos
                           join md in entity.ModuloPrincipal on pm.FKModuloPrincipal equals md.IdModuloPrincipal
                           where lMod.Contains(pm.IdModulos)
                           & md.EstadoModuloPrin == true
                           & pm.EstadoModulo == true
                           orderby pm.FKModuloPrincipal
                           select new
                           {
                               pm.DescripcionModulo,
                               md.DescripcionModuloPrin,
                               pm.FKModuloPrincipal,
                               pm.IdModulos
                           };

            DataTable dtMods = tmodulos.CopyAnonymusToDataTable();
            DataRow dtR = dtMods.NewRow();
            dtR[2] = "0";
            dtR[3] = "0";
            dtMods.Rows.Add(dtR);
            short modPrinAnterior = 0;
            MenuStrip mnStrip = new MenuStrip();
            ToolStripMenuItem mnPrin = new ToolStripMenuItem();
            

            foreach (DataRow dr in dtMods.Rows)
            {
                if (modPrinAnterior == Convert.ToInt16(dr[2]))
                {
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(dr[0].ToString(), null, ChildClick);
                    subMenu.Name = dr[0].ToString();
                    mnPrin.DropDownItems.Add(subMenu);
                }
                else
                {
                    if (!mnPrin.Name.Equals(""))
                        mnStrip.Items.Add(mnPrin);
                    mnPrin = new ToolStripMenuItem(dr[1].ToString());

                    mnPrin.Name = dr[1].ToString();
                    //MessageBox.Show(mnPrin.Name);
                    //variable que retiene el nombre
                    if (mnPrin.Name != "")
                    {
                        modulo = dr[1].ToString();
                    }
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(dr[0].ToString(), null, ChildClick);
                    subMenu.Name = dr[0].ToString();
                    mnPrin.DropDownItems.Add(subMenu);

                    // de aqui se toma si es parte de las auditorías y se bloquean los botones $linea 157
                }
                modPrinAnterior = Convert.ToInt16(dr[2]);

            }
            //estilo para el submenú de opciones
            mnStrip.Location = new Point(203, 0);
            mnStrip.Size = new Size(1000, 28);
            panelMenu.Controls.Add(mnStrip);
            btnCerrar.BringToFront();
            mnStrip.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Reporteria.PresentadordeReportes());

        }
        //teclas rapidas ( Atajos del teclado para abrir pestañas ).
        private void Menu_estilo_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.NumPad1)
            {
                btnInventario.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad3)
            {
                btnVentas.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad2)
            {
                btnComprar.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.NumPad5)
            {
                abrirFormularioHijo(new Punto_de_venta.Inicio.Inicio());
            }
        }

        public void ChildClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            

            var tipo = Type.GetType("Punto_de_venta." + menu.Name);

            var frm = Activator.CreateInstance(tipo);

            Form formulario = (Form)frm;

            formulario.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //formulario para pruebas
        private void button3_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Mantenimientos.FormCondicional(modulo));
        }
    }
}
