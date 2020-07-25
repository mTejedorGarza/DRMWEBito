using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Ingredientes;

namespace Spartane.Web.SqlModelMapper
{
    public class IngredientesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Ingredientes.Clave";
                case "Es_un_ingrediente_de_SMAE":
                    return "Ingredientes.Es_un_ingrediente_de_SMAE";
                case "Clasificacion[Descripcion]":
                case "ClasificacionDescripcion":
                    return "Clasificacion_Ingredientes.Descripcion";
                case "Subgrupo[Nombre]":
                case "SubgrupoNombre":
                    return "Subgrupos_Ingredientes.Nombre";
                case "Nombre_Ingrediente":
                    return "Ingredientes.Nombre_Ingrediente";
                case "Ingrediente":
                    return "Ingredientes.Ingrediente";
                case "Cantidad_sugerida":
                    return "Ingredientes.Cantidad_sugerida";
                case "Cantidad_Sugerida_Decimal":
                    return "Ingredientes.Cantidad_Sugerida_Decimal";
                case "Unidad[Unidad]":
                case "UnidadUnidad":
                    return "Unidades_de_Medida.Unidad";
                case "Peso_bruto_redondeado_g":
                    return "Ingredientes.Peso_bruto_redondeado_g";
                case "Peso_neto_g":
                    return "Ingredientes.Peso_neto_g";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Ingredientes.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Ingredientes).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Es_un_ingrediente_de_SMAE")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }


            var operatorCondition = GetOperationType(columnName);
            columnName = GetPropertyName(columnName);

            switch (operatorCondition)
            {
                case SqlOperationType.Contains:
                    return string.IsNullOrEmpty(Convert.ToString(value)) ? "" : columnName + " LIKE '%" + value + "%'";
                case SqlOperationType.Equals:
                    return Convert.ToString(value) == "0" || Convert.ToString(value) == "" ? "" : columnName + "='" + value + "'";

            }
            return null;
        }
    }
}

