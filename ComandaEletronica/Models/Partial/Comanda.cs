﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {

    [MetadataType(typeof(ComandaMetadata))]
    public class Comanda {
    }
    public partial class ComandaMetadata {
        public ComandaMetadata() {
            this.Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }


}