using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Campos_por_FuncionalidadResources
    {
        //private static IResourceProvider resourceProviderMS_Campos_por_Funcionalidad = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Campos_por_FuncionalidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Campos_por_Funcionalidad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Campos_por_FuncionalidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Campos_por_Funcionalidad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Campos_por_FuncionalidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Campos_por_Funcionalidad</summary>
        public static string MS_Campos_por_Funcionalidad
        {
            get
            {
                SetPath();
                return resourceProviderMS_Campos_por_Funcionalidad.GetResource("MS_Campos_por_Funcionalidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Campos_por_Funcionalidad.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Campo</summary>
        public static string Campo
        {
            get
            {
                SetPath();
                return resourceProviderMS_Campos_por_Funcionalidad.GetResource("Campo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Campos_por_Funcionalidad.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
