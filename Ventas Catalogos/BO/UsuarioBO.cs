using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
    public class UsuarioBO
    {
        UsuarioDAO pdao;
        
        public UsuarioBO()
        {
            pdao = new UsuarioDAO();
        }
        public Usuario Loguear(Usuario u)
        {
            return pdao.Autentificar(u);
        }
    }
}
