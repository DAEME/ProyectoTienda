using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFTiendaServices.Dominio;

namespace WCFTiendaServices.Persistencia
{
    public class ProductoDAO:BaseDAO<Producto, int>
    {
        public void EliminarN(int codigo)
        {
            string sql = "DELETE FROM tb_producto WHERE co_producto=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add(new SqlParameter("@cod", codigo));
                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}