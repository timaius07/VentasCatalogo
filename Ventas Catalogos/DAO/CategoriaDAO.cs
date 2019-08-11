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
    public class CategoriaDAO
    {

        public Categoria RegistrarCliente(Categoria cc)
        {
            Categoria cli = new Categoria();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"INSERT INTO categoria( descrip_categ)
                                 VALUES (:descCateg)
                  RETURNING id_categ;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("descCateg", cc.NombreCategoria);
                    cc.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    tran.Commit();
                    MessageBox.Show("Se ingreso la Categoría correctamente", "Ingreso de Categoría Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return cc;
            
                }


            }
            catch (Exception)
            {

                MessageBox.Show("No se puede Registrar una Categoría ya exsitente", "Ingresar Categoría Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null ;
            }



        }

        public bool Eliminar_Categoria(int idCtg)
        {
            bool estado = false;
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    string sql = @"DELETE FROM categoria
                    WHERE id_categ= :id_cc;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id_cc", idCtg);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    estado = true;
                }
                catch (Exception)
                {

                    estado = false;
                    MessageBox.Show("No se elimino la Categoría", "Eliminar Categoría Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return estado;
        }

        public List<Categoria> GetCategoria()
        {
            List<Categoria> marc = new List<Categoria>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from categoria";
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
        private Categoria cargaCliente(NpgsqlDataReader reader)
        {
            return new Categoria
            {
                Id = reader.GetInt32(0),
                NombreCategoria = reader.GetString(1)
            };
        }
    }
}
