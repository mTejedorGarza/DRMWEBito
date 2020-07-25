using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Frecuencia_Notificaciones;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Frecuencia_NotificacionesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Frecuencia_Notificaciones.Folio";
                case "Frecuencia[Descripcion]":
                case "FrecuenciaDescripcion":
                    return "Tipo_Frecuencia_Notificacion.Descripcion";
                case "Dia[Descripcion]":
                case "DiaDescripcion":
                    return "Tipo_Dia_Notificacion.Descripcion";
                case "Hora":
                    return "Detalle_Frecuencia_Notificaciones.Hora";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Frecuencia_Notificaciones).GetProperty(columnName));
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

