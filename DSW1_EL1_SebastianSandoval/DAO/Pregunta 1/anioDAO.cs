using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models;

namespace DSW1_EL1_SebastianSandoval.DAO
{
    public class anioDAO
    {
        conexionDAO cn = new conexionDAO();
        public IEnumerable<Anio> anios()
        {
            List<Anio> temporal = new List<Anio>();

            using (cn.getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_listar_anio", cn.getcn);

                cn.getcn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temporal.Add(new Anio()
                    {
                        year= dr.GetInt32(0)
                    });

                }
                dr.Close();
                cn.getcn.Close();

            }

            return temporal;
        }
    }
}