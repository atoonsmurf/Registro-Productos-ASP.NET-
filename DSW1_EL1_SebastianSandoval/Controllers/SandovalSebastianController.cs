using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using DSW1_EL1_SebastianSandoval.Models.Pregunta_2;
using DSW1_EL1_SebastianSandoval.DAO.Pregunta_2;

namespace DSW1_EL1_SebastianSandoval.Controllers
{
    public class SandovalSebastianController : Controller
    {
        // DAOs

        categoriaDAO categorias = new categoriaDAO();
        productoDAO productos = new productoDAO();
        proveedorDAO proveedor = new proveedorDAO();

        public ActionResult Index(int id =0)
        {
            Producto reg = (id == 0 ? new Producto() : productos.Buscar(id));

            //producto a la vista parcial
            ViewBag.productos = productos.listado();    
            //categoria
            ViewBag.categorias = new SelectList(categorias.listado(),
                "idcategoria",
                "nombrecategoria",reg.idcategoria);

            //proveedor
            ViewBag.proveedores = new SelectList(proveedor.listado(),
              "idproveedor",
              "nombrecia",reg.idproveedor);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Index(String btncrud, Producto reg)
        {
            switch (btncrud)
            {
                case "Agregar": return Agregar(reg);
                case "Eliminar":return Eliminar(reg);
                default: return RedirectToAction("Index", new { id = "" });

            }
        }

        public ActionResult Agregar(Producto reg)
        {
            SqlParameter[] pars =
            {
                new SqlParameter(){ ParameterName="@idproducto", Value= reg.idproducto},
                new SqlParameter(){ ParameterName="@desproducto", Value= reg.descripcion},
                new SqlParameter(){ ParameterName="@umedida", Value= reg.umedida},
                new SqlParameter(){ ParameterName="@idcategoria", Value= reg.idcategoria},
                new SqlParameter(){ ParameterName="@idproveedor", Value= reg.idproveedor},
                new SqlParameter(){ParameterName="@preUni",Value= reg.preuni}

            };

            ViewBag.mensaje = productos.CRUD("usp_productoBI_add", pars, 1);

            //refresh
            ViewBag.productos = productos.listado();
            //categoria
            ViewBag.categorias = new SelectList(categorias.listado(),
                "idcategoria",
                "nombrecategoria", reg.idcategoria);

            //proveedor
            ViewBag.proveedores = new SelectList(proveedor.listado(),
              "idproveedor",
              "nombrecia", reg.idproveedor);

            return View(reg);

        }
        public ActionResult Eliminar(Producto reg)
        {
            SqlParameter[] pars =
          {
                new SqlParameter(){ ParameterName="@idproducto", Value= reg.idproducto}           
            };

            ViewBag.mensaje = productos.CRUD("usp_productoBI_delete", pars, 2);

            //refresh
            ViewBag.productos = productos.listado();
            //categoria
            ViewBag.categorias = new SelectList(categorias.listado(),
                "idcategoria",
                "nombrecategoria", reg.idcategoria);

            //proveedor
            ViewBag.proveedores = new SelectList(proveedor.listado(),
              "idproveedor",
              "nombrecia", reg.idproveedor);

            return View(reg);
        }
    }
}