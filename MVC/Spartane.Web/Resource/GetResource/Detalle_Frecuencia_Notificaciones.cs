using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Frecuencia_NotificacionesResources
    {
        //private static IResourceProvider resourceProviderDetalle_Frecuencia_Notificaciones = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Frecuencia_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Frecuencia_Notificaciones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Frecuencia_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Frecuencia_Notificaciones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Frecuencia_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Frecuencia_Notificaciones</summary>
        public static string Detalle_Frecuencia_Notificaciones
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("Detalle_Frecuencia_Notificaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia</summary>
        public static string Frecuencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("Frecuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dia</summary>
        public static string Dia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora</summary>
        public static string Hora
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("Hora", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Frecuencia_Notificaciones.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
