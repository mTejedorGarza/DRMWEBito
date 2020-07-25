using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Tipo_de_Ejercicio_RutinaResources
    {
        //private static IResourceProvider resourceProviderTipo_de_Ejercicio_Rutina = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Tipo_de_Ejercicio_RutinaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTipo_de_Ejercicio_Rutina = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tipo_de_Ejercicio_RutinaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTipo_de_Ejercicio_Rutina = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tipo_de_Ejercicio_RutinaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Tipo_de_Ejercicio_Rutina</summary>
        public static string Tipo_de_Ejercicio_Rutina
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("Tipo_de_Ejercicio_Rutina", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Rutina</summary>
        public static string Tipo_de_Rutina
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("Tipo_de_Rutina", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_para_Secuencia</summary>
        public static string Nombre_para_Secuencia
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("Nombre_para_Secuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTipo_de_Ejercicio_Rutina.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
