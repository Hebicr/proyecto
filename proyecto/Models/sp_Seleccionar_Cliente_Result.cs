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
    
    public partial class sp_Seleccionar_Cliente_Result
    {
        public int idCliente { get; set; }
        public string Cedula { get; set; }
        public int id_Genero { get; set; }
        public System.DateTime FechadeNacimiento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string DireccionFisica { get; set; }
        public string TelefonoPrincipal { get; set; }
        public string TelefonoSecundario { get; set; }
        public string CorreoElectronico { get; set; }
        public int id_Provincia { get; set; }
        public int id_Canton { get; set; }
        public int id_Distrito { get; set; }
        public int id_Usuario { get; set; }
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int estado { get; set; }
        public int idRol { get; set; }
    }
}
