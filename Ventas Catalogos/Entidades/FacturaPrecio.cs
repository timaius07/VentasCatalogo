using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
    public class FacturaPrecio
    {
        public int Id_FacArt { get; set; }
        public string Num_Fact { get; set; }
        public string Cod_Arti { get; set; }
        public string Descripcion { get; set; }
        public decimal  Costo { get; set; }
        public decimal Utilidad { get; set; }
        public decimal PrecioPub { get; set; }
        public bool   AplicDesc { get; set; }
        public int RelFactPrecio { get; set; }
    }
}
