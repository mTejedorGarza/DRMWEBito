using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Rangos_Pediatria_por_Platillos;

namespace Spartane.Web.SqlModelMapper
{
    public class Rangos_Pediatria_por_PlatillosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Rangos_Pediatria_por_Platillos.Folio";
                case "Nombre_de_rango":
                    return "Rangos_Pediatria_por_Platillos.Nombre_de_rango";
                case "Edad_minima":
                    return "Rangos_Pediatria_por_Platillos.Edad_minima";
                case "Edad_maxima":
                    return "Rangos_Pediatria_por_Platillos.Edad_maxima";
                case "Tiene_padecimientos":
                    return "Rangos_Pediatria_por_Platillos.Tiene_padecimientos";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Rangos_Pediatria_por_Platillos).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Tiene_padecimientos")
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

