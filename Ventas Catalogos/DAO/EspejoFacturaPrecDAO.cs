using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventas_Catalogos.Entidades;

namespace Ventas_Catalogos.DAO
{
  public class EspejoFacturaPrecDAO
    {
        public FacturaPrecio RegistrarEspejoFacPrecio(FacturaPrecio fpr)
        {

            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"INSERT INTO espejoprecprove(
             num_factartp, cod_arti, descripart, costo, utilidad, 
            preciopu, aplicadesc, rel_factprecio)
            VALUES ( :numfac , :codart , :desc , :precicos , :util , :preciopu, 
            :aplidesc, :relafacprec);";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("numfac", fpr.Num_Fact);
                    cmd.Parameters.AddWithValue("codart", fpr.Cod_Arti);
                    cmd.Parameters.AddWithValue("desc", fpr.Descripcion);
                    cmd.Parameters.AddWithValue("precicos", fpr.Costo);
                    cmd.Parameters.AddWithValue("util", fpr.Utilidad);
                    cmd.Parameters.AddWithValue("preciopu", fpr.PrecioPub);
                    cmd.Parameters.AddWithValue("aplidesc", fpr.AplicDesc);
                    cmd.Parameters.AddWithValue("relafacprec", fpr.RelFactPrecio);
                    cmd.ExecuteScalar();
                    tran.Commit();
                    return fpr;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede Registrar", "Ingresar Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
        public bool Eliminar_EspejoFactArticuloPrec()
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM espejoprecprove ;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    estado = true;
                }
                catch (Exception)
                {
                    estado = false;
                    MessageBox.Show(" No ha seleccionado ningún Artículo", "Eliminar Artículo Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return estado;
        }
    }
}
