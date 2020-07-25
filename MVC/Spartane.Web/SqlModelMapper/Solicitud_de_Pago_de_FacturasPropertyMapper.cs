using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Solicitud_de_Pago_de_Facturas;

namespace Spartane.Web.SqlModelMapper
{
    public class Solicitud_de_Pago_de_FacturasPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Solicitud_de_Pago_de_Facturas.Folio";
                case "Fecha_de_Registro":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Solicitud_de_Pago_de_Facturas.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Mes_Facturado[Nombre]":
                case "Mes_FacturadoNombre":
                    return "Meses.Nombre";
                case "Fecha_inicio_del_periodo_facturado":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_inicio_del_periodo_facturado";
                case "Fecha_fin_del_periodo_facturado":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_fin_del_periodo_facturado";
                case "Total":
                    return "Solicitud_de_Pago_de_Facturas.Total";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_Facturas.Descripcion";
                case "Fecha_de_autorizacion":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_de_autorizacion";
                case "Hora_de_autorizacion":
                    return "Solicitud_de_Pago_de_Facturas.Hora_de_autorizacion";
                case "Usuario_que_autoriza[Name]":
                case "Usuario_que_autorizaName":
                    return "Spartan_User.Name";
                case "Resultado_de_la_Revision[Nombre]":
                case "Resultado_de_la_RevisionNombre":
                    return "Resultados_de_Revision.Nombre";
                case "Observaciones":
                    return "Solicitud_de_Pago_de_Facturas.Observaciones";
                case "Fecha_de_programacion":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_de_programacion";
                case "Hora_de_programacion":
                    return "Solicitud_de_Pago_de_Facturas.Hora_de_programacion";
                case "Usuario_que_programa[Name]":
                case "Usuario_que_programaName":
                    return "Spartan_User.Name";
                case "Fecha_programada_de_Pago":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_programada_de_Pago";
                case "Estatus_de_Pago[Nombre]":
                case "Estatus_de_PagoNombre":
                    return "Estatus_de_Pago_de_Facturas.Nombre";
                case "Fecha_de_actualizacion":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_de_actualizacion";
                case "Hora_de_actualizacion":
                    return "Solicitud_de_Pago_de_Facturas.Hora_de_actualizacion";
                case "Usuario_que_actualiza[Name]":
                case "Usuario_que_actualizaName":
                    return "Spartan_User.Name";
                case "Fecha_de_Pago":
                    return "Solicitud_de_Pago_de_Facturas.Fecha_de_Pago";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Solicitud_de_Pago_de_Facturas).GetProperty(columnName));
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
            if (columnName == "Fecha_inicio_del_periodo_facturado")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_del_periodo_facturado")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_autorizacion")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_programacion")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_programada_de_Pago")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_actualizacion")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_de_Pago")
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

