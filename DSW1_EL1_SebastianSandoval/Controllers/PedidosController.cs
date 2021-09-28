using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models;
using DSW1_EL1_SebastianSandoval.DAO;

namespace DSW1_EL1_SebastianSandoval.Controllers
{
    public class PedidosController : Controller
    {
        // DAOs
        pedidosDAO pedidos = new pedidosDAO();
        anioDAO anios = new anioDAO();

        static int fila = 10;
        public ActionResult pedidosPorAnio(int p = 0, int y=0)
        {
            SqlParameter[] pars={
                new SqlParameter() { ParameterName="@y",Value=y}
            };

            IEnumerable<PedidoCabe> listado = pedidos.pedidos("usp_lista_pedidos_anio", pars);

            int c = listado.Count();

            ViewBag.numPags = c % fila > 0 ? c / fila + 1 : c / fila;
            ViewBag.p = p;
            ViewBag.y = y;

            //
            ViewBag.years = new SelectList(anios.anios(),
                "",
                "year");

            return View(listado.Skip(p*fila).Take(fila));
        }
    }
}