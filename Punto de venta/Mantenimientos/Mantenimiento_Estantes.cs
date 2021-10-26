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

    public partial class Mantenimiento_Estantes : Form
    {
        string modulo = "";
        //private IForm _form;

        //public Mantenimiento_Estantes (IForm form)
        //{ //este es el constructor
        //    _form = form;
        //}
        //Conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        int id = 0;
        bool editar = false;
        public Mantenimiento_Estantes()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Estantes_Load(object sender, EventArgs e)
        {
            Mostrar_datos();
        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Estante
                             select new
                             {
                                 p.IdEstante,
                                 p.NombreEstante,
                                 p.DescripciónEstante,
                             };
            this.mifiltro = (tProductos.CopyAnonymusToDataTable()).DefaultView;
            this.dgDatos.DataSource = mifiltro;

        }

        
        private void btnEstante_Click(object sender, EventArgs e)
        {

            Punto_de_venta.Mantenimientos.Mantenimiento_Productos Productos = new Punto_de_venta.Mantenimientos.Mantenimiento_Productos(modulo);
            Punto_de_venta.Clases.almacen_de_datos.Estante = txtId.Text;
            //Productos.Traer_Datos();
            Productos.btnTraerEstante.PerformClick();
            //MessageBox.Show("exito");
            this.Close();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Punto_de_venta.Mantenimientos.Mantenimiento_Productos Productos = new Punto_de_venta.Mantenimientos.Mantenimiento_Productos(modulo);
            Punto_de_venta.Clases.almacen_de_datos.Estante = txtId.Text;
            Productos.Traer_Datos();
            this.Close();


        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    id = Convert.ToInt32(dgDatos.SelectedCells[0].Value);
                    var tabla = entity.Estante.FirstOrDefault(x => x.IdEstante == id);
                    txtId.Text = tabla.IdEstante.ToString();
                    txtNombre.Text = tabla.NombreEstante;
                    txtDescripcion.Text =tabla.DescripciónEstante;
                    editar = true; txtId.Enabled = false; btnEstante.Enabled = true;
                }
                catch (Exception)
                {
                    // MessageBox.Show("Error");
                }
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
                    salida_datos = "(IdEstante LIKE '%" + palabra + "%' OR NombreEstante LIKE '%" + palabra +
                        "%' OR DescripciónEstante LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(IdEstante LIKE '%" + palabra + "%' OR NombreEstante LIKE '%" + palabra +
                         "%' OR DescripciónEstante LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }
        private void Limpiar()
        {
            //metodo de limpiar textbox
            txtId.Text = txtNombre.Text = txtDescripcion.Text  = string.Empty;
            editar = false;
            txtBuscar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (editar)
            {
                try
                {
                    if (txtNombre.Text.Equals("") | txtId.Text.Equals("") | txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        var tablaP = entity.Estante.FirstOrDefault(x => x.IdEstante == id);
                        tablaP.IdEstante = Convert.ToInt32(txtId.Text);
                        tablaP.NombreEstante = txtNombre.Text;
                        tablaP.DescripciónEstante = txtDescripcion.Text;
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
                    if (txtNombre.Text.Equals("") | txtId.Text.Equals("") | txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        Punto_de_venta.Bases_de_datos.Estante tabla = new Punto_de_venta.Bases_de_datos.Estante();
                        tabla.DescripciónEstante = txtDescripcion.Text;
                        tabla.NombreEstante = txtNombre.Text;
                        tabla.IdEstante = Convert.ToInt32(txtId.Text);
                        entity.Estante.Add(tabla);
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
            Limpiar();
            txtId.Enabled = true;
            btnEstante.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (editar || txtId.Text != "")
            {
                try
                {
                    var tablaP = entity.Estante.FirstOrDefault(x => x.IdEstante == id);
                    entity.Estante.Remove(tablaP);
                    entity.SaveChanges();
                    MessageBox.Show("¡Registro eliminado correctamente!");
                    Limpiar();
                    Mostrar_datos();

                }
                catch (Exception)
                {
                    MessageBox.Show("¡No puedes eliminar un Estante si ya está en facturas!"); return;
                }
            }
        }

      
    }
}
