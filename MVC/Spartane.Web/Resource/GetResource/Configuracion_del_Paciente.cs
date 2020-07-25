using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Configuracion_del_PacienteResources
    {
        //private static IResourceProvider resourceProviderConfiguracion_del_Paciente = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Configuracion_del_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderConfiguracion_del_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_del_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderConfiguracion_del_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_del_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Configuracion_del_Paciente</summary>
        public static string Configuracion_del_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Configuracion_del_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_Registrado</summary>
        public static string Usuario_Registrado
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Usuario_Registrado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rol</summary>
        public static string Rol
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Rol", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Token</summary>
        public static string Token
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Token", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Android</summary>
        public static string Android
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Android", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>iOS</summary>
        public static string iOS
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("iOS", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permite_notificaciones_por_email</summary>
        public static string Permite_notificaciones_por_email
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Permite_notificaciones_por_email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permite_notificaciones_push</summary>
        public static string Permite_notificaciones_push
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("Permite_notificaciones_push", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>MR_Notificaciones</summary>
        public static string MR_Notificaciones
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_del_Paciente.GetResource("MR_Notificaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderConfiguracion_del_Paciente.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
