//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto.Models
{
    using System;
    
    public partial class sp_Selecionar_Polizas_Admin_Detalles_Id_Result
    {
        public string Cedula { get; set; }
        public string nombreCompleto { get; set; }
        public int idRegistroPoliza { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> montoAsegurado { get; set; }
        public Nullable<decimal> porcentajeCobertura { get; set; }
        public Nullable<int> numeroAdiciones { get; set; }
        public Nullable<decimal> montoAdiciones { get; set; }
        public Nullable<decimal> primaAntesImpuestos { get; set; }
        public Nullable<decimal> impuestos { get; set; }
        public Nullable<decimal> primaFinal { get; set; }
        public Nullable<System.DateTime> fechaVencimiento { get; set; }
    }
}
