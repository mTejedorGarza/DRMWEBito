using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Funcionalidades_para_NotificacionResources
    {
        //private static IResourceProvider resourceProviderFuncionalidades_para_Notificacion = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Funcionalidades_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderFuncionalidades_para_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Funcionalidades_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderFuncionalidades_para_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Funcionalidades_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Funcionalidades_para_Notificacion</summary>
        public static string Funcionalidades_para_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Funcionalidades_para_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Funcionalidad</summary>
        public static string Funcionalidad
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Funcionalidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Tabla</summary>
        public static string Nombre_de_la_Tabla
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Nombre_de_la_Tabla", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Campos_para_Vigencia</summary>
        public static string Campos_para_Vigencia
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Campos_para_Vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Campos_de_Estatus</summary>
        public static string Campos_de_Estatus
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Campos_de_Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Validacion_Obligatoria</summary>
        public static string Validacion_Obligatoria
        {
            get
            {
                SetPath();
                return resourceProviderFuncionalidades_para_Notificacion.GetResource("Validacion_Obligatoria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderFuncionalidades_para_Notificacion.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
