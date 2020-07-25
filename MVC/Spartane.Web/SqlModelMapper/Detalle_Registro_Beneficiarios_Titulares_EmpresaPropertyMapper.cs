using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Titulares_Empresa;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_Registro_Beneficiarios_Titulares_EmpresaPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Folio":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Folio";
                case "Numero_de_Empleado_Titular":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Numero_de_Empleado_Titular";
                case "Usuario[Name]":
                case "UsuarioName":
                    return "Spartan_User.Name";
                case "Nombres":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Nombres";
                case "Apellido_Paterno":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Apellido_Paterno";
                case "Apellido_Materno":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Apellido_Materno";
                case "Nombre_Completo":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Nombre_Completo";
                case "Email":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Email";
                case "Activo":
                    return "Detalle_Registro_Beneficiarios_Titulares_Empresa.Activo";
                case "Suscripcion[Nombre_del_Plan]":
                case "SuscripcionNombre_del_Plan":
                    return "Planes_de_Suscripcion.Nombre_del_Plan";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_Registro_Beneficiarios_Titulares_Empresa).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Activo")
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

