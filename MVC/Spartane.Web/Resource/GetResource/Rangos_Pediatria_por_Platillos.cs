using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Rangos_Pediatria_por_PlatillosResources
    {
        //private static IResourceProvider resourceProviderRangos_Pediatria_por_Platillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Rangos_Pediatria_por_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRangos_Pediatria_por_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Rangos_Pediatria_por_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRangos_Pediatria_por_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Rangos_Pediatria_por_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Rangos_Pediatria_por_Platillos</summary>
        public static string Rangos_Pediatria_por_Platillos
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Rangos_Pediatria_por_Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_rango</summary>
        public static string Nombre_de_rango
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Nombre_de_rango", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad_minima</summary>
        public static string Edad_minima
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Edad_minima", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad_maxima</summary>
        public static string Edad_maxima
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Edad_maxima", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiene_padecimientos</summary>
        public static string Tiene_padecimientos
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Tiene_padecimientos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Padecimientos</summary>
        public static string Padecimientos
        {
            get
            {
                SetPath();
                return resourceProviderRangos_Pediatria_por_Platillos.GetResource("Padecimientos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRangos_Pediatria_por_Platillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
