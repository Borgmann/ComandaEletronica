using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {
    
    [MetadataType(typeof(PedidoItemMetadata))]
    
    public class PedidoItem {
    }

    public partial class PedidoItemMetadata {
        public int Id { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Produto { get; set; }
        public decimal Valor { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}