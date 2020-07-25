﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Titulos_Personales;
using Spartane.Core.Classes.Tipos_de_Especialistas;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Sexo;
using Spartane.Core.Classes.Estatus;
using Spartane.Core.Classes.Estatus_Workflow_Especialistas;
using Spartane.Core.Classes.Tipo_Workflow_Especialistas;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Profesiones;
using Spartane.Core.Classes.Especialidades;
using Spartane.Core.Classes.Regimenes_Fiscales;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Bancos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Medicos
{
    /// <summary>
    /// Medicos table
    /// </summary>
    public class Medicos: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public int? Titulo_Personal { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Tipo_de_Especialista { get; set; }
        public int? Foto { get; set; }
        //public string Foto_URL { get; set; }
        public string Nombre_de_usuario { get; set; }
        public int? Usuario_Registrado { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Pais_de_nacimiento { get; set; }
        public int? Entidad_de_nacimiento { get; set; }
        public int? Sexo { get; set; }
        public string Email_institucional { get; set; }
        public int? Estatus { get; set; }
        public int? Estatus_WF { get; set; }
        public int? Tipo_WF { get; set; }
        public int? Email_ppal_publico { get; set; }
        public string Email_de_contacto { get; set; }
        public string Calle { get; set; }
        public string Numero_exterior { get; set; }
        public string Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? CP { get; set; }
        public string Ciudad { get; set; }
        public int? Estado { get; set; }
        public int? Pais { get; set; }
        public string Telefonos { get; set; }
        public int? En_Hospital { get; set; }
        public string Nombre_del_Hospital { get; set; }
        public string Piso_hospital { get; set; }
        public string Numero_de_consultorio { get; set; }
        public int? Se_ajusta_tabulador { get; set; }
        public int? Profesion { get; set; }
        public int? Especialidad { get; set; }
        public string Resumen_Profesional { get; set; }
        public int? Regimen_Fiscal { get; set; }
        public string Nombre_o_Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Calle_Fiscal { get; set; }
        public string Numero_exterior_Fiscal { get; set; }
        public string Numero_interior_Fiscal { get; set; }
        public string Colonia_Fiscal { get; set; }
        public int? CP_Fiscal { get; set; }
        public string Ciudad_Fiscal { get; set; }
        public int? Estado_Fiscal { get; set; }
        public int? Pais_Fiscal { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public int? Cedula_Fiscal_Documento { get; set; }
        //public string Cedula_Fiscal_Documento_URL { get; set; }
        public int? Comprobante_de_Domicilio { get; set; }
        //public string Comprobante_de_Domicilio_URL { get; set; }
        public int? Calificacion_Red_de_Medicos { get; set; }
        public int? Banco { get; set; }
        public string CLABE_Interbancaria { get; set; }
        public string Numero_de_Cuenta { get; set; }
        public string Nombre_del_Titular { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Titulo_Personal")]
        public virtual Spartane.Core.Classes.Titulos_Personales.Titulos_Personales Titulo_Personal_Titulos_Personales { get; set; }
        [ForeignKey("Tipo_de_Especialista")]
        public virtual Spartane.Core.Classes.Tipos_de_Especialistas.Tipos_de_Especialistas Tipo_de_Especialista_Tipos_de_Especialistas { get; set; }
        [ForeignKey("Foto")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Foto_Spartane_File { get; set; }
        [ForeignKey("Usuario_Registrado")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_Registrado_Spartan_User { get; set; }
        [ForeignKey("Pais_de_nacimiento")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_de_nacimiento_Pais { get; set; }
        [ForeignKey("Entidad_de_nacimiento")]
        public virtual Spartane.Core.Classes.Estado.Estado Entidad_de_nacimiento_Estado { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Classes.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Estatus_WF")]
        public virtual Spartane.Core.Classes.Estatus_Workflow_Especialistas.Estatus_Workflow_Especialistas Estatus_WF_Estatus_Workflow_Especialistas { get; set; }
        [ForeignKey("Tipo_WF")]
        public virtual Spartane.Core.Classes.Tipo_Workflow_Especialistas.Tipo_Workflow_Especialistas Tipo_WF_Tipo_Workflow_Especialistas { get; set; }
        [ForeignKey("Email_ppal_publico")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Email_ppal_publico_Respuesta_Logica { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("En_Hospital")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica En_Hospital_Respuesta_Logica { get; set; }
        [ForeignKey("Se_ajusta_tabulador")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Se_ajusta_tabulador_Respuesta_Logica { get; set; }
        [ForeignKey("Profesion")]
        public virtual Spartane.Core.Classes.Profesiones.Profesiones Profesion_Profesiones { get; set; }
        [ForeignKey("Especialidad")]
        public virtual Spartane.Core.Classes.Especialidades.Especialidades Especialidad_Especialidades { get; set; }
        [ForeignKey("Regimen_Fiscal")]
        public virtual Spartane.Core.Classes.Regimenes_Fiscales.Regimenes_Fiscales Regimen_Fiscal_Regimenes_Fiscales { get; set; }
        [ForeignKey("Estado_Fiscal")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Fiscal_Estado { get; set; }
        [ForeignKey("Pais_Fiscal")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Fiscal_Pais { get; set; }
        [ForeignKey("Cedula_Fiscal_Documento")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Cedula_Fiscal_Documento_Spartane_File { get; set; }
        [ForeignKey("Comprobante_de_Domicilio")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Comprobante_de_Domicilio_Spartane_File { get; set; }
        [ForeignKey("Banco")]
        public virtual Spartane.Core.Classes.Bancos.Bancos Banco_Bancos { get; set; }

    }
}

