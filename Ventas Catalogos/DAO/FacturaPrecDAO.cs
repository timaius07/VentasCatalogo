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
    public class FacturaPrecDAO
    {
        public FacturaPrecio RegistrarFacPrecio(FacturaPrecio fpr)
        {
           
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"INSERT INTO precprove(
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
            catch (Exception )
            {
                MessageBox.Show("No se puede Registrar", "Ingresar Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public FacturaPrecio ModificarFacturaPrec(FacturaPrecio fpr)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"UPDATE precprove
            SET  cod_arti= :codart, descripart= :desc, 
            costo= :precicos, utilidad= :util , preciopu= :preciopub,
            aplicadesc= :aplicdes
            WHERE rel_factprecio= :numidprec and cod_arti= :codart;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numidprec", fpr.RelFactPrecio);
                cmd.Parameters.AddWithValue("codart", fpr.Cod_Arti);
                cmd.Parameters.AddWithValue("desc", fpr.Descripcion);
                cmd.Parameters.AddWithValue("precicos", fpr.Costo);
                cmd.Parameters.AddWithValue("util", fpr.Utilidad);
                cmd.Parameters.AddWithValue("preciopu", fpr.PrecioPub);
                cmd.Parameters.AddWithValue("aplicdes", fpr.AplicDesc);
                cmd.ExecuteScalar();
                tran.Commit();
                return fpr;
            }
        }

        public bool Eliminar_FactArticuloPrec(int numidFact)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM precprove
                WHERE rel_factprecio = :numidfac ;";
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

        public List<FacturaPrecio> GetFactArticuloPrec(string numfact)
        {
            List<FacturaPrecio> facprove = new List<FacturaPrecio>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from precprove where num_factartp = :numfac ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfac", numfact);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactPrec(reader));
                }
                return facprove;
            }
        }//
        public List<FacturaPrecio> GetFactEspejoArticuloPrec(string numfact)
        {
            List<FacturaPrecio> facprove = new List<FacturaPrecio>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from espejoprecprove where num_factartp = :numfac ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfac", numfact);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactPrec(reader));
                }
                return facprove;
            }
        }//
        private FacturaPrecio cargarFactPrec(NpgsqlDataReader reader)
        {
            return new FacturaPrecio
            {
                Id_FacArt = reader.GetInt32(0),
                Num_Fact= reader.GetString(1),
                Cod_Arti = reader .GetString (2),
                Descripcion = reader.GetString(3),
                Costo= reader .GetDecimal(4),
                Utilidad = reader.GetDecimal(5),
                PrecioPub = reader.GetDecimal(6),
                AplicDesc = reader.GetBoolean(7),
                RelFactPrecio= reader .GetInt32(8),
            };
        }
    }
}
