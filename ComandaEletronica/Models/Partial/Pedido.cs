using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {
    
    [MetadataType(typeof(PedidoMetadata))]
    public class Pedido {
    }
    public partial class PedidoMetadata {
        public PedidoMetadata() {
            this.PedidoItem = new HashSet<PedidoItem>();
        }

        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Comanda { get; set; }
        public int Id_Atendente { get; set; }
        public int Id_Mesa { get; set; }
        public byte Pago { get; set; }
        public decimal Valor { get; set; }

        public virtual Atendente Atendente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Comanda Comanda { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
    }
}