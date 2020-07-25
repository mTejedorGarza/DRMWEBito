using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Platillos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_PlatillosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Platillos.Folio";
                case "Cantidad":
                    return "Detalle_Platillos.Cantidad";
                case "Unidad":
                    return "Detalle_Platillos.Unidad";
                case "Ingrediente[Nombre_Ingrediente]":
                case "IngredienteNombre_Ingrediente":
                    return "Ingredientes.Nombre_Ingrediente";
                case "Unidad_SMAE":
                    return "Detalle_Platillos.Unidad_SMAE";
                case "Porciones":
                    return "Detalle_Platillos.Porciones";
                case "Texto_para_mostrar":
                    return "Detalle_Platillos.Texto_para_mostrar";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Platillos).GetProperty(columnName));
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

