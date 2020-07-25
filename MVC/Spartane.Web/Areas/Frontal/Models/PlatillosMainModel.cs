using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class PlatillosMainModel
    {
        public PlatillosModel PlatillosInfo { set; get; }
        public MS_CaloriasGridModelPost MS_CaloriasGridInfo { set; get; }
        public MS_Dificultad_PlatillosGridModelPost MS_Dificultad_PlatillosGridInfo { set; get; }
        public MS_PadecimientosGridModelPost MS_PadecimientosGridInfo { set; get; }
        public MS_Tiempos_de_Comida_PlatillosGridModelPost MS_Tiempos_de_Comida_PlatillosGridInfo { set; get; }
        public MS_Caracteristicas_PlatilloGridModelPost MS_Caracteristicas_PlatilloGridInfo { set; get; }
        public MR_Detalle_PlatilloGridModelPost MR_Detalle_PlatilloGridInfo { set; get; }

    }

    public class MS_CaloriasGridModelPost
    {
        public int Folio { get; set; }
        public int? Calorias { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Dificultad_PlatillosGridModelPost
    {
        public int Folio { get; set; }
        public int? Dificultad { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_PadecimientosGridModelPost
    {
        public int Folio { get; set; }
        public int? Categoria { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Tiempos_de_Comida_PlatillosGridModelPost
    {
        public int Folio { get; set; }
        public int? Tiempo_de_Comida { get; set; }

        public bool Removed { set; get; }
    }

    public class MS_Caracteristicas_PlatilloGridModelPost
    {
        public int Folio { get; set; }
        public int? Caracteristicas { get; set; }

        public bool Removed { set; get; }
    }

    public class MR_Detalle_PlatilloGridModelPost
    {
        public int Folio { get; set; }
        public int? Ingrediente { get; set; }
        public string Cantidad { get; set; }
        public decimal? Cantidad_en_Fraccion { get; set; }
        public int? Unidad { get; set; }
        public string Cantidad_a_mostrar { get; set; }
        public string Ingrediente_a_mostrar { get; set; }

        public bool Removed { set; get; }
    }



}

