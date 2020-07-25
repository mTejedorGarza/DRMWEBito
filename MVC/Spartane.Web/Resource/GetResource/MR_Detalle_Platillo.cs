using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MR_Detalle_PlatilloResources
    {
        //private static IResourceProvider resourceProviderMR_Detalle_Platillo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MR_Detalle_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMR_Detalle_Platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_Detalle_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMR_Detalle_Platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_Detalle_PlatilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MR_Detalle_Platillo</summary>
        public static string MR_Detalle_Platillo
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("MR_Detalle_Platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ingrediente</summary>
        public static string Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_en_Fraccion</summary>
        public static string Cantidad_en_Fraccion
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Cantidad_en_Fraccion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_a_mostrar</summary>
        public static string Cantidad_a_mostrar
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Cantidad_a_mostrar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ingrediente_a_mostrar</summary>
        public static string Ingrediente_a_mostrar
        {
            get
            {
                SetPath();
                return resourceProviderMR_Detalle_Platillo.GetResource("Ingrediente_a_mostrar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMR_Detalle_Platillo.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
