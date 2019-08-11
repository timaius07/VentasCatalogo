using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
    public class FacturaArticBO
    {
        FacturaArtDAO fadao;
        EspejoFacturaArtDAO feadao;

        public FacturaArticBO()
        {
            fadao = new FacturaArtDAO();
            feadao = new EspejoFacturaArtDAO();
        }
        public void IngresarEspejo (FacturaArtc feart)
        {
           feadao.RegitrarEspejoFactArticulo(feart);
        }
        public bool EliminarEspejoFactArt()
        {
            return feadao.Eliminar_EspejoFactArticulo();
        }

        public string ValidarIngFacArt(FacturaArtc fart)
        {
            if (!(fart.Num_Fact == "" ||fart.Cod_Arti == ""))
            {
                return fadao.RegitrarFactArticulo(fart).Id_FacArt > 0 ? "Registro con exito" : "Se guardo la nueva Factura Articulos";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }
        public string ModificarFactArt(FacturaArtc fart)
        {
            if (!(fart.Num_Fact == "" || fart.Cod_Arti == null || fart.RelFactProve== 0))
            {
                return fadao.ModificarFactArticulo(fart).Id_FacArt > 0 ? "Modificación de FacArticulos" : "Exito al Guardar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }

        public bool EliminarFactArt(int numFact)
        {
            return fadao.Eliminar_FactArticulo(numFact);
        }

        public List<FacturaArtc> GetNumFactProv(string numfact)
        {          
            return fadao.GetFactArticulo(numfact);
        }
        public List<FacturaArtc> GetNumFactEspejoProv(string numfact)
        {
            return fadao.GetFactEspejoArticulo(numfact);
        }
    }
}
