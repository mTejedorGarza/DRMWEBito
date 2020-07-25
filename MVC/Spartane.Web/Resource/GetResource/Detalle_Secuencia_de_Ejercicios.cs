using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Secuencia_de_EjerciciosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Secuencia_de_Ejercicios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Secuencia_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Secuencia_de_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Secuencia_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Secuencia_de_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Secuencia_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Secuencia_de_Ejercicios</summary>
        public static string Detalle_Secuencia_de_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Detalle_Secuencia_de_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Orden_del_Ejercicio</summary>
        public static string Orden_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Orden_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Ejercicio</summary>
        public static string Tipo_de_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Tipo_de_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Enfoque</summary>
        public static string Enfoque
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Enfoque", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Secuencia_del_Ejercicio</summary>
        public static string Secuencia_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("Secuencia_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Secuencia_de_Ejercicios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
