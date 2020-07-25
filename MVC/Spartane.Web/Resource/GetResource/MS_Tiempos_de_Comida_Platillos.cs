using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Tiempos_de_Comida_PlatillosResources
    {
        //private static IResourceProvider resourceProviderMS_Tiempos_de_Comida_Platillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Tiempos_de_Comida_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Tiempos_de_Comida_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Tiempos_de_Comida_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Tiempos_de_Comida_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Tiempos_de_Comida_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Tiempos_de_Comida_Platillos</summary>
        public static string MS_Tiempos_de_Comida_Platillos
        {
            get
            {
                SetPath();
                return resourceProviderMS_Tiempos_de_Comida_Platillos.GetResource("MS_Tiempos_de_Comida_Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Tiempos_de_Comida_Platillos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiempo_de_Comida</summary>
        public static string Tiempo_de_Comida
        {
            get
            {
                SetPath();
                return resourceProviderMS_Tiempos_de_Comida_Platillos.GetResource("Tiempo_de_Comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Tiempos_de_Comida_Platillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
