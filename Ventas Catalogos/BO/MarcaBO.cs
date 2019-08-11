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
   public  class MarcaBO
    {
        MarcaDAO mdao;
       
        public MarcaBO()
        {
            mdao = new MarcaDAO();
        }

        public string IngresarMarca(Marca mc)
        {
            try
            {
                return mdao.RegistrarCliente(mc).Id > 0 ? "Registro con exito" : "Se ingreso el nuevo Cliente";
            }
            catch (Exception)
            {
               // MessageBox.Show("No se puede Registrar una Marca ya exsitente", "Ingresar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }
        public bool EliminarMarca(int idMar)
        {
            return mdao.Eliminar_Marca(idMar);
        }
        public List<Marca> GetMarcas()
        {
            mdao = new MarcaDAO();
            return mdao.GetMarca();
        }
    }
}
