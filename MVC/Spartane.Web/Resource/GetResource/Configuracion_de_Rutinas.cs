using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Configuracion_de_RutinasResources
    {
        //private static IResourceProvider resourceProviderConfiguracion_de_Rutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Configuracion_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderConfiguracion_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderConfiguracion_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Configuracion_de_Rutinas</summary>
        public static string Configuracion_de_Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Configuracion_de_Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Rutina</summary>
        public static string Tipo_de_Rutina
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Tipo_de_Rutina", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nivel_de_Dificultad</summary>
        public static string Nivel_de_Dificultad
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Nivel_de_Dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_ejercicios</summary>
        public static string Cantidad_de_ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Cantidad_de_ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_series</summary>
        public static string Cantidad_de_series
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Cantidad_de_series", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_repeticiones</summary>
        public static string Cantidad_de_repeticiones
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Cantidad_de_repeticiones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descanso_segundos</summary>
        public static string Descanso_segundos
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Descanso_segundos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_Ejercicios</summary>
        public static string Texto_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Texto_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lleva_Calentamiento</summary>
        public static string Lleva_Calentamiento
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Lleva_Calentamiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lleva_Enfriamiento</summary>
        public static string Lleva_Enfriamiento
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Lleva_Enfriamiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Secuencia_de_Ejercicios</summary>
        public static string Secuencia_de_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Rutinas.GetResource("Secuencia_de_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderConfiguracion_de_Rutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
