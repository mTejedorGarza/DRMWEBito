using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Laboratorios_Clinicos;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Laboratorios_ClinicosPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Laboratorios_Clinicos.Folio";
                case "Numero_de_Empleado_Titular":
                    return "Detalle_Laboratorios_Clinicos.Numero_de_Empleado_Titular";
                case "Nombre_Completo":
                    return "Detalle_Laboratorios_Clinicos.Nombre_Completo";
                case "Familiar_del_Empleado":
                    return "Detalle_Laboratorios_Clinicos.Familiar_del_Empleado";
                case "Numero_de_Empleado_Beneficiario":
                    return "Detalle_Laboratorios_Clinicos.Numero_de_Empleado_Beneficiario";
                case "Indicador[Indicador]":
                case "IndicadorIndicador":
                    return "Indicadores_Laboratorio.Indicador";
                case "Resultado":
                    return "Detalle_Laboratorios_Clinicos.Resultado";
                case "Unidad":
                    return "Detalle_Laboratorios_Clinicos.Unidad";
                case "Intervalo_de_referencia":
                    return "Detalle_Laboratorios_Clinicos.Intervalo_de_referencia";
                case "Fecha_de_Resultado":
                    return "Detalle_Laboratorios_Clinicos.Fecha_de_Resultado";
                case "Estatus_Indicador":
                    return "Detalle_Laboratorios_Clinicos.Estatus_Indicador";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Laboratorios_Clinicos).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Familiar_del_Empleado")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_de_Resultado")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
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

