using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models.Pregunta_2;

namespace DSW1_EL1_SebastianSandoval.DAO.Pregunta_2
{
    public class proveedorDAO
    {

        conexionDAO cn = new conexionDAO();

        public IEnumerable<Proveedor> listado()
        {
            List<Proveedor> temporal = new List<Proveedor>();

            using (cn.getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_proveedores_listado", cn.getcn);

                cn.getcn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temporal.Add(new Proveedor()
                    {
                        idproveedor = dr.GetInt32(0),
                        nombrecia = dr.GetString(1)
                    });
                }
                dr.Close();
                cn.getcn.Close();
            }

            return temporal;
        }
    }
}