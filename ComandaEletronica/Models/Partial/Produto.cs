using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {

    [MetadataType(typeof(ProdutoMetadata))]
    
    public class Produto {
    }

    public partial class ProdutoMetadata {
        public ProdutoMetadata() {
            this.PedidoItem = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
    }
}