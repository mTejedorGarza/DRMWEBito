using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Roles_para_NotificarResources
    {
        //private static IResourceProvider resourceProviderRoles_para_Notificar = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Roles_para_NotificarResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRoles_para_Notificar = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Roles_para_NotificarResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRoles_para_Notificar = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Roles_para_NotificarResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Roles_para_Notificar</summary>
        public static string Roles_para_Notificar
        {
            get
            {
                SetPath();
                return resourceProviderRoles_para_Notificar.GetResource("Roles_para_Notificar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderRoles_para_Notificar.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rol</summary>
        public static string Rol
        {
            get
            {
                SetPath();
                return resourceProviderRoles_para_Notificar.GetResource("Rol", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRoles_para_Notificar.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
