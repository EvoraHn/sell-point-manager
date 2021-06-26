using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//AGREGANDO NAME SPACES PARA SQL
using System.Data.SqlClient;
using System.Configuration;

namespace Punto_de_venta.Inventario
{
    public partial class InventarioCompleto : Form
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["Punto_de_venta.Properties.Settings.BPBConnectionString"].ConnectionString;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);
        public InventarioCompleto()
        {
            InitializeComponent();
        }
        DataSet resultados = new DataSet();
        DataView mifiltro;

        public void leer_datos(string query, ref DataSet dstprincipal, String tabla)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dstprincipal, tabla);
                da.Dispose();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InventarioCompleto_Load(object sender, EventArgs e)
        {
            this.leer_datos("select * from vista1", ref resultados, "Vista1");
            this.mifiltro = ((DataTable)resultados.Tables["vista1"]).DefaultView;
            this.gvInventario.DataSource = mifiltro;
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    salida_datos = "(Codigo LIKE '%" + palabra + "%' OR Nombre_de_Producto LIKE '%" + palabra + "%' OR Categoria LIKE '%" + palabra + "%' OR Proveedor LIKE '%" + palabra + "%' )";
                }
                else
                {
                    salida_datos += "AND(Codigo LIKE '%" + palabra + "%' OR Nombre_de_Producto LIKE '%" + palabra + "%' OR Categoria LIKE '%" + palabra + "%' OR Proveedor LIKE '%" + palabra + "%' )";                    
                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }
    }
}

