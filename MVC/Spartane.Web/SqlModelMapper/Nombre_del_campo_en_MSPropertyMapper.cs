using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Nombre_del_campo_en_MS;

namespace Spartane.Web.SqlModelMapper
{
    public class Nombre_del_campo_en_MSPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Nombre_del_campo_en_MS.Clave";
                case "Descripcion":
                    return "Nombre_del_campo_en_MS.Descripcion";
                case "Nombre_Fisico_del_Campo":
                    return "Nombre_del_campo_en_MS.Nombre_Fisico_del_Campo";
                case "Nombre_Fisico_de_la_Tabla":
                    return "Nombre_del_campo_en_MS.Nombre_Fisico_de_la_Tabla";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Nombre_del_campo_en_MS).GetProperty(columnName));
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

