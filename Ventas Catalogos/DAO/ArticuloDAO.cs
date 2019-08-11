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
   public  class ArticuloDAO
    {
        public Articulo RegistrarArticulo(Articulo at)
        {
            Articulo art = new Articulo();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"INSERT INTO articulo( cod_art, nombre_art, fecha_compra, 
                    cantidad_invt, precio_cost, porc_util, precio_venta,
                    cod_marca, cod_categoria, impuesto)
                    VALUES (:codar, :descrip, :fecha, :cantinv, :costo, :util, :venta, :codmar, :codcat, :imp)
                    RETURNING cod_art;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("codar", at.Cod_Art);
                    cmd.Parameters.AddWithValue("descrip", at.Descrip);
                    cmd.Parameters.AddWithValue("fecha", at.Fecha_Compra);
                    cmd.Parameters.AddWithValue("cantinv", at.Cantidad_Invt);
                    cmd.Parameters.AddWithValue("costo", at.Precio_Cost);
                    cmd.Parameters.AddWithValue("util", at.Porc_Util);
                    cmd.Parameters.AddWithValue("venta", at.Precio_Venta);
                    cmd.Parameters.AddWithValue("codmar", at.Cod_Marca.Id);
                    cmd.Parameters.AddWithValue("codcat", at.Cod_Depart.Id);
                    cmd.Parameters.AddWithValue("imp", at.Impuesto);
                    at.Cod_Art = Convert.ToString(cmd.ExecuteScalar());
                    tran.Commit();
                    //MessageBox.Show("Se ingreso la Artículo correctamente", "Ingreso de Artículo Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return at;
                }
            }
            catch (Exception )
            {
                MessageBox.Show("No se puede Registrar una Artículo ya exsitente", "Ingresar Artículo Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public Articulo ModificarArticulo(Articulo at)
        {
           // Articulo art = new Articulo();

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();

                string sql = @"UPDATE articulo SET
                        nombre_art= :descrip,
                        fecha_compra= :fecha,
                        cantidad_invt= :cantinv, 
                        precio_cost= :costo, 
                        porc_util= :util,
                        precio_venta= :venta,
                        cod_marca= :codmar,
                        cod_categoria= :codcat ,
                        impuesto= :imp
                        WHERE cod_art= :codart ;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("descrip", at.Descrip);
                cmd.Parameters.AddWithValue("fecha", at.Fecha_Compra);
                cmd.Parameters.AddWithValue("cantinv", at.Cantidad_Invt);
                cmd.Parameters.AddWithValue("costo", at.Precio_Cost);
                cmd.Parameters.AddWithValue("util", at.Porc_Util);
                cmd.Parameters.AddWithValue("venta", at.Precio_Venta);
                cmd.Parameters.AddWithValue("codmar", at.Cod_Marca.Id);
                cmd.Parameters.AddWithValue("codcat", at.Cod_Depart.Id);
                cmd.Parameters.AddWithValue("imp", at.Impuesto);
                cmd.Parameters.AddWithValue("codart", at.Cod_Art);
                at.Cod_Art = Convert.ToString(cmd.ExecuteScalar());
                tran.Commit();
                return at;
            }
        }
        public bool ModificarArtCompra(Articulo at)
        {
            // Articulo art = new Articulo();

            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                try
                {
                    con.Open();
                    NpgsqlTransaction tran = con.BeginTransaction();

                    string sql = @"UPDATE articulo
                   SET cantidad_invt=?, 
                   precio_cost=?,
                   porc_util=?, 
                   precio_venta=?,fecha_compra=?,
                   impuesto=?, aplicadesc=?
                   WHERE cod_art = ??;

                        WHERE cod_art= :codart ;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("cantinv", at.Cantidad_Invt);
                    cmd.Parameters.AddWithValue("costo", at.Precio_Cost);
                    cmd.Parameters.AddWithValue("util", at.Porc_Util);
                    cmd.Parameters.AddWithValue("venta", at.Precio_Venta);
                    cmd.Parameters.AddWithValue("fecha", at.Fecha_Compra);
                    cmd.Parameters.AddWithValue("imp", at.Impuesto);
                    cmd.Parameters.AddWithValue("codart", at.Cod_Art);
                    at.Cod_Art = Convert.ToString(cmd.ExecuteScalar());
                    tran.Commit();
                    return true;
                }
                catch (Exception)
                {
                    return false;                    
                }
                
            }
        }
        public List<Articulo> GetArtiDesc(string descArt)
        {
            List<Articulo> art = new List<Articulo>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from articulo
                                 where nombre_art like " + "'%" + descArt + "%'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    art.Add(cargaArticulo(reader));
                }
                return art;
            }
        }//


        public List<Articulo> GetArtCod(string codArt)
        {
            List<Articulo> art = new List<Articulo>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"select * from articulo
                                 where cod_art like " + "'%" + codArt + "%'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("nom", nombcli);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    art.Add(cargaArticulo(reader));
                }
                return art;
            }
        }//

        public List<Articulo> GetArtCodCompra(string codArt)
        {
            
            List<Articulo> art = new List<Articulo>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"SELECT nombre_art, precio_cost, porc_util, precio_venta, impuesto
                FROM articulo where cod_art = :id_art;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id_art", codArt);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    art.Add(cargaArticulo2(reader));
                }
                return art;
            }
        }/// <summary>
        /// carga los valores que se va a modificar luego de aplicar la compra
        /// </summary>
        /// <param name="codArt">actualiza los valores por codigo de articulo</param>
        /// <returns>lista con los valores seleccionados</returns>
        public List<Articulo> GetArticuloModif(string codArt)
        {
            List<Articulo> art = new List<Articulo>();
            using (NpgsqlConnection con = new NpgsqlConnection(Configuracion.CadenaConexion))
            {
                con.Open();
                //abre
                string sql = @"SELECT cantidad_invt, precio_cost, porc_util, precio_venta,
                fecha_compra, impuesto, aplicadesc
                FROM articulo where cod_art = :id_art ;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("id_art", codArt);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                
                    art.Add(cargaArticulo3(reader));
                }
                return art;
            }
        }//
        private Articulo cargaArticulo(NpgsqlDataReader reader)
        {
            return new Articulo
            {
                Cod_Art = reader.GetString(0),
                Descrip = reader.GetString(1),
                Cantidad_Invt = reader.GetInt32(2),
                Precio_Cost = reader.GetDecimal(3),
                Porc_Util = reader.GetDecimal(4),
                Precio_Venta = reader.GetDecimal(5),
                Cod_Marca = new Marca() { Id = reader.GetInt32(6) },
                Cod_Depart = new Categoria { Id = reader.GetInt32(7) },
                Fecha_Compra = reader.GetDateTime(8),
                Impuesto = reader.GetBoolean(9)
                
            };
        }//

        private Articulo cargaArticulo2(NpgsqlDataReader reader)
        {
            return new Articulo
            {                
                Descrip = reader.GetString(0),                
                Precio_Cost = reader.GetDecimal(1),
                Porc_Util = reader.GetDecimal(2),
                Precio_Venta = reader.GetDecimal(3),              
                Impuesto = reader.GetBoolean(4)
            };
        }//

        private Articulo cargaArticulo3(NpgsqlDataReader reader)
        {
            try
            {
                return new Articulo
                {
                    Cantidad_Invt = reader.GetInt32(0),
                    Precio_Cost = reader.GetDecimal(1),
                    Porc_Util = reader.GetDecimal(2),
                    Precio_Venta = reader.GetDecimal(3),
                    Fecha_Compra = reader.GetDateTime(4),
                    Impuesto = reader.GetBoolean(5),
                    AplicaDesc = reader.GetBoolean(6)
                };
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
