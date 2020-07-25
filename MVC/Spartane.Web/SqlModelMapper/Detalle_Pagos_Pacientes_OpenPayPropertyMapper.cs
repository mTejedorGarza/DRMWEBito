using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Pagos_Pacientes_OpenPay;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Pagos_Pacientes_OpenPayPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Pagos_Pacientes_OpenPay.Folio";
                case "Usuario_que_Registra[Name]":
                case "Usuario_que_RegistraName":
                    return "Spartan_User.Name";
                case "Fecha_de_Pago":
                    return "Detalle_Pagos_Pacientes_OpenPay.Fecha_de_Pago";
                case "Hora_de_Pago":
                    return "Detalle_Pagos_Pacientes_OpenPay.Hora_de_Pago";
                case "TokenID":
                    return "Detalle_Pagos_Pacientes_OpenPay.TokenID";
                case "Importe":
                    return "Detalle_Pagos_Pacientes_OpenPay.Importe";
                case "Concepto":
                    return "Detalle_Pagos_Pacientes_OpenPay.Concepto";
                case "Forma_de_pago[Nombre]":
                case "Forma_de_pagoNombre":
                    return "Formas_de_Pago.Nombre";
                case "Autorizacion":
                    return "Detalle_Pagos_Pacientes_OpenPay.Autorizacion";
                case "Nombre":
                    return "Detalle_Pagos_Pacientes_OpenPay.Nombre";
                case "Apellidos":
                    return "Detalle_Pagos_Pacientes_OpenPay.Apellidos";
                case "Telefono":
                    return "Detalle_Pagos_Pacientes_OpenPay.Telefono";
                case "Email":
                    return "Detalle_Pagos_Pacientes_OpenPay.Email";
                case "DeviceID":
                    return "Detalle_Pagos_Pacientes_OpenPay.DeviceID";
                case "UsaPuntos":
                    return "Detalle_Pagos_Pacientes_OpenPay.UsaPuntos";
                case "PuntosID":
                    return "Detalle_Pagos_Pacientes_OpenPay.PuntosID";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Pago.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Pagos_Pacientes_OpenPay).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
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
            if (columnName == "UsaPuntos")
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

