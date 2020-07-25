using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Pagos_Pacientes_OpenPayResources
    {
        //private static IResourceProvider resourceProviderDetalle_Pagos_Pacientes_OpenPay = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Pagos_Pacientes_OpenPayResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Pagos_Pacientes_OpenPay = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Pagos_Pacientes_OpenPayResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Pagos_Pacientes_OpenPay = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Pagos_Pacientes_OpenPayResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Pagos_Pacientes_OpenPay</summary>
        public static string Detalle_Pagos_Pacientes_OpenPay
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Detalle_Pagos_Pacientes_OpenPay", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Pago</summary>
        public static string Fecha_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Fecha_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Pago</summary>
        public static string Hora_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Hora_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>TokenID</summary>
        public static string TokenID
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("TokenID", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Importe</summary>
        public static string Importe
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Importe", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concepto</summary>
        public static string Concepto
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Concepto", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Forma_de_pago</summary>
        public static string Forma_de_pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Forma_de_pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Autorizacion</summary>
        public static string Autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellidos</summary>
        public static string Apellidos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Apellidos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>DeviceID</summary>
        public static string DeviceID
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("DeviceID", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>UsaPuntos</summary>
        public static string UsaPuntos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("UsaPuntos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PuntosID</summary>
        public static string PuntosID
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("PuntosID", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Pagos_Pacientes_OpenPay.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
