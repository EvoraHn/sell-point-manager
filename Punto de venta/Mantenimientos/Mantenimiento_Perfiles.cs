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
    public partial class Mantenimiento_Perfiles : Form
    {
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Punto_de_venta.Bases_de_datos.BPBEntities1();
        public Mantenimiento_Perfiles()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Perfiles_Load(object sender, EventArgs e)
        {
            cmbModPrin.SelectedIndex = -1;

            var tPerfil = from p in entity.Perfiles
                          where p.EstadoPerfil == true
                          select new
                          {
                              p.IdPerfil,
                              p.DescripcionPerfil
                          };

            DataTable dtPerfiles = tPerfil.CopyAnonymusToDataTable();
            cmbPerfiles.DataSource = dtPerfiles;
            cmbPerfiles.ValueMember = dtPerfiles.Columns[0].ColumnName;
            cmbPerfiles.DisplayMember = dtPerfiles.Columns[1].ColumnName;

            var tModPrin = from mp in entity.ModuloPrincipal
                           where mp.EstadoModuloPrin == true
                           select new
                           {
                               mp.IdModuloPrincipal,
                               mp.DescripcionModuloPrin
                           };

            DataTable dtModPrin = tModPrin.CopyAnonymusToDataTable();

            cmbModPrin.DataSource = dtModPrin;

            cmbModPrin.ValueMember = dtModPrin.Columns[0].ColumnName;
            cmbModPrin.DisplayMember = dtModPrin.Columns[1].ColumnName;
        }
        private void cmbModPrin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int idModulo = Convert.ToInt32(cmbModPrin.SelectedValue);

                var tMod = from mod in entity.Modulos
                           where mod.FKModuloPrincipal == idModulo
                           select new
                           {
                               mod.IdModulos,
                               mod.DescripcionModulo
                           };

                DataTable dtMod = tMod.CopyAnonymusToDataTable();
                cmbModulo.DataSource = dtMod;

                cmbModulo.ValueMember = dtMod.Columns[0].ColumnName;
                cmbModulo.DisplayMember = dtMod.Columns[1].ColumnName;

            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbPerfiles.SelectedIndex = cmbModPrin.SelectedIndex = cmbModulo.SelectedIndex = -1;

        }

        private void btnGurardar_Click(object sender, EventArgs e)
        {
            if (cmbPerfiles.SelectedIndex == -1 || cmbModPrin.SelectedIndex == -1 || cmbModulo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione todas las listas");
            }
            else
            {
                Punto_de_venta.Bases_de_datos.PerfilModulo pm = new Punto_de_venta.Bases_de_datos.PerfilModulo();
                pm.FKPerfilId = Convert.ToInt16(cmbPerfiles.SelectedValue);
                pm.FKModuloId = Convert.ToInt16(cmbModulo.SelectedValue);

                entity.PerfilModulo.Add(pm);
                entity.SaveChanges();

                cmbPerfiles.SelectedIndex = cmbModPrin.SelectedIndex = cmbModulo.SelectedIndex = -1;
            }
        }
    }
}

