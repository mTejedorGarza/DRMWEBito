using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Telefonos_de_AsistenciaResources
    {
        //private static IResourceProvider resourceProviderTelefonos_de_Asistencia = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Telefonos_de_AsistenciaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTelefonos_de_Asistencia = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Telefonos_de_AsistenciaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTelefonos_de_Asistencia = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Telefonos_de_AsistenciaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Telefonos_de_Asistencia</summary>
        public static string Telefonos_de_Asistencia
        {
            get
            {
                SetPath();
                return resourceProviderTelefonos_de_Asistencia.GetResource("Telefonos_de_Asistencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderTelefonos_de_Asistencia.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderTelefonos_de_Asistencia.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Departamento</summary>
        public static string Departamento
        {
            get
            {
                SetPath();
                return resourceProviderTelefonos_de_Asistencia.GetResource("Departamento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTelefonos_de_Asistencia.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
