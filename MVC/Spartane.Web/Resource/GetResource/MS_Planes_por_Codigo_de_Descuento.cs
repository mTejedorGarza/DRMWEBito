using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Planes_por_Codigo_de_DescuentoResources
    {
        //private static IResourceProvider resourceProviderMS_Planes_por_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Planes_por_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Planes_por_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Planes_por_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Planes_por_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Planes_por_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Planes_por_Codigo_de_Descuento</summary>
        public static string MS_Planes_por_Codigo_de_Descuento
        {
            get
            {
                SetPath();
                return resourceProviderMS_Planes_por_Codigo_de_Descuento.GetResource("MS_Planes_por_Codigo_de_Descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Planes_por_Codigo_de_Descuento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Planes_de_Suscripcion</summary>
        public static string Planes_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderMS_Planes_por_Codigo_de_Descuento.GetResource("Planes_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Planes_por_Codigo_de_Descuento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
