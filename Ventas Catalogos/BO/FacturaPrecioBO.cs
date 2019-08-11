using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
    public class FacturaPrecioBO
    {
        FacturaPrecDAO fpdao;
        EspejoFacturaPrecDAO fepdao;

        public FacturaPrecioBO()
        {
            fpdao = new FacturaPrecDAO();
            fepdao = new EspejoFacturaPrecDAO();
        }

        public void IngresoEspejoFacPrecio (FacturaPrecio feart)
        {
            fepdao.RegistrarEspejoFacPrecio(feart);
        }
        public bool EliminarEspFactArt()
        {
            return fepdao.Eliminar_EspejoFactArticuloPrec();
        }

        public string IngresoFacPrecio(FacturaPrecio fart)
        {
            if (!(fart.Num_Fact == "" || fart.Cod_Arti == ""))
            {
                return fpdao.RegistrarFacPrecio(fart).Id_FacArt > 0 ? "Registro con exito" : "Se guardo la nueva Factura Articulos";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }
        public string ModificarFacPrec(FacturaPrecio fart)
        {
            if (!(fart.Num_Fact == "" || fart.Cod_Arti == null || fart.RelFactPrecio==0))
            {
                return fpdao.ModificarFacturaPrec(fart).Id_FacArt > 0 ? "Modificación de FacArticulos" : "Exito al Guardar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }

        public bool EliminarFactPrec(int numFact)
        {
            return fpdao.Eliminar_FactArticuloPrec(numFact);
        }

        public List<FacturaPrecio> GetNumFactPrec(string numfact)
        {
            return fpdao.GetFactArticuloPrec(numfact);
        }
        public List<FacturaPrecio> GetEspejoNumFactPrec(string numfact)
        {
            return fpdao.GetFactEspejoArticuloPrec(numfact);
        }

    }
}
