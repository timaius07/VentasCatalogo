using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
   public  class Provedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RazonComercial { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string TelefonoCel { get; set; }
        public int DiasCredito { get; set; }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
