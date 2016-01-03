using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    [Table("DTypes")]
    public class DType
    {
        [Key]
        [DisplayName("Downtime Type ID")]
        public int DTypeID { get; set; }
        [DisplayName("Downtime Type")]
        public string Type { get; set; }
    }
}