using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
   public  class ArticuloBO
    {
        ArticuloDAO adao;
       
        public ArticuloBO()
        {
            adao = new ArticuloDAO();
        }
        public string IngrearArt(Articulo art)
        {
            if (!(art.Descrip == "" || art.Cod_Art == "" || art.Precio_Cost <= 0 || art.Porc_Util <= 0 || art.Precio_Venta <= 0))
            {
                if (art.Cod_Marca != null)
                {
                    if (art.Cod_Depart != null)
                    {
                        return adao.RegistrarArticulo(art) !=null ? "Registro con exito" : "No se pudo registrar";
                    }
                    return "Seleccione una categoria";
                }
                return "Selecciones una Marca";
            }
            return "Hay espacios requeridos vacios";
        }


        public string ModificarArt(Articulo art)
        {
            if (!(art.Descrip == "" || art.Porc_Util <= 0 ||  art.Precio_Cost <= 0 || art.Precio_Venta<= 0 ))

            {
                return adao.ModificarArticulo(art).Cod_Art != null ? "Registro con exito" : "Exito al Modificar";
            }
            else
            {
                return "Hay espacios requeridos vacios o erroneos";
            }
        }

        //public bool EliminarArt(int codArt)
        //{
        //    return adao.Eliminar_Articulo(codArt);
        //}

        public List<Articulo> GetDescArt(string descArt)
        {
            adao = new ArticuloDAO();
            return adao.GetArtiDesc(descArt);
        }

        public List<Articulo> GetArtCod(string codArt)
        {
            adao = new ArticuloDAO();
            return adao.GetArtCod(codArt);
        }
        public List<Articulo> GetArtCodComp(string codArt)
        {
            adao = new ArticuloDAO();
            return adao.GetArtCodCompra(codArt);
        }
        public List<Articulo> GetModifArtCompra(string codArt)
        {
            adao = new ArticuloDAO();
            return adao.GetArticuloModif(codArt);
        }


    }
}
