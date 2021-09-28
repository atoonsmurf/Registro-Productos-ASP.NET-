using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models;

namespace DSW1_EL1_SebastianSandoval.DAO
{
    public class pedidosDAO
    {
        conexionDAO cn = new conexionDAO();
        public IEnumerable<PedidoCabe> pedidos(String sp, SqlParameter[]pars=null)
        {
            List<PedidoCabe> temporal = new List<PedidoCabe>();

            using (cn.getcn)
            {
                SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (pars != null) cmd.Parameters.AddRange(pars.ToArray());

                cn.getcn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temporal.Add(new PedidoCabe()
                    {
                      idpedido= dr.GetInt32(0),
                      fechapedido= dr.GetDateTime(1),
                      direccion= dr.GetString(2),
                      ciudad= dr.GetString(3)

                    });
                }
                dr.Close();
                cn.getcn.Close();
            }

            return temporal;
        }
    }
}