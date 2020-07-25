using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Secuencia_de_Ejercicios;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Secuencia_de_EjerciciosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Secuencia_de_Ejercicios.Folio";
                case "Orden_del_Ejercicio[Descripcion]":
                case "Orden_del_EjercicioDescripcion":
                    return "Secuencia_de_Ejercicios_en_Rutinas.Descripcion";
                case "Tipo_de_Ejercicio[Nombre_para_Secuencia]":
                case "Tipo_de_EjercicioNombre_para_Secuencia":
                    return "Tipo_de_Ejercicio_Rutina.Nombre_para_Secuencia";
                case "Enfoque[Descripcion]":
                case "EnfoqueDescripcion":
                    return "Tipo_de_Enfoque_del_Ejercicio.Descripcion";
                case "Secuencia_del_Ejercicio":
                    return "Detalle_Secuencia_de_Ejercicios.Secuencia_del_Ejercicio";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Secuencia_de_Ejercicios).GetProperty(columnName));
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

