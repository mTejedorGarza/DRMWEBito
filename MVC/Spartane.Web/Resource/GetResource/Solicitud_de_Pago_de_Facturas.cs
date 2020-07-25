using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Solicitud_de_Pago_de_FacturasResources
    {
        //private static IResourceProvider resourceProviderSolicitud_de_Pago_de_Facturas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Solicitud_de_Pago_de_FacturasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSolicitud_de_Pago_de_Facturas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Solicitud_de_Pago_de_FacturasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSolicitud_de_Pago_de_Facturas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Solicitud_de_Pago_de_FacturasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Solicitud_de_Pago_de_Facturas</summary>
        public static string Solicitud_de_Pago_de_Facturas
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Solicitud_de_Pago_de_Facturas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Mes_Facturado</summary>
        public static string Mes_Facturado
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Mes_Facturado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_del_periodo_facturado</summary>
        public static string Fecha_inicio_del_periodo_facturado
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_inicio_del_periodo_facturado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_del_periodo_facturado</summary>
        public static string Fecha_fin_del_periodo_facturado
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_fin_del_periodo_facturado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Archivo_XML</summary>
        public static string Archivo_XML
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Archivo_XML", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Archivo_PDF</summary>
        public static string Archivo_PDF
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Archivo_PDF", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Recibo_de_Solicitud_de_Pago</summary>
        public static string Recibo_de_Solicitud_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Recibo_de_Solicitud_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Total</summary>
        public static string Total
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Total", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_autorizacion</summary>
        public static string Fecha_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_autorizacion</summary>
        public static string Hora_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Hora_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_autoriza</summary>
        public static string Usuario_que_autoriza
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Usuario_que_autoriza", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultado_de_la_Revision</summary>
        public static string Resultado_de_la_Revision
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Resultado_de_la_Revision", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Observaciones</summary>
        public static string Observaciones
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Observaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_programacion</summary>
        public static string Fecha_de_programacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_de_programacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_programacion</summary>
        public static string Hora_de_programacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Hora_de_programacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_programa</summary>
        public static string Usuario_que_programa
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Usuario_que_programa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_programada_de_Pago</summary>
        public static string Fecha_programada_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_programada_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_de_Pago</summary>
        public static string Estatus_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Estatus_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_actualizacion</summary>
        public static string Fecha_de_actualizacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_de_actualizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_actualizacion</summary>
        public static string Hora_de_actualizacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Hora_de_actualizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_actualiza</summary>
        public static string Usuario_que_actualiza
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Usuario_que_actualiza", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Pago</summary>
        public static string Fecha_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("Fecha_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Autorización</summary>	public static string TabAutorizacion 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("TabAutorizacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Programación de Pago</summary>	public static string TabProgramacion_de_Pago 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("TabProgramacion_de_Pago", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Pago</summary>	public static string TabPago 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Pago_de_Facturas.GetResource("TabPago", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
