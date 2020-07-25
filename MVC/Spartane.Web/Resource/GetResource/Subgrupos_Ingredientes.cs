using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Subgrupos_IngredientesResources
    {
        //private static IResourceProvider resourceProviderSubgrupos_Ingredientes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Subgrupos_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSubgrupos_Ingredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Subgrupos_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSubgrupos_Ingredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Subgrupos_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Subgrupos_Ingredientes</summary>
        public static string Subgrupos_Ingredientes
        {
            get
            {
                SetPath();
                return resourceProviderSubgrupos_Ingredientes.GetResource("Subgrupos_Ingredientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderSubgrupos_Ingredientes.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderSubgrupos_Ingredientes.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clasificacion</summary>
        public static string Clasificacion
        {
            get
            {
                SetPath();
                return resourceProviderSubgrupos_Ingredientes.GetResource("Clasificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSubgrupos_Ingredientes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
