using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {

    [MetadataType(typeof(MesaMetadata))]
    public class Mesa {
    }
    public partial class MesaMetadata {
        public MesaMetadata() {
            this.Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}