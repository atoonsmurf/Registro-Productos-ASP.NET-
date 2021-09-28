using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DSW1_EL1_SebastianSandoval.Models.Pregunta_2
{
    public class Producto
    {
        [Display(Name = "idproducto")]
        public int idproducto { get; set; }

        [Display(Name = "descripcion")]
        public String descripcion { get; set; }

        [Display(Name = "medida")]
        public String umedida { get; set; }

        [Display(Name = "idcat")]
        public int idcategoria { get; set; }

        [Display(Name = "idprov")]
        public int idproveedor { get; set; }

        [Display(Name = "precio")]
        public decimal preuni { get; set; }
    }
}