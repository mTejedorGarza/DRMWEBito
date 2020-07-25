using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MR_TarjetasResources
    {
        //private static IResourceProvider resourceProviderMR_Tarjetas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MR_TarjetasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMR_Tarjetas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_TarjetasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMR_Tarjetas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MR_TarjetasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MR_Tarjetas</summary>
        public static string MR_Tarjetas
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("MR_Tarjetas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Tarjeta</summary>
        public static string Tipo_de_Tarjeta
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Tipo_de_Tarjeta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Tarjeta</summary>
        public static string Numero_de_Tarjeta
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Numero_de_Tarjeta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Titular</summary>
        public static string Nombre_del_Titular
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Nombre_del_Titular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ano_de_vigencia</summary>
        public static string Ano_de_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Ano_de_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Mes_de_vigencia</summary>
        public static string Mes_de_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Mes_de_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Alias_de_la_Tarjeta</summary>
        public static string Alias_de_la_Tarjeta
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Alias_de_la_Tarjeta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderMR_Tarjetas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMR_Tarjetas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
