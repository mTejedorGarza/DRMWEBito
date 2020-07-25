using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Rango_Consumo_BebidasResources
    {
        //private static IResourceProvider resourceProviderRango_Consumo_Bebidas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Rango_Consumo_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRango_Consumo_Bebidas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Rango_Consumo_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRango_Consumo_Bebidas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Rango_Consumo_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Rango_Consumo_Bebidas</summary>
        public static string Rango_Consumo_Bebidas
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Rango_Consumo_Bebidas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Es_agua</summary>
        public static string Es_agua
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Es_agua", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad_de_Medida</summary>
        public static string Unidad_de_Medida
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Unidad_de_Medida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderRango_Consumo_Bebidas.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRango_Consumo_Bebidas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
