﻿using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class IngredientesResources
    {
        //private static IResourceProvider resourceProviderIngredientes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderIngredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderIngredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Ingredientes</summary>
        public static string Ingredientes
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Ingredientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Es_un_ingrediente_de_SMAE</summary>
        public static string Es_un_ingrediente_de_SMAE
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Es_un_ingrediente_de_SMAE", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clasificacion</summary>
        public static string Clasificacion
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Clasificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Subgrupo</summary>
        public static string Subgrupo
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Subgrupo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Ingrediente</summary>
        public static string Nombre_Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Nombre_Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ingrediente</summary>
        public static string Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Imagen</summary>
        public static string Imagen
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Imagen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_sugerida</summary>
        public static string Cantidad_sugerida
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Cantidad_sugerida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_Sugerida_Decimal</summary>
        public static string Cantidad_Sugerida_Decimal
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Cantidad_Sugerida_Decimal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_bruto_redondeado_g</summary>
        public static string Peso_bruto_redondeado_g
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Peso_bruto_redondeado_g", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peso_neto_g</summary>
        public static string Peso_neto_g
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Peso_neto_g", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderIngredientes.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderIngredientes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
