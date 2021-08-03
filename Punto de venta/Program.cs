using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Punto_de_venta.Menú.Menu_estilo_1());
            //Application.Run(new Punto_de_venta.Informes.Form1());
            Application.Run(new Punto_de_venta.Inicio.Login());
            //Application.Run(new Punto_de_venta.Mantenimientos.Mantenimiento_Perfiles());
            
        }
    }
}
