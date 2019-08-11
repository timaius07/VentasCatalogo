using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
    public class FacturaArtc
    {

      public int Id_FacArt { get; set; }
      public string  Num_Fact { get; set; } 
      public string  Cod_Arti { get; set; }
      public string   DescripArt { get; set; }
      public int Cantidad { get; set; }
      public decimal  PrecioU { get; set; }
      public decimal   Subtotal { get; set; }
      public decimal    PorcDesc { get; set; }
      public decimal   MontoDesc { get; set; }
      public decimal  SubtoDesc { get; set; }
      public decimal MontocIV { get; set; }
      public decimal  SubtoIV { get; set; }
      public decimal TotalFin { get; set; }
      public bool IV { get; set; }
      public int RelFactProve{ get; set; }
      

    }
}
