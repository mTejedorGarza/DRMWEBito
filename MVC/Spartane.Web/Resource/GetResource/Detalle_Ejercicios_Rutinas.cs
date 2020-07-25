using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Ejercicios_RutinasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Ejercicios_Rutinas</summary>
        public static string Detalle_Ejercicios_Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Detalle_Ejercicios_Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Orden_de_realizacion</summary>
        public static string Orden_de_realizacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Orden_de_realizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Secuencia</summary>
        public static string Secuencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Secuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Enfoque_del_Ejercicio</summary>
        public static string Enfoque_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Enfoque_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ejercicio</summary>
        public static string Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_series</summary>
        public static string Cantidad_de_series
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Cantidad_de_series", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_repeticiones</summary>
        public static string Cantidad_de_repeticiones
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Cantidad_de_repeticiones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descanso_en_segundos</summary>
        public static string Descanso_en_segundos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Descanso_en_segundos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
