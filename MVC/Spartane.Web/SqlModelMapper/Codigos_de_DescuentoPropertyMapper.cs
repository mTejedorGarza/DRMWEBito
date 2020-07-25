using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Codigos_de_Descuento;

namespace Spartane.Web.SqlModelMapper
{
    public class Codigos_de_DescuentoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Codigos_de_Descuento.Folio";
                case "Fecha_de_Registro":
                    return "Codigos_de_Descuento.Fecha_de_Registro";
                case "Hora_de_Registro":
                    return "Codigos_de_Descuento.Hora_de_Registro";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Tipo_de_Vendedor[Descripcion]":
                case "Tipo_de_VendedorDescripcion":
                    return "Tipos_de_Vendedor.Descripcion";
                case "Vendedor[Name]":
                case "VendedorName":
                    return "Spartan_User.Name";
                case "Tipo_de_Descuento[Nombre]":
                case "Tipo_de_DescuentoNombre":
                    return "Tipos_de_Descuento.Nombre";
                case "Descuento":
                    return "Codigos_de_Descuento.Descuento";
                case "Texto_promocional":
                    return "Codigos_de_Descuento.Texto_promocional";
                case "Fecha_inicio_vigencia":
                    return "Codigos_de_Descuento.Fecha_inicio_vigencia";
                case "Fecha_fin_vigencia":
                    return "Codigos_de_Descuento.Fecha_fin_vigencia";
                case "Cantidad_maxima_de_referenciados":
                    return "Codigos_de_Descuento.Cantidad_maxima_de_referenciados";
                case "Codigo_de_descuento":
                    return "Codigos_de_Descuento.Codigo_de_descuento";
                case "Estatus[Nombre]":
                case "EstatusNombre":
                    return "Estatus_de_Codigos_de_Descuento.Nombre";
                case "Fecha_de_autorizacion":
                    return "Codigos_de_Descuento.Fecha_de_autorizacion";
                case "Hora_de_autorizacion":
                    return "Codigos_de_Descuento.Hora_de_autorizacion";
                case "Usuario_que_autoriza[Name]":
                case "Usuario_que_autorizaName":
                    return "Spartan_User.Name";
                case "Observaciones":
                    return "Codigos_de_Descuento.Observaciones";
                case "Resultado[Nombre]":
                case "ResultadoNombre":
                    return "Resultado_de_Autorizacion.Nombre";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Codigos_de_Descuento).GetProperty(columnName));
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
            if (columnName == "Fecha_inicio_vigencia")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }
            if (columnName == "Fecha_fin_vigencia")
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

