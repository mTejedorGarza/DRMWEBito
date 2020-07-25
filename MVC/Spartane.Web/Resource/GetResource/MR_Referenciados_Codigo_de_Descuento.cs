using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MR_Referenciados_Codigo_de_DescuentoResources
    {
        //private static IResourceProvider resourceProviderMR_Referenciados_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MR_Referenciados_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMR_Referenciados_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_Referenciados_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMR_Referenciados_Codigo_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_Referenciados_Codigo_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MR_Referenciados_Codigo_de_Descuento</summary>
        public static string MR_Referenciados_Codigo_de_Descuento
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("MR_Referenciados_Codigo_de_Descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_usuario</summary>
        public static string Tipo_de_usuario
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("Tipo_de_usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario</summary>
        public static string Usuario
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("Usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_aplicacion</summary>
        public static string Fecha_de_aplicacion
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("Fecha_de_aplicacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descuento_Total</summary>
        public static string Descuento_Total
        {
            get
            {
                SetPath();
                return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("Descuento_Total", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMR_Referenciados_Codigo_de_Descuento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
