using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {
    
    [MetadataType(typeof(ClienteMetadata))]

    public class Cliente {}

    public partial class ClienteMetadata {
        public ClienteMetadata() {
            this.Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}