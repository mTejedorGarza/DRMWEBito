using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_de_Rutinas;

namespace Spartane.Web.SqlModelMapper
{
    public class Configuracion_de_RutinasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Configuracion_de_Rutinas.Folio";
                case "Fecha_de_Registro":
                    return "Configuracion_de_Rutinas.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Configuracion_de_Rutinas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Tipo_de_Rutina[Tipo_de_Rutina]":
                case "Tipo_de_RutinaTipo_de_Rutina":
                    return "Tipo_de_Ejercicio_Rutina.Tipo_de_Rutina";
                case "Nivel_de_Dificultad[Dificultad]":
                case "Nivel_de_DificultadDificultad":
                    return "Nivel_de_dificultad.Dificultad";
                case "Sexo[Descripcion]":
                case "SexoDescripcion":
                    return "Sexo.Descripcion";
                case "Cantidad_de_ejercicios":
                    return "Configuracion_de_Rutinas.Cantidad_de_ejercicios";
                case "Cantidad_de_series":
                    return "Configuracion_de_Rutinas.Cantidad_de_series";
                case "Cantidad_de_repeticiones":
                    return "Configuracion_de_Rutinas.Cantidad_de_repeticiones";
                case "Descanso_segundos":
                    return "Configuracion_de_Rutinas.Descanso_segundos";
                case "Texto_Ejercicios":
                    return "Configuracion_de_Rutinas.Texto_Ejercicios";
                case "Lleva_Calentamiento":
                    return "Configuracion_de_Rutinas.Lleva_Calentamiento";
                case "Lleva_Enfriamiento":
                    return "Configuracion_de_Rutinas.Lleva_Enfriamiento";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Configuracion_de_Rutinas).GetProperty(columnName));
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
            if (columnName == "Lleva_Calentamiento")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Lleva_Enfriamiento")
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

