
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
    
public partial class Compra
{

    public int IdCompra { get; set; }

    public string Producto { get; set; }

    public Nullable<int> Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Total { get; set; }



    public virtual Producto Producto1 { get; set; }

}

}
