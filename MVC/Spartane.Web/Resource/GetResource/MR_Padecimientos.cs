using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MR_PadecimientosResources
    {
        //private static IResourceProvider resourceProviderMR_Padecimientos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MR_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMR_Padecimientos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMR_Padecimientos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MR_Padecimientos</summary>
        public static string MR_Padecimientos
        {
            get
            {
                SetPath();
                return resourceProviderMR_Padecimientos.GetResource("MR_Padecimientos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMR_Padecimientos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Padecimiento</summary>
        public static string Padecimiento
        {
            get
            {
                SetPath();
                return resourceProviderMR_Padecimientos.GetResource("Padecimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMR_Padecimientos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
