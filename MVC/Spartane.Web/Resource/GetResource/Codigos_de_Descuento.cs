using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Codigos_de_DescuentoResources
    {
        //private static IResourceProvider resourceProviderCodigos_de_Descuento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Codigos_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderCodigos_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Codigos_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderCodigos_de_Descuento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Codigos_de_DescuentoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Codigos_de_Descuento</summary>
        public static string Codigos_de_Descuento
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Codigos_de_Descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Vendedor</summary>
        public static string Tipo_de_Vendedor
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Tipo_de_Vendedor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Vendedor</summary>
        public static string Vendedor
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Vendedor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Descuento</summary>
        public static string Tipo_de_Descuento
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Tipo_de_Descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descuento</summary>
        public static string Descuento
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Productos</summary>
        public static string Productos
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Productos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_promocional</summary>
        public static string Texto_promocional
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Texto_promocional", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_vigencia</summary>
        public static string Fecha_inicio_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Fecha_inicio_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_vigencia</summary>
        public static string Fecha_fin_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Fecha_fin_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_maxima_de_referenciados</summary>
        public static string Cantidad_maxima_de_referenciados
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Cantidad_maxima_de_referenciados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigo_de_descuento</summary>
        public static string Codigo_de_descuento
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Codigo_de_descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_autorizacion</summary>
        public static string Fecha_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Fecha_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_autorizacion</summary>
        public static string Hora_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Hora_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_autoriza</summary>
        public static string Usuario_que_autoriza
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Usuario_que_autoriza", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Observaciones</summary>
        public static string Observaciones
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Observaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultado</summary>
        public static string Resultado
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Referenciados</summary>
        public static string Referenciados
        {
            get
            {
                SetPath();
                return resourceProviderCodigos_de_Descuento.GetResource("Referenciados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderCodigos_de_Descuento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Autorización</summary>	public static string TabAutorizacion 	{		get		{			SetPath();  			return resourceProviderCodigos_de_Descuento.GetResource("TabAutorizacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Referenciados</summary>	public static string TabReferenciados 	{		get		{			SetPath();  			return resourceProviderCodigos_de_Descuento.GetResource("TabReferenciados", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
