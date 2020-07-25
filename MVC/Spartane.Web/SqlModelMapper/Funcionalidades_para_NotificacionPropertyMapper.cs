using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Funcionalidades_para_Notificacion;

namespace Spartane.Web.SqlModelMapper
{
    public class Funcionalidades_para_NotificacionPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Funcionalidades_para_Notificacion.Folio";
                case "Funcionalidad":
                    return "Funcionalidades_para_Notificacion.Funcionalidad";
                case "Nombre_de_la_Tabla":
                    return "Funcionalidades_para_Notificacion.Nombre_de_la_Tabla";
                case "Campos_de_Estatus[Campo_para_Estatus]":
                case "Campos_de_EstatusCampo_para_Estatus":
                    return "Estatus_de_Funcionalidad_para_Notificacion.Campo_para_Estatus";
                case "Validacion_Obligatoria":
                    return "Funcionalidades_para_Notificacion.Validacion_Obligatoria";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Funcionalidades_para_Notificacion).GetProperty(columnName));
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

