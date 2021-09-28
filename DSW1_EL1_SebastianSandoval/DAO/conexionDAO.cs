using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DSW1_EL1_SebastianSandoval.DAO
{
    public class conexionDAO
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        public SqlConnection getcn
        {
            get { return cn; }
        }
    }
}