
//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Punto_de_venta.Bases_de_datos
{

using System;
    using System.Collections.Generic;
    
public partial class Estado
{

    public Estado()
    {

        this.Venta = new HashSet<Venta>();

    }


    public int IdEstado { get; set; }

    public int Estado1 { get; set; }

    public string Descripción_estado { get; set; }



    public virtual ICollection<Venta> Venta { get; set; }

}

}
