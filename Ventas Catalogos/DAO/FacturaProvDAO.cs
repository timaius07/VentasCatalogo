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
    public class FacturaProvDAO
    {

        public int RegitrarFactProvedor(FacturaProv fpv)
        {
          using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();
                string sql = @"INSERT INTO facturaprov(
             num_factprov, idprove, fecha, formapago, observaciones, apllicainv, 
             finalfact, montofact)
             VALUES ( :numfact , :idprov , :fech , :formpago , :observac , :aplicinv, 
             :finfact, :montofac) RETURNING id_factprov ;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfact", fpv.NumFactProv);
                cmd.Parameters.AddWithValue("idprov", fpv.IdProvedor);
                cmd.Parameters.AddWithValue("fech", fpv.Fecha);
                cmd.Parameters.AddWithValue("formpago", fpv.Formapago);
                cmd.Parameters.AddWithValue("observac", fpv.Observaciones);
                cmd.Parameters.AddWithValue("aplicinv", fpv.AplicaInv);
                cmd.Parameters.AddWithValue("finfact", fpv.Finalfact);
                cmd.Parameters.AddWithValue("montofac", fpv.Montofact);
                fpv.IDProvFact = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
                return fpv.IDProvFact; 
            }
        }
        public FacturaProv ModificarFacturaPrv(FacturaProv fpv)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"UPDATE facturaprov
                SET fecha= :fech , formapago= :formpago, observaciones= :observac, 
                apllicainv= :aplicinv , finalfact= :finfact , montofact= :montofac
                WHERE id_factprov = :numidFact;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numidFact", fpv.IDProvFact);
                cmd.Parameters.AddWithValue("fech", fpv.Fecha);
                cmd.Parameters.AddWithValue("formpago", fpv.Formapago);
                cmd.Parameters.AddWithValue("observac", fpv.Observaciones);
                cmd.Parameters.AddWithValue("aplicinv", fpv.AplicaInv);
                cmd.Parameters.AddWithValue("finfact", fpv.Finalfact);
                cmd.Parameters.AddWithValue("montofac", fpv.Montofact);
                fpv.IdProvedor = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
                return fpv;
            }
        }
        public bool Eliminar_FactProvedor(string numFact)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
               try
                {
                    con.Open();
                    string sql = @"DELETE FROM facturaprov
                    WHERE num_factprov = :numfac;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("numfac", numFact);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    estado = true;
                }
                catch (Exception)
                {
                   estado = false;
                    MessageBox.Show(" No ha seleccionado ningún Factura", "Eliminar Factura Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return estado;
        }

        public List<FacturaProv> GetFactProvedor()
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from facturaprov";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactProv(reader));
                }
                return facprove;
            }
        }//
        public List<FacturaProv> GetFactNumProvedor()
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select num_factprov , idprove from facturaprov";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarNumFactProv(reader));
                }
                return facprove;
            }
        }//
        public List<FacturaProv> GetFactProvedorBusc(string numfact,int idprov, DateTime fecha)
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select  provedor.id_provedor,facturaprov.num_factprov, 
                provedor.razonsocial, facturaprov.montofact,
                facturaprov.fecha , facturaprov.formapago, facturaprov.observaciones,
                facturaprov.apllicainv, facturaprov.finalfact, facturaprov.id_factprov
                FROM
                 facturaprov  inner JOIN  provedor on   (provedor.id_provedor = facturaprov.idprove) where (provedor.id_provedor = :idpro) and 
                (facturaprov.num_factprov = :numfac) and (facturaprov.fecha = :fechafact)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfac", numfact);
                cmd.Parameters.AddWithValue("idpro", idprov);
                cmd.Parameters.AddWithValue("fechafact", fecha);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactProvBuscar(reader));
                }
                return facprove;
            }
        }
        public List<FacturaProv> GetFactProvedorBuscProv( int idprov)
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select  provedor.id_provedor,facturaprov.num_factprov,
                provedor.razonsocial, facturaprov.montofact,
                facturaprov.fecha , facturaprov.formapago, facturaprov.observaciones, 
                facturaprov.apllicainv, facturaprov.finalfact, facturaprov.id_factprov
                FROM
                facturaprov  inner JOIN  provedor on   (provedor.id_provedor = facturaprov.idprove)   where(provedor.id_provedor = :idpro )";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);               
                cmd.Parameters.AddWithValue("idpro", idprov);               
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactProvBuscar(reader));
                }
                return facprove;
            }
        }

        public List<FacturaProv> GetFactProvedorBuscProvFecha(DateTime fecha)
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select  provedor.id_provedor,facturaprov.num_factprov, 
                provedor.razonsocial, facturaprov.montofact,
                facturaprov.fecha , facturaprov.formapago, 
                facturaprov.observaciones, facturaprov.apllicainv,
                facturaprov.finalfact, facturaprov.id_factprov
                FROM
                facturaprov  inner JOIN  provedor on   (provedor.id_provedor = facturaprov.idprove)   where (facturaprov.fecha = :fechfact)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("fechfact", fecha);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactProvBuscar(reader));
                }
                return facprove;
            }
        }

        public List<FacturaProv> GetFactProvedorBuscProvNumFact(string fact)
        {
            List<FacturaProv> facprove = new List<FacturaProv>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select  provedor.id_provedor,facturaprov.num_factprov, 
                provedor.razonsocial, facturaprov.montofact,
                facturaprov.fecha , facturaprov.formapago, facturaprov.observaciones,
                facturaprov.apllicainv, facturaprov.finalfact, facturaprov.id_factprov
                FROM
                facturaprov  inner JOIN  provedor on   (provedor.id_provedor = facturaprov.idprove) where (facturaprov.num_factprov = :numfact)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("numfact", fact);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    facprove.Add(cargarFactProvBuscar(reader));
                }
                return facprove;
            }
        }

        private FacturaProv cargarFactProv(NpgsqlDataReader reader)
        {
            return new FacturaProv
            {
                NumFactProv = reader.GetString(0),
                IdProvedor = reader.GetInt32(1),
                Fecha = reader.GetDateTime(2),
                Formapago = reader.GetString(3),
                Observaciones = reader.GetString(4),
                AplicaInv = reader.GetBoolean(5),
                Finalfact = reader.GetBoolean(6),
                Montofact = reader.GetDecimal(7),
                IDProvFact = reader .GetInt32(8)
            };
        }
        private FacturaProv cargarNumFactProv(NpgsqlDataReader reader)
        {
            return new FacturaProv
            {
                NumFactProv = reader.GetString(0),
                IdProvedor = reader.GetInt32(1),             
            };
        }
        private FacturaProv cargarFactProvBuscar(NpgsqlDataReader reader)
        {
            return new FacturaProv
            {
                IdProvedor = reader.GetInt32(0),
                NumFactProv = reader.GetString(1),
                NombProv = reader.GetString(2),
                Montofact = reader.GetDecimal(3),
                Fecha = reader.GetDateTime(4),
                Formapago = reader.GetString(5),
                Observaciones = reader.GetString(6),
                AplicaInv = reader.GetBoolean(7),
                Finalfact = reader.GetBoolean(8),
                IDProvFact = reader.GetInt32(9)

            };
        }

    }
}
