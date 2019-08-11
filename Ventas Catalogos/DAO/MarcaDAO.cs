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
    public class MarcaDAO
    {

        public Marca RegistrarCliente(Marca mc)
        {
            Marca cli = new Marca();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"INSERT INTO marca( descrip_marca)
                                 VALUES (:descpmarc)
                  RETURNING id_marca;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("descpmarc", mc.NombreMarca);
                    mc.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    MessageBox.Show("Se ingreso la Marca correctamente", "Ingreso de Marca Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return mc;
            
                }


            }
            catch (Exception)
            {

                MessageBox.Show("No se puede Registrar una Marca ya exsitente", "Ingresar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null ;
            }



        }

        public bool Eliminar_Marca(int idMc)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM marca
                    WHERE id_marca= :id_mc;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id_mc", idMc);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    estado = true;
                }
                catch (Exception)
                {

                    estado = false;
                    MessageBox.Show("No se elimino la Marca", "Eliminar Marca Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return estado;
        }

        public List<Marca> GetMarca()
        {
            List<Marca> marc = new List<Marca>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from marca";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    marc.Add(cargaCliente(reader));
                }
                return marc;
            }
        }//
        private Marca cargaCliente(NpgsqlDataReader reader)
        {
            return new Marca
            {
                Id = reader.GetInt32(0),
                NombreMarca = reader.GetString(1)
            };
        }
    }
}
