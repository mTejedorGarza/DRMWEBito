using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_del_Paciente;

namespace Spartane.Web.SqlModelMapper
{
    public class Configuracion_del_PacientePropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Configuracion_del_Paciente.Folio";
                case "Fecha_de_Registro":
                    return "Configuracion_del_Paciente.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Configuracion_del_Paciente.Hora_de_Registro";
                case "Usuario_Registrado[Name]":
                case "Usuario_RegistradoName":
                    return "Spartan_User.Name";
                case "Rol":
                    return "Configuracion_del_Paciente.Rol";
                case "Token":
                    return "Configuracion_del_Paciente.Token";
                case "Android":
                    return "Configuracion_del_Paciente.Android";
                case "iOS":
                    return "Configuracion_del_Paciente.iOS";
                case "Permite_notificaciones_por_email":
                    return "Configuracion_del_Paciente.Permite_notificaciones_por_email";
                case "Permite_notificaciones_push":
                    return "Configuracion_del_Paciente.Permite_notificaciones_push";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Configuracion_del_Paciente).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha_de_Registro")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Android")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "iOS")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permite_notificaciones_por_email")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Permite_notificaciones_push")
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

