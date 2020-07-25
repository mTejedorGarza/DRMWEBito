using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.MR_Tarjetas;

namespace Spartane.Web.SqlModelMapper
{
    public class MR_TarjetasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "MR_Tarjetas.Folio";
                case "Tipo_de_Tarjeta[Descripcion]":
                case "Tipo_de_TarjetaDescripcion":
                    return "Tipo_de_Tarjeta.Descripcion";
                case "Numero_de_Tarjeta":
                    return "MR_Tarjetas.Numero_de_Tarjeta";
                case "Nombre_del_Titular":
                    return "MR_Tarjetas.Nombre_del_Titular";
                case "Ano_de_vigencia":
                    return "MR_Tarjetas.Ano_de_vigencia";
                case "Mes_de_vigencia":
                    return "MR_Tarjetas.Mes_de_vigencia";
                case "Alias_de_la_Tarjeta":
                    return "MR_Tarjetas.Alias_de_la_Tarjeta";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(MR_Tarjetas).GetProperty(columnName));
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

