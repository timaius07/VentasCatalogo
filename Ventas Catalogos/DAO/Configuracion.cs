using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas_Catalogos.DAO
{
   public class Configuracion
    {
        private static string cadenaConexion =
         String.Format("Server={0};Port={1};user id ={2};" +
          "Password={3};Database={4};", "localhost", 5432,
          "postgres", "123", "Ventas1");

        public static string CadenaConexion
        {
            get { return cadenaConexion; }

        }
    }
}
