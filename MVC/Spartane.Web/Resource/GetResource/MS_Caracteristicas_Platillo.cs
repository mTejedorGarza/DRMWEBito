using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Caracteristicas_PlatilloResources
    {
        //private static IResourceProvider resourceProviderMS_Caracteristicas_Platillo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Caracteristicas_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Caracteristicas_Platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Caracteristicas_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Caracteristicas_Platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Caracteristicas_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Caracteristicas_Platillo</summary>
        public static string MS_Caracteristicas_Platillo
        {
            get
            {
                SetPath();
                return resourceProviderMS_Caracteristicas_Platillo.GetResource("MS_Caracteristicas_Platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Caracteristicas_Platillo.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Caracteristicas</summary>
        public static string Caracteristicas
        {
            get
            {
                SetPath();
                return resourceProviderMS_Caracteristicas_Platillo.GetResource("Caracteristicas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Caracteristicas_Platillo.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
