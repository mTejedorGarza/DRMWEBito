using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Configuracion_de_NotificacionesResources
    {
        //private static IResourceProvider resourceProviderConfiguracion_de_Notificaciones = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Configuracion_de_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderConfiguracion_de_Notificaciones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_de_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderConfiguracion_de_Notificaciones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Configuracion_de_NotificacionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Configuracion_de_Notificaciones</summary>
        public static string Configuracion_de_Notificaciones
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Configuracion_de_Notificaciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Notificacion</summary>
        public static string Nombre_de_la_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Nombre_de_la_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dirigido_a</summary>
        public static string Dirigido_a
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Dirigido_a", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Es_permanente</summary>
        public static string Es_permanente
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Es_permanente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Funcionalidad</summary>
        public static string Funcionalidad
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Funcionalidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Notificacion</summary>
        public static string Tipo_de_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Tipo_de_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Accion</summary>
        public static string Tipo_de_Accion
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Tipo_de_Accion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Recordatorio</summary>
        public static string Tipo_de_Recordatorio
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Tipo_de_Recordatorio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio</summary>
        public static string Fecha_inicio
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Fecha_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiene_fecha_de_finalizacion_definida</summary>
        public static string Tiene_fecha_de_finalizacion_definida
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Tiene_fecha_de_finalizacion_definida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_dias_a_validar</summary>
        public static string Cantidad_de_dias_a_validar
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Cantidad_de_dias_a_validar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_a_validar</summary>
        public static string Fecha_a_validar
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Fecha_a_validar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin</summary>
        public static string Fecha_fin
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Fecha_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Notificar_por_correo</summary>
        public static string Notificar_por_correo
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Notificar_por_correo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_que_llevara_el_correo</summary>
        public static string Texto_que_llevara_el_correo
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Texto_que_llevara_el_correo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Notificacion_push</summary>
        public static string Notificacion_push
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Notificacion_push", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_a_mostrar_en_la_notificacion_Push</summary>
        public static string Texto_a_mostrar_en_la_notificacion_Push
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Texto_a_mostrar_en_la_notificacion_Push", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_Notificacion</summary>
        public static string Frecuencia_Notificacion
        {
            get
            {
                SetPath();
                return resourceProviderConfiguracion_de_Notificaciones.GetResource("Frecuencia_Notificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderConfiguracion_de_Notificaciones.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
