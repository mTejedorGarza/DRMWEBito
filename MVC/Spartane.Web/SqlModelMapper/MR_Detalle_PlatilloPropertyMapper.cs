using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.MR_Detalle_Platillo;

namespace Spartane.Web.SqlModelMapper
{
    public class MR_Detalle_PlatilloPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "MR_Detalle_Platillo.Folio";
                case "Ingrediente[Nombre_Ingrediente]":
                case "IngredienteNombre_Ingrediente":
                    return "Ingredientes.Nombre_Ingrediente";
                case "Cantidad":
                    return "MR_Detalle_Platillo.Cantidad";
                case "Cantidad_en_Fraccion":
                    return "MR_Detalle_Platillo.Cantidad_en_Fraccion";
                case "Unidad[Unidad]":
                case "UnidadUnidad":
                    return "Unidades_de_Medida.Unidad";
                case "Cantidad_a_mostrar":
                    return "MR_Detalle_Platillo.Cantidad_a_mostrar";
                case "Ingrediente_a_mostrar":
                    return "MR_Detalle_Platillo.Ingrediente_a_mostrar";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(MR_Detalle_Platillo).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {


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

