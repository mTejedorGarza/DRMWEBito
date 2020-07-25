using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PlatillosGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_RegistraName { get; set; }
        public string Nombre_de_Platillo { get; set; }
        public int? Imagen { get; set; }
        public Grid_File ImagenFileInfo { set; get; }
        public int? Tipo_de_comida { get; set; }
        public string Tipo_de_comidaTipo_de_comida { get; set; }
        public string Calificacion { get; set; }
        public string Modo_de_Preparacion { get; set; }
        
    }
}

