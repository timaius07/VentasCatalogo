using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas_Catalogos.DAO;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.BO
{
   public  class CategoriaBO
    {
        CategoriaDAO cdao;
       
        public CategoriaBO()
        {
            cdao = new CategoriaDAO();
        }

        public string IngresarCategoria(Categoria mc)
        {
            try
            {
                return cdao.RegistrarCliente(mc).Id > 0 ? "Registro con exito" : "Se ingreso el nuevo Cliente";
            }
            catch (Exception)
            {
               // MessageBox.Show("No se puede Registrar una Marca ya exsitente", "Ingresar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        public bool EliminaCategoria(int idCat)
        {
            return cdao.Eliminar_Categoria(idCat);
        }
        public List<Categoria> GetCateg()
        {
            cdao = new CategoriaDAO();
            return cdao.GetCategoria();
        }
    }
}
