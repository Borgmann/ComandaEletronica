using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models.Partial {




    [MetadataType(typeof(AtendenteMetadata))]
    public partial class Atendente { }
    public partial class AtendenteMetadata {
        public AtendenteMetadata() {
            this.Pedido = new HashSet<Pedido>();
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        [Display(Name = "User")]
        public string Usuario { get; set; }
        [Required]
        [Display(Name="Password")]
        public string Senha { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}