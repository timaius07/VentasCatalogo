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
    public class ProvedorBO
    {
        ProvedorDAO pdao;
        string exp = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        public ProvedorBO()
        {
            pdao = new ProvedorDAO();
        }
        public string Validar(Provedor pt)
        {
            if (!(pt.RazonComercial == "" || pt.RazonSocial == "" || !Regex.IsMatch(pt.Email, exp) || pt.Cedula == "" || pt.Direccion == "" ||
                   pt.TelefonoCel == "" || pt.TelefonoCel == ""))
            {
                return pdao.RegitrarProvedor(pt).Id > 0 ? "Registro con exito" : "Se ingreso el nuevo Provedor";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }

        }

        public string ModificarProv(Provedor pt)
        {
            if (!(pt.RazonComercial == "" || pt.RazonSocial == "" || !Regex.IsMatch(pt.Email, exp) || pt.Cedula == "" ||
                pt.Direccion == "" || pt.TelefonoEmpresa == "" || pt.TelefonoCel == ""))

            {
                return pdao.ModificarProvedor(pt).Id > 0 ? "Registro con exito" : "Exito al Modificar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }

        }
        public bool EliminarProvedor(int idProv)
        {
            return pdao.Eliminar_Provedor(idProv);
        }
        public List<Provedor> GetProvedor(string nombprov)
        {
            pdao = new ProvedorDAO();
            return pdao.GetProvedor(nombprov);
        }
        public List<Provedor> GetProvedorID()
        {
            pdao = new ProvedorDAO();
            return pdao.GetProvedorIDNomb();
        }

    }
}
