using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Configuracion_de_Notificaciones;

namespace Spartane.Web.SqlModelMapper
{
    public class Configuracion_de_NotificacionesPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Configuracion_de_Notificaciones.Folio";
                case "Fecha_de_Registro":
                    return "Configuracion_de_Notificaciones.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Configuracion_de_Notificaciones.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Nombre_de_la_Notificacion":
                    return "Configuracion_de_Notificaciones.Nombre_de_la_Notificacion";
                case "Es_permanente":
                    return "Configuracion_de_Notificaciones.Es_permanente";
                case "Funcionalidad[Funcionalidad]":
                case "FuncionalidadFuncionalidad":
                    return "Funcionalidades_para_Notificacion.Funcionalidad";
                case "Tipo_de_Notificacion[Descripcion]":
                case "Tipo_de_NotificacionDescripcion":
                    return "Tipo_de_Notificacion.Descripcion";
                case "Tipo_de_Accion[Descripcion]":
                case "Tipo_de_AccionDescripcion":
                    return "Tipo_de_Accion_Notificacion.Descripcion";
                case "Tipo_de_Recordatorio[Descripcion]":
                case "Tipo_de_RecordatorioDescripcion":
                    return "Tipo_de_Recordatorio_Notificacion.Descripcion";
                case "Fecha_inicio":
                    return "Configuracion_de_Notificaciones.Fecha_inicio";
                case "Tiene_fecha_de_finalizacion_definida":
                    return "Configuracion_de_Notificaciones.Tiene_fecha_de_finalizacion_definida";
                case "Cantidad_de_dias_a_validar":
                    return "Configuracion_de_Notificaciones.Cantidad_de_dias_a_validar";
                case "Fecha_a_validar[Descripcion]":
                case "Fecha_a_validarDescripcion":
                    return "Nombre_del_campo_en_MS.Descripcion";
                case "Fecha_fin":
                    return "Configuracion_de_Notificaciones.Fecha_fin";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";
                case "Notificar_por_correo":
                    return "Configuracion_de_Notificaciones.Notificar_por_correo";
                case "Texto_que_llevara_el_correo":
                    return "Configuracion_de_Notificaciones.Texto_que_llevara_el_correo";
                case "Notificacion_push":
                    return "Configuracion_de_Notificaciones.Notificacion_push";
                case "Texto_a_mostrar_en_la_notificacion_Push":
                    return "Configuracion_de_Notificaciones.Texto_a_mostrar_en_la_notificacion_Push";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Configuracion_de_Notificaciones).GetProperty(columnName));
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
            if (columnName == "Es_permanente")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_inicio")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Tiene_fecha_de_finalizacion_definida")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Fecha_fin")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Notificar_por_correo")
            {
                value = Convert.ToString(value) != string.Empty?(Convert.ToString(value) == "true"  ? 1 :0 ): value;
            }
            if (columnName == "Notificacion_push")
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

