using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
    public class Articulo
    {
        public string  Cod_Art { get; set; }
        public string Descrip { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public int Cantidad_Invt { get; set; }
        public decimal Precio_Cost { get; set; }
        public decimal Porc_Util { get; set; }
        public decimal Precio_Venta { get; set; }     
        public Marca Cod_Marca { get; set; }
        public Categoria Cod_Depart { get; set; }
        public bool Impuesto { get; set; }
        public bool AplicaDesc { get; set; }
    }
}
