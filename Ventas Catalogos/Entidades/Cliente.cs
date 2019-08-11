using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Email{ get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoCel { get; set; }
        public bool EstadoCliente { get; set; }

    }
}
