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
    public class UsuarioDAO
    {
       

        public Usuario Autentificar(Usuario usu)
        {
            try
            {
                Usuario usuar = new Usuario();
                //NPSGSQL es un driver en cada proyecto debe instalarse
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();


                    //abre
                    string sql = @"select nomb_usu, pass_usu, id_usuario from usuario
	                            where nomb_usu = :usu and pass_usu = :con";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("usu", usu.Nombre);
                    cmd.Parameters.AddWithValue("con", usu.Contras);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usu.Nombre = reader.GetString(0);
                        usu.Contras = reader.GetString(1);
                        usu.Id = reader.IsDBNull(2) ? 2 : reader.GetInt32(2);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error en los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
                //cierra                
                return usu;
            }            
        }
}

