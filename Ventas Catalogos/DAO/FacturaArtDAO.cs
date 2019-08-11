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
    public class FacturaArtDAO
    {
        public FacturaArtc RegitrarFactArticulo(FacturaArtc fpv)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    ///revisar el scrip de insertar
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();
                    string sql = @"INSERT INTO articprove(
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

        public FacturaArtc ModificarFactArticulo(FacturaArtc fpv)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"UPDATE articprove
                SET descripart= :descrp, cantidad= :cant, 
                precio= :preciou, subtotal= :subtotal, porcdesc= :porcdesc,
                montodec= :montodesc, subtodesc= :subdesc, montociv= :montoiv, 
                subtoiv= :subtotaliv, totalfin= :montofin
                WHERE rel_factprove = :numidprov and cod_arti= :codart";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numidprov", fpv.RelFactProve);
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
                cmd.Parameters.AddWithValue("iv", fpv.IV);
                fpv.Id_FacArt = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
                return fpv;
            }
        }
        public bool Eliminar_FactArticulo(int numidFact)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM articprove
                WHERE rel_factprove = :numidfac ;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("numidfac", numidFact);
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
        public List<FacturaArtc> GetFactArticulo(string numfact)
        {
            List<FacturaArtc> facprove = new List<FacturaArtc>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from articprove where num_factartp = :numfac ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfac", numfact);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactArt(reader));
                }
                return facprove;
            }
        }//

        public List<FacturaArtc> GetFactEspejoArticulo(string numfact)
        {
            List<FacturaArtc> facprove = new List<FacturaArtc>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from espejoarticprove where num_factartp = :numfac ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfac", numfact);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactArt(reader));
                }
                return facprove;
            }
        }//

        private FacturaArtc cargarFactArt(NpgsqlDataReader reader)
        {
            return new FacturaArtc
            {
                Id_FacArt = reader.GetInt32(0),
                Num_Fact = reader.GetString(1),
                DescripArt = reader .GetString(2),
                Cantidad = reader.GetInt32(3),
                PrecioU = reader.GetInt32(4),
                Subtotal = reader.GetDecimal(5),
                PorcDesc = reader.GetDecimal(6),
                MontoDesc = reader.GetDecimal(7),
                SubtoDesc = reader.GetDecimal(8),
                MontocIV = reader .GetDecimal(9),
                SubtoIV = reader.GetDecimal(10),
                TotalFin = reader.GetDecimal(11),
                Cod_Arti = reader.GetString(12),
                IV = reader.GetBoolean(13),
                RelFactProve = reader .GetInt32(14)
            };
    }

    
}
}
