using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Nombre_del_campo_en_MSResources
    {
        //private static IResourceProvider resourceProviderNombre_del_campo_en_MS = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Nombre_del_campo_en_MSResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderNombre_del_campo_en_MS = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nombre_del_campo_en_MSResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderNombre_del_campo_en_MS = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nombre_del_campo_en_MSResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Nombre_del_campo_en_MS</summary>
        public static string Nombre_del_campo_en_MS
        {
            get
            {
                SetPath();
                return resourceProviderNombre_del_campo_en_MS.GetResource("Nombre_del_campo_en_MS", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderNombre_del_campo_en_MS.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderNombre_del_campo_en_MS.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Fisico_del_Campo</summary>
        public static string Nombre_Fisico_del_Campo
        {
            get
            {
                SetPath();
                return resourceProviderNombre_del_campo_en_MS.GetResource("Nombre_Fisico_del_Campo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Fisico_de_la_Tabla</summary>
        public static string Nombre_Fisico_de_la_Tabla
        {
            get
            {
                SetPath();
                return resourceProviderNombre_del_campo_en_MS.GetResource("Nombre_Fisico_de_la_Tabla", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderNombre_del_campo_en_MS.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
