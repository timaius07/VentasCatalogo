using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
    public class ClienteBO
    {
        ClienteDAO cdao;
        string exp = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        public ClienteBO()
        {
            cdao = new ClienteDAO();
        }
        public string Validar(Cliente pt)
        {
            if (!(pt.Nombre == "" || pt.Apellido == "" || !Regex.IsMatch(pt.Email, exp) || pt.Cedula == "" || pt.Direccion == "" ||
                   pt.TelefonoCasa=="" || pt.TelefonoCel ==""))
            
                    {
                        return cdao.RegistrarCliente(pt).Id > 0 ? "Registro con exito" : "Se ingreso el nuevo Cliente";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
          
        }

        public string ModificarCli(Cliente pt)
        {
            if (!(pt.Nombre == "" || pt.Apellido == "" || !Regex.IsMatch(pt.Email, exp) || pt.Cedula == "" || pt.Direccion == "" ||
                   pt.TelefonoCasa == "" || pt.TelefonoCel == ""))

            {
                return cdao.ModificarCliente(pt).Id > 0 ? "Registro con exito" : "Exito al Modificar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }

        }

        public bool EliminarCliente(int idCli)
        {
            return cdao.Eliminar_Cliente(idCli);
        }


        public List<Cliente> GetCliente(string nombcli)
        {
            cdao = new ClienteDAO();
            return cdao.GetCliente(nombcli);
        }

        public List<Cliente> GetClienteCed(string cedu)
        {
            cdao = new ClienteDAO();
            return cdao.GetClienteCed(cedu);
        }
    }
}
