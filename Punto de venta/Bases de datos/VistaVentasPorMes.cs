
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
    
public partial class VistaVentasPorMes
{

    public int IdVenta { get; set; }

    public System.DateTime Fecha_Venta { get; set; }

    public decimal Total_Venta { get; set; }

    public Nullable<int> Estado { get; set; }

    public Nullable<decimal> Impuesto_Gravado_15_ { get; set; }

    public Nullable<decimal> Impuesto_Gravado_18_ { get; set; }

    public Nullable<decimal> ISV15_ { get; set; }

    public Nullable<decimal> ISV18_ { get; set; }

    public Nullable<decimal> Importe_Exento { get; set; }

    public Nullable<decimal> Importe_Exonerado { get; set; }

    public Nullable<decimal> Enero { get; set; }

    public Nullable<decimal> Febrero { get; set; }

    public Nullable<decimal> Marzo { get; set; }

    public Nullable<decimal> Abril { get; set; }

    public Nullable<decimal> Mayo { get; set; }

    public Nullable<decimal> Junio { get; set; }

    public Nullable<decimal> Julio { get; set; }

    public Nullable<decimal> Agosto { get; set; }

    public Nullable<decimal> Septiembre { get; set; }

    public Nullable<decimal> Octubre { get; set; }

    public Nullable<decimal> Noviembre { get; set; }

    public Nullable<decimal> Diciembre { get; set; }

}

}