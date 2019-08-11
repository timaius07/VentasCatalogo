using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
    public class FacturaProv
    {
        public int IDProvFact { get; set; }
        public string NumFactProv { get; set; }
        public int IdProvedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Formapago { get; set; }
        public string Observaciones { get; set; }
        public bool AplicaInv { get; set; }
        public bool Finalfact { get; set; }
        public decimal Montofact { get; set; }
        public string NombProv { get; set; }
    }
}
