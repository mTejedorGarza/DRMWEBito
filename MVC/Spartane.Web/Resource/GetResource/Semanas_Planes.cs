using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Semanas_PlanesResources
    {
        //private static IResourceProvider resourceProviderSemanas_Planes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Semanas_PlanesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSemanas_Planes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Semanas_PlanesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSemanas_Planes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Semanas_PlanesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Semanas_Planes</summary>
        public static string Semanas_Planes
        {
            get
            {
                SetPath();
                return resourceProviderSemanas_Planes.GetResource("Semanas_Planes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderSemanas_Planes.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semana</summary>
        public static string Semana
        {
            get
            {
                SetPath();
                return resourceProviderSemanas_Planes.GetResource("Semana", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semanas_del_mes</summary>
        public static string Semanas_del_mes
        {
            get
            {
                SetPath();
                return resourceProviderSemanas_Planes.GetResource("Semanas_del_mes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSemanas_Planes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
