using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Roles_de_Usuario_NotificacionResources
    {
        //private static IResourceProvider resourceProviderMS_Roles_de_Usuario_Notificacion = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Roles_de_Usuario_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Roles_de_Usuario_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Roles_de_Usuario_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Roles_de_Usuario_Notificacion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Roles_de_Usuario_NotificacionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Roles_de_Usuario_Notificacion</summary>
        public static string MS_Roles_de_Usuario_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderMS_Roles_de_Usuario_Notificacion.GetResource("MS_Roles_de_Usuario_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Roles_de_Usuario_Notificacion.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Campo</summary>
        public static string Nombre_del_Campo
        {
            get
            {
                SetPath();
                return resourceProviderMS_Roles_de_Usuario_Notificacion.GetResource("Nombre_del_Campo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Roles_de_Usuario_Notificacion.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
