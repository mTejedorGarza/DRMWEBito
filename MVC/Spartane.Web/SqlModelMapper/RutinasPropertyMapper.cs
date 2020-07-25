using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Rutinas;

namespace Spartane.Web.SqlModelMapper
{
    public class RutinasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Rutinas.Folio";
                case "Fecha_de_Registro":
                    return "Rutinas.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Rutinas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Tipo_de_Rutina[Tipo_de_Rutina]":
                case "Tipo_de_RutinaTipo_de_Rutina":
                    return "Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina";
                case "Nivel_de_dificultad[Dificultad]":
                case "Nivel_de_dificultadDificultad":
                    return "Nivel_de_dificultad.Dificultad";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Nombre_de_la_Rutina":
                    return "Rutinas.Nombre_de_la_Rutina";
                case "Descripcion":
                    return "Rutinas.Descripcion";
                case "Equipamiento":
                    return "Rutinas.Equipamiento";
                case "Equipamiento_alterno":
                    return "Rutinas.Equipamiento_alterno";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Rutinas).GetProperty(columnName));
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

