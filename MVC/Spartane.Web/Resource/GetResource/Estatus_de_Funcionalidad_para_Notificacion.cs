using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Estatus_de_Funcionalidad_para_NotificacionResources
    {
        //private static IResourceProvider resourceProviderEstatus_de_Funcionalidad_para_Notificacion = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Estatus_de_Funcionalidad_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderEstatus_de_Funcionalidad_para_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Estatus_de_Funcionalidad_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderEstatus_de_Funcionalidad_para_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Estatus_de_Funcionalidad_para_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Estatus_de_Funcionalidad_para_Notificacion</summary>
        public static string Estatus_de_Funcionalidad_para_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("Estatus_de_Funcionalidad_para_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Campo_para_Estatus</summary>
        public static string Campo_para_Estatus
        {
            get
            {
                SetPath();
                return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("Campo_para_Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Fisico_del_Campo</summary>
        public static string Nombre_Fisico_del_Campo
        {
            get
            {
                SetPath();
                return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("Nombre_Fisico_del_Campo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Fisico_de_la_Tabla</summary>
        public static string Nombre_Fisico_de_la_Tabla
        {
            get
            {
                SetPath();
                return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("Nombre_Fisico_de_la_Tabla", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderEstatus_de_Funcionalidad_para_Notificacion.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
