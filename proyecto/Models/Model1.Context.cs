﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoProgra6Entities : DbContext
    {
        public ProyectoProgra6Entities()
            : base("name=ProyectoProgra6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adiciones> Adiciones { get; set; }
        public virtual DbSet<AdicionesxCliente> AdicionesxCliente { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<CoberturaPolizas> CoberturaPolizas { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<RegistrosPolizas> RegistrosPolizas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual ObjectResult<RetornaCantones_Result> RetornaCantones(string nombre, Nullable<int> id_Provincia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetornaCantones_Result>("RetornaCantones", nombreParameter, id_ProvinciaParameter);
        }
    
        public virtual ObjectResult<RetornaCantonesID_Result> RetornaCantonesID(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetornaCantonesID_Result>("RetornaCantonesID", id_CantonParameter);
        }
    
        public virtual ObjectResult<RetornaProvincias_Result> RetornaProvincias(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetornaProvincias_Result>("RetornaProvincias", nombreParameter);
        }
    
        public virtual int sp_AgregarAdiccion(string nombre, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AgregarAdiccion", nombreParameter, codigoParameter);
        }
    
        public virtual int sp_AgregarCobertura(string nombre, string descripcion, Nullable<decimal> porcentaje)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var porcentajeParameter = porcentaje.HasValue ?
                new ObjectParameter("Porcentaje", porcentaje) :
                new ObjectParameter("Porcentaje", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AgregarCobertura", nombreParameter, descripcionParameter, porcentajeParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EliminaCanton(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaCanton", id_CantonParameter);
        }
    
        public virtual int sp_eliminarAdiccion(Nullable<int> idAdiccion)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("idAdiccion", idAdiccion) :
                new ObjectParameter("idAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eliminarAdiccion", idAdiccionParameter);
        }
    
        public virtual int sp_eliminarAdiccionCliente(Nullable<int> idAdiccion, Nullable<int> idCliente)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("idAdiccion", idAdiccion) :
                new ObjectParameter("idAdiccion", typeof(int));
    
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eliminarAdiccionCliente", idAdiccionParameter, idClienteParameter);
        }
    
        public virtual int sp_eliminarCobertura(Nullable<int> idCoberturaPoliza)
        {
            var idCoberturaPolizaParameter = idCoberturaPoliza.HasValue ?
                new ObjectParameter("idCoberturaPoliza", idCoberturaPoliza) :
                new ObjectParameter("idCoberturaPoliza", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_eliminarCobertura", idCoberturaPolizaParameter);
        }
    
        public virtual ObjectResult<sp_getAdiccionEditar_Result> sp_getAdiccionEditar(Nullable<int> idAdiccion)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("idAdiccion", idAdiccion) :
                new ObjectParameter("idAdiccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAdiccionEditar_Result>("sp_getAdiccionEditar", idAdiccionParameter);
        }
    
        public virtual ObjectResult<sp_getAdicciones_Result> sp_getAdicciones()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAdicciones_Result>("sp_getAdicciones");
        }
    
        public virtual ObjectResult<sp_getAdiccionesxClienteC_Result> sp_getAdiccionesxClienteC(Nullable<int> idCliente)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAdiccionesxClienteC_Result>("sp_getAdiccionesxClienteC", idClienteParameter);
        }
    
        public virtual ObjectResult<sp_getCoberturaPolizas_Result> sp_getCoberturaPolizas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getCoberturaPolizas_Result>("sp_getCoberturaPolizas");
        }
    
        public virtual ObjectResult<sp_getCoberturaPolizasEditar_Result> sp_getCoberturaPolizasEditar(Nullable<int> idCoberturaPoliza)
        {
            var idCoberturaPolizaParameter = idCoberturaPoliza.HasValue ?
                new ObjectParameter("idCoberturaPoliza", idCoberturaPoliza) :
                new ObjectParameter("idCoberturaPoliza", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getCoberturaPolizasEditar_Result>("sp_getCoberturaPolizasEditar", idCoberturaPolizaParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_Inserta_Clientes_Result> sp_Inserta_Clientes(string cedula, Nullable<int> genero, Nullable<System.DateTime> fecha_nacimiento, string nombre, string primer_apellido, string segundo_apellido, string direccion_fisica, string telefono_principal, string telefono_secundario, string correo_electronico, Nullable<int> id_provincia, Nullable<int> id_canton, Nullable<int> id_distrito)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            var generoParameter = genero.HasValue ?
                new ObjectParameter("genero", genero) :
                new ObjectParameter("genero", typeof(int));
    
            var fecha_nacimientoParameter = fecha_nacimiento.HasValue ?
                new ObjectParameter("fecha_nacimiento", fecha_nacimiento) :
                new ObjectParameter("fecha_nacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var primer_apellidoParameter = primer_apellido != null ?
                new ObjectParameter("primer_apellido", primer_apellido) :
                new ObjectParameter("primer_apellido", typeof(string));
    
            var segundo_apellidoParameter = segundo_apellido != null ?
                new ObjectParameter("segundo_apellido", segundo_apellido) :
                new ObjectParameter("segundo_apellido", typeof(string));
    
            var direccion_fisicaParameter = direccion_fisica != null ?
                new ObjectParameter("direccion_fisica", direccion_fisica) :
                new ObjectParameter("direccion_fisica", typeof(string));
    
            var telefono_principalParameter = telefono_principal != null ?
                new ObjectParameter("telefono_principal", telefono_principal) :
                new ObjectParameter("telefono_principal", typeof(string));
    
            var telefono_secundarioParameter = telefono_secundario != null ?
                new ObjectParameter("telefono_secundario", telefono_secundario) :
                new ObjectParameter("telefono_secundario", typeof(string));
    
            var correo_electronicoParameter = correo_electronico != null ?
                new ObjectParameter("correo_electronico", correo_electronico) :
                new ObjectParameter("correo_electronico", typeof(string));
    
            var id_provinciaParameter = id_provincia.HasValue ?
                new ObjectParameter("id_provincia", id_provincia) :
                new ObjectParameter("id_provincia", typeof(int));
    
            var id_cantonParameter = id_canton.HasValue ?
                new ObjectParameter("id_canton", id_canton) :
                new ObjectParameter("id_canton", typeof(int));
    
            var id_distritoParameter = id_distrito.HasValue ?
                new ObjectParameter("id_distrito", id_distrito) :
                new ObjectParameter("id_distrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Inserta_Clientes_Result>("sp_Inserta_Clientes", cedulaParameter, generoParameter, fecha_nacimientoParameter, nombreParameter, primer_apellidoParameter, segundo_apellidoParameter, direccion_fisicaParameter, telefono_principalParameter, telefono_secundarioParameter, correo_electronicoParameter, id_provinciaParameter, id_cantonParameter, id_distritoParameter);
        }
    
        public virtual int sp_InsertaCanton(Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaCanton", id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual int sp_insertAdiccionCliente(Nullable<int> idCliente, Nullable<int> idAdicion)
        {
            var idClienteParameter = idCliente.HasValue ?
                new ObjectParameter("idCliente", idCliente) :
                new ObjectParameter("idCliente", typeof(int));
    
            var idAdicionParameter = idAdicion.HasValue ?
                new ObjectParameter("idAdicion", idAdicion) :
                new ObjectParameter("idAdicion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_insertAdiccionCliente", idClienteParameter, idAdicionParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_Login(string usuario, string contrasena)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_Login", usuarioParameter, contrasenaParameter);
        }
    
        public virtual int sp_ModificaCanton(Nullable<int> id_Canton, Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaCanton", id_CantonParameter, id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual int sp_ModificarAdiccion(Nullable<int> idAdiccion, string nombre, string codigo)
        {
            var idAdiccionParameter = idAdiccion.HasValue ?
                new ObjectParameter("idAdiccion", idAdiccion) :
                new ObjectParameter("idAdiccion", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificarAdiccion", idAdiccionParameter, nombreParameter, codigoParameter);
        }
    
        public virtual int sp_ModificarCobertura(Nullable<int> idCoberturaPoliza, string nombre, string descripcion, Nullable<decimal> porcentaje)
        {
            var idCoberturaPolizaParameter = idCoberturaPoliza.HasValue ?
                new ObjectParameter("idCoberturaPoliza", idCoberturaPoliza) :
                new ObjectParameter("idCoberturaPoliza", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var porcentajeParameter = porcentaje.HasValue ?
                new ObjectParameter("Porcentaje", porcentaje) :
                new ObjectParameter("Porcentaje", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificarCobertura", idCoberturaPolizaParameter, nombreParameter, descripcionParameter, porcentajeParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_Seleccionar_Cliente_Result> sp_Seleccionar_Cliente(Nullable<int> id_usuario)
        {
            var id_usuarioParameter = id_usuario.HasValue ?
                new ObjectParameter("id_usuario", id_usuario) :
                new ObjectParameter("id_usuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Seleccionar_Cliente_Result>("sp_Seleccionar_Cliente", id_usuarioParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
