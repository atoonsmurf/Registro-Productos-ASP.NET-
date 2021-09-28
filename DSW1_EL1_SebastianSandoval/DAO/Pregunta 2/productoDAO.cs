using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models.Pregunta_2;
using System.Configuration;

namespace DSW1_EL1_SebastianSandoval.DAO.Pregunta_2
{
    public class productoDAO
    {
        conexionDAO cn = new conexionDAO();
        public IEnumerable<Producto> listado()

        {
            {
                List<Producto> temporal = new List<Producto>();

                cn = new conexionDAO();
                using (cn.getcn)
                {

                    SqlCommand cmd = new SqlCommand("usp_productoBI_listado", cn.getcn);

                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        temporal.Add(new Producto()
                        {
                            idproducto= dr.GetInt32(0),
                            descripcion=dr.GetString(1),
                            umedida=dr.GetString(2),
                            idcategoria=dr.GetInt32(3),
                            idproveedor=dr.GetInt32(4),
                            preuni=dr.GetDecimal(5)

                        });
                    }

                    dr.Close();
                    cn.getcn.Close();

                }
                return temporal;
            }

        }

        public IEnumerable<Producto> listado(String sp, SqlParameter[] pars = null)
        {
            {
                List<Producto> temporal = new List<Producto>();

                using (cn.getcn)
                {
                    SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (pars != null) cmd.Parameters.AddRange(pars.ToArray());

                    cn.getcn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        temporal.Add(new Producto()
                        {
                            idproducto = dr.GetInt32(0),
                            descripcion = dr.GetString(1),
                            umedida = dr.GetString(2),
                            idcategoria = dr.GetInt32(3),
                            idproveedor = dr.GetInt32(4),
                            preuni = dr.GetDecimal(5)
                        });
                    }
                    dr.Close();
                    cn.getcn.Close();
                }

                return temporal;
            }
        }

        public Producto Buscar(int id)

        {
            Producto reg = listado().Where(c => c.idproducto == id).FirstOrDefault();

            return reg;


        }

        public String CRUD(string sp, SqlParameter[] pars = null, int op = 0)

        {

            string mensaje = "";

            try{

                SqlCommand cmd = new SqlCommand(sp, cn.getcn);

                cmd.CommandType = CommandType.StoredProcedure;

                if (pars != null) cmd.Parameters.AddRange(pars.ToArray());

                cn.getcn.Open();

                int c = cmd.ExecuteNonQuery(); //ejecutamos el CRUD

                if (op == 1) mensaje = c + "Registro exitoso";
                else if (op == 2) mensaje = c + "Eliminación exitosa";

            }catch (SqlException e)
            {
                mensaje = e.Message;
            } finally{
                cn.getcn.Close();
            }

            return mensaje;
        }

    }

}
