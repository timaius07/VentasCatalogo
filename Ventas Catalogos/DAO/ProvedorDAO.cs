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
    public class ProvedorDAO
    {
        public Provedor RegitrarProvedor(Provedor pt)
        {
            Provedor pv = new Provedor();

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"INSERT INTO provedor(
                    cedula, razonsocial, razoncomercial, direcion, email, 
                    numtelf, numcel, diascredito)
                    VALUES ( :ced , :razonsoc , :razoncomer , :dirc, :correo, :telcasa , 
                        :telcel , :diascred );";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ced", pt.Cedula);
                cmd.Parameters.AddWithValue("razonsoc", pt.RazonSocial);
                cmd.Parameters.AddWithValue("razoncomer", pt.RazonComercial);
                cmd.Parameters.AddWithValue("dirc", pt.Direccion);
                cmd.Parameters.AddWithValue("correo", pt.Email);
                cmd.Parameters.AddWithValue("telcasa", pt.TelefonoEmpresa);
                cmd.Parameters.AddWithValue("telcel", pt.TelefonoCel);
                cmd.Parameters.AddWithValue("diascred", pt.DiasCredito);
                pt.Id = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
                return pt;
            }
        }
        public Provedor ModificarProvedor(Provedor pt)
        {
            Provedor prv = new Provedor();

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"UPDATE provedor
        SET cedula= :ced, razonsocial= :razonsoc, razoncomercial= :razoncomer,
        direcion= :dirc, email= :correo, numtelf= :telofic, numcel= :telcel,    
        diascredito= :diascred  WHERE id_provedor = :id_prov;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("ced", pt.Cedula);
                cmd.Parameters.AddWithValue("razonsoc", pt.RazonSocial);
                cmd.Parameters.AddWithValue("razoncomer", pt.RazonComercial);
                cmd.Parameters.AddWithValue("dirc", pt.Direccion);
                cmd.Parameters.AddWithValue("correo", pt.Email);
                cmd.Parameters.AddWithValue("telofic", pt.TelefonoEmpresa);
                cmd.Parameters.AddWithValue("telcel", pt.TelefonoCel);
                cmd.Parameters.AddWithValue("diascred", pt.DiasCredito);
                cmd.Parameters.AddWithValue("id_prov", pt.Id);
                pt.Id = Convert.ToInt32(cmd.ExecuteScalar());
                tran.Commit();
                return pt;
            }
        }
        public bool Eliminar_Provedor(int idProv)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {

                try
                {
                    con.Open();
                    string sql = @"DELETE FROM provedor
                    WHERE id_provedor= :id_prov;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id_prov", idProv);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    estado = true;
                }
                catch (Exception)
                {

                    estado = false;
                    MessageBox.Show(" No ha seleccionado ningún Provedor", "Eliminar Provedor Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return estado;
        }

        public List<Provedor> GetProvedor(string nombprov)
        {
            List<Provedor> prov = new List<Provedor>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from provedor
                                 where razonsocial || razoncomercial like " + "'%" + nombprov + "%'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prov.Add(this.cargarProvedor(reader));
                }
                return prov;
            }
        }//

        public List<Provedor> GetProvedorIDNomb()
        {
            List<Provedor> prove = new List<Provedor>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from provedor";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prove.Add(cargaProvedorNuevFact(reader));
                }
                return prove;
            }
        }//
        private Provedor cargaProvedorNuevFact(NpgsqlDataReader reader)
        {
            return new Provedor
            {
                Id = reader.GetInt32(0),
                RazonSocial = reader.GetString(2),
                DiasCredito = reader.GetInt32(8)
            };
        }

        private Provedor cargarProvedor(NpgsqlDataReader reader)
        {
            return new Provedor
            {
                Id = reader.GetInt32(0),
                Cedula = reader.GetString(1),
                RazonComercial = reader.GetString(2),
                RazonSocial = reader.GetString(3),
                Direccion = reader.GetString(4),
                Email = reader.GetString(5),
                TelefonoEmpresa  = reader.GetString(6),
                TelefonoCel = reader.GetString(7),
                DiasCredito = reader.GetInt32(8)

            };
        }

    }
}
