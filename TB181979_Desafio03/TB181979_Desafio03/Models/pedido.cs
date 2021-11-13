using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TB181979_Desafio03.Models
{
    public partial class pedido
    {
        public int id { get; set; }
        public virtual cliente clientes { get; set; }
        public virtual producto productos { get; set; }

    }
}