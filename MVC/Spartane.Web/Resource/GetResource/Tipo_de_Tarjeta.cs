﻿using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Tipo_de_TarjetaResources
    {
        //private static IResourceProvider resourceProviderTipo_de_Tarjeta = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Tipo_de_TarjetaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTipo_de_Tarjeta = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tipo_de_TarjetaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTipo_de_Tarjeta = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tipo_de_TarjetaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Tipo_de_Tarjeta</summary>
        public static string Tipo_de_Tarjeta
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Tarjeta.GetResource("Tipo_de_Tarjeta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Tarjeta.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderTipo_de_Tarjeta.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>

    }
}