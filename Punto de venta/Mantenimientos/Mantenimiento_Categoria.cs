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
    public partial class Mantenimiento_Categoria : Form
    {
        //conexión a la base de datos
        Punto_de_venta.Bases_de_datos.BPBEntities1 entity = new Bases_de_datos.BPBEntities1();
        //filtro para el botón buscar
        DataView mifiltro;
        //inicializar las variables
        int id = 0;
        bool editar = false;
        public Mantenimiento_Categoria()
        {
            InitializeComponent();
        }
        private void Mantenimiento_Categoria_Load(object sender, EventArgs e)
        {
            Mostrar_datos();
        }
        private void Mostrar_datos()
        {
            var tProductos = from p in entity.Categoria
                             select new
                             {
                                 p.IdCategoria,
                                 p.Nombre,
                                 p.Descripcion,
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
            Punto_de_venta.Clases.almacen_de_datos.Categoria = txtId.Text;
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
                    var tabla = entity.Categoria.FirstOrDefault(x => x.IdCategoria == id);
                    txtId.Text = tabla.IdCategoria.ToString();
                    txtNombre.Text = tabla.Nombre;
                    txtDescripcion.Text = tabla.Descripcion;
                    editar = true;
                    btnEnviar.Enabled = true;
                }
                catch (Exception)
                {}
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
                    salida_datos = "(IdCategoria LIKE '%" + palabra + "%' OR Nombre LIKE '%" + palabra +
                        "%' OR Descripcion LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos = "(IdCategoria LIKE '%" + palabra + "%' OR Nombre LIKE '%" + palabra +
                        "%' OR Descripcion LIKE '%" + palabra + "%' )";
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }
        
        private void Limpiar()
        {
            txtId.Text = txtNombre.Text = txtDescripcion.Text = string.Empty;
            editar = false;
            txtBuscar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                try
                {
                    if (txtNombre.Text.Equals("") | txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        var tablaP = entity.Categoria.FirstOrDefault(x => x.IdCategoria == id);
                        //tablaP.IdCategoria = Convert.ToInt32(txtId.Text);
                        tablaP.Nombre = txtNombre.Text;
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
                    if (txtNombre.Text.Equals("") | txtDescripcion.Text.Equals(""))
                    {
                        MessageBox.Show("Por favor ingresar todos los datos en el formulario");
                        return;
                    }
                    else
                    {
                        Punto_de_venta.Bases_de_datos.Categoria tabla = new Punto_de_venta.Bases_de_datos.Categoria();
                        tabla.Descripcion = txtDescripcion.Text;
                        tabla.Nombre = txtNombre.Text;
                        //tabla.IdCategoria = Convert.ToInt32(txtId.Text);
                        entity.Categoria.Add(tabla);
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
                    var tablaP = entity.Categoria.FirstOrDefault(x => x.IdCategoria == id);
                    entity.Categoria.Remove(tablaP);
                    entity.SaveChanges();
                    MessageBox.Show("¡Registro eliminado correctamente!");
                    Limpiar();
                    Mostrar_datos();

                }
                catch (Exception)
                {
                    MessageBox.Show("¡No puedes eliminar una categoría si ya está enlazada con un producto!"); return;
                }
            }
        }
    }
}
