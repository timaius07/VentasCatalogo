using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
    public class FacturaProvBO
    {
        FacturaProvDAO fpdao;

        public FacturaProvBO()
        {
            fpdao = new FacturaProvDAO();
        }

        public int ValidarIngFactPrv(FacturaProv fp)
        {
            if (!(fp.NumFactProv == "" || fp.Fecha == null || fp.Formapago == "" || fp.IdProvedor <= 0 ||
                   fp.Montofact < 0 ))
            {
                return fpdao.RegitrarFactProvedor(fp) ;
            }
            else
            {
                return 0;
            }
        }

        public string ModificarProv(FacturaProv fpv)
        {
            if (!(fpv.NumFactProv == "" || fpv.Fecha == null || fpv.Formapago == "" || fpv.IDProvFact == 0 ||
                   fpv.Montofact <= 0))
            {
                return fpdao.ModificarFacturaPrv(fpv).IdProvedor > 0 ? "Modificación" : "Exito al Guardar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }

        public bool EliminarFactProv(string factProv)
        {
            return fpdao.Eliminar_FactProvedor(factProv);
        }

        public List<FacturaProv> GetNumFactProv()
        {
            fpdao = new FacturaProvDAO();
            return fpdao.GetFactNumProvedor();
        }
        public List<FacturaProv> GetNumFactProvBusc(string numfact, int idprov, DateTime fecha)
        {
            fpdao = new FacturaProvDAO();
            return fpdao.GetFactProvedorBusc(numfact, idprov,  fecha);
        }
        public List<FacturaProv> GetNumFactProvBuscProv(int idprov)
        {
            fpdao = new FacturaProvDAO();
            return fpdao.GetFactProvedorBuscProv(idprov);
        }
        public List<FacturaProv> GetNumFactProvBuscFec(DateTime fech)
        {
            fpdao = new FacturaProvDAO();
            return fpdao.GetFactProvedorBuscProvFecha(fech);
        }
        public List<FacturaProv> GetNumFactProvBuscNumF(string  numfac)
        {
            fpdao = new FacturaProvDAO();
            return fpdao.GetFactProvedorBuscProvNumFact(numfac);
        }

    }
}
