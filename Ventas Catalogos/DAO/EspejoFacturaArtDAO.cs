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
    public class EspejoFacturaArtDAO
    {
        public FacturaArtc RegitrarEspejoFactArticulo(FacturaArtc fpv)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    ///revisar el scrip de insertar
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();
                    string sql = @"INSERT INTO espejoarticprove(
            num_factartp, cod_arti, descripart, cantidad, precio, 
            subtotal, porcdesc, montodec, subtodesc, montociv, subtoiv, totalfin, iv, rel_factprove)
            VALUES ( :numfact, :codart, :descrp, :cant, :preciou, 
            :subtotal, :porcdesc, :montodesc, :subdesc, :montoiv, :subtotaliv, :montofin, :ive, :relfactprov);";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("numfact", fpv.Num_Fact);
                    cmd.Parameters.AddWithValue("codart", fpv.Cod_Arti);
                    cmd.Parameters.AddWithValue("descrp", fpv.DescripArt);
                    cmd.Parameters.AddWithValue("cant", fpv.Cantidad);
                    cmd.Parameters.AddWithValue("preciou", fpv.PrecioU);
                    cmd.Parameters.AddWithValue("subtotal", fpv.Subtotal);
                    cmd.Parameters.AddWithValue("porcdesc", fpv.PorcDesc);
                    cmd.Parameters.AddWithValue("montodesc", fpv.MontoDesc);
                    cmd.Parameters.AddWithValue("subdesc", fpv.SubtoDesc);
                    cmd.Parameters.AddWithValue("montoiv", fpv.MontocIV);
                    cmd.Parameters.AddWithValue("subtotaliv", fpv.SubtoIV);
                    cmd.Parameters.AddWithValue("montofin", fpv.TotalFin);
                    cmd.Parameters.AddWithValue("ive", fpv.IV);
                    cmd.Parameters.AddWithValue("relfactprov", fpv.RelFactProve);
                    cmd.ExecuteScalar();
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {


            }
            return fpv;
        }

        public bool Eliminar_EspejoFactArticulo()
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM espejoarticprove ;";
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
