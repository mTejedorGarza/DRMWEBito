using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Laboratorios_ClinicosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Laboratorios_Clinicos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Laboratorios_ClinicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Laboratorios_Clinicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Laboratorios_ClinicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Laboratorios_Clinicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Laboratorios_ClinicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Laboratorios_Clinicos</summary>
        public static string Detalle_Laboratorios_Clinicos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Detalle_Laboratorios_Clinicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Empleado_Titular</summary>
        public static string Numero_de_Empleado_Titular
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Numero_de_Empleado_Titular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Familiar_del_Empleado</summary>
        public static string Familiar_del_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Familiar_del_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Empleado_Beneficiario</summary>
        public static string Numero_de_Empleado_Beneficiario
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Numero_de_Empleado_Beneficiario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indicador</summary>
        public static string Indicador
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultado</summary>
        public static string Resultado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Intervalo_de_referencia</summary>
        public static string Intervalo_de_referencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Intervalo_de_referencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Resultado</summary>
        public static string Fecha_de_Resultado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Fecha_de_Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_Indicador</summary>
        public static string Estatus_Indicador
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("Estatus_Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Laboratorios_Clinicos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
