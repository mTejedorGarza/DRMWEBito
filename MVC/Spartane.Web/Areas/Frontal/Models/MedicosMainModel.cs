using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class MedicosMainModel
    {
        public MedicosModel MedicosInfo { set; get; }
        public Detalle_Redes_Sociales_EspecialistaGridModelPost Detalle_Redes_Sociales_EspecialistaGridInfo { set; get; }
        public Detalle_Convenio_Medicos_AseguradorasGridModelPost Detalle_Convenio_Medicos_AseguradorasGridInfo { set; get; }
        public Detalle_Titulos_MedicosGridModelPost Detalle_Titulos_MedicosGridInfo { set; get; }
        public Detalle_Identificacion_Oficial_MedicosGridModelPost Detalle_Identificacion_Oficial_MedicosGridInfo { set; get; }
        public Detalle_Planes_de_Suscripcion_EspecialistasGridModelPost Detalle_Planes_de_Suscripcion_EspecialistasGridInfo { set; get; }

    }

    public class Detalle_Redes_Sociales_EspecialistaGridModelPost
    {
        public int Folio { get; set; }
        public int? Red_Social { get; set; }
        public string URL { get; set; }
        public bool? Principal { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Convenio_Medicos_AseguradorasGridModelPost
    {
        public int Folio { get; set; }
        public int? Aseguradora_medico { get; set; }

        public bool Removed { set; get; }
    }

    public class Detalle_Titulos_MedicosGridModelPost
    {
        public int Folio { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public string Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        public Grid_File TituloInfo { set; get; }
        public string Numero_de_Cedula { get; set; }
        public string Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        public Grid_File Cedula_FrenteInfo { set; get; }
        public int? Cedula_Reverso { get; set; }
        public Grid_File Cedula_ReversoInfo { set; get; }

        public bool Removed { set; get; }
    }

    public class Detalle_Identificacion_Oficial_MedicosGridModelPost
    {
        public int Folio { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public int? Documento { get; set; }
        public Grid_File DocumentoInfo { set; get; }

        public bool Removed { set; get; }
    }

    public class Detalle_Planes_de_Suscripcion_EspecialistasGridModelPost
    {
        public int Folio { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Fecha_de_inicio { get; set; }
        public string Fecha_fin { get; set; }
        public decimal? Costo { get; set; }
        public int? Contrato { get; set; }
        public Grid_File ContratoInfo { set; get; }
        public bool? Firmo_Contrato { get; set; }
        public int? Estatus { get; set; }

        public bool Removed { set; get; }
    }



}

