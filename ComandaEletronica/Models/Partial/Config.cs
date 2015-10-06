using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComandaEletronica.Models {

    [MetadataType(typeof(ConfigMetadata))]
    public partial class Config { }
    public partial class ConfigMetadata {
        public int Id { get; set; }
        public Nullable<decimal> Perc_Desconto { get; set; }
        public Nullable<decimal> Desconto { get; set; }
        public Nullable<decimal> Perc_Acrescimo { get; set; }
        public Nullable<decimal> Acrescimo { get; set; }
    }
}