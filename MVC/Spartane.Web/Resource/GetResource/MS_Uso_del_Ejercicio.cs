using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Uso_del_EjercicioResources
    {
        //private static IResourceProvider resourceProviderMS_Uso_del_Ejercicio = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Uso_del_EjercicioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Uso_del_Ejercicio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Uso_del_EjercicioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Uso_del_Ejercicio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Uso_del_EjercicioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Uso_del_Ejercicio</summary>
        public static string MS_Uso_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Uso_del_Ejercicio.GetResource("MS_Uso_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Uso_del_Ejercicio.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Uso_del_Ejercicio</summary>
        public static string Uso_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Uso_del_Ejercicio.GetResource("Uso_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Uso_del_Ejercicio.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
