using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace DSW1_EL1_SebastianSandoval.Models
{
    public class PedidoCabe
    {

        [Display(Name ="idpedido")]
        public int idpedido { get; set; }

        [Display(Name = "fecha")]
        public DateTime fechapedido { get; set; }

        [Display(Name = "direccion")]
        public String direccion { get; set; }

        [Display(Name = "ciudad")]
        public String ciudad { get; set; }
    }
}