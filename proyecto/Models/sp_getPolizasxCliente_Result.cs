//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto.Models
{
    using System;
    
    public partial class sp_getPolizasxCliente_Result
    {
        public int idRegistroPoliza { get; set; }
        public int idCoberturaPoliza { get; set; }
        public int idCliente { get; set; }
        public Nullable<decimal> montoAsegurado { get; set; }
        public Nullable<decimal> porcentajeCobertura { get; set; }
        public Nullable<int> numeroAdiciones { get; set; }
        public Nullable<decimal> montoAdiciones { get; set; }
        public Nullable<decimal> primaAntesImpuestos { get; set; }
        public Nullable<decimal> impuestos { get; set; }
        public Nullable<decimal> primaFinal { get; set; }
    }
}
