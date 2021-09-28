using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models.Pregunta_2;

namespace DSW1_EL1_SebastianSandoval.DAO.Pregunta_2
{
    public class categoriaDAO
    {
        conexionDAO cn = new conexionDAO();

        public IEnumerable<Categoria> listado()
        {
            List<Categoria> temporal = new List<Categoria>();

            using (cn.getcn)
            {
                SqlCommand cmd = new SqlCommand("usp_categoria_listado", cn.getcn);

                cn.getcn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    temporal.Add(new Categoria()
                    {
                        idcategoria = dr.GetInt32(0),
                        nombrecategoria = dr.GetString(1)
                    });
                }
                dr.Close();
                cn.getcn.Close();
            }

                return temporal;
        }
    } 
}