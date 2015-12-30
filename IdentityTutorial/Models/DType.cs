using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class DType
    {
        [DisplayName("Downtime Type ID")]
        public int DowntimeTypeID { get; set; }
        [DisplayName("Downtime Type")]
        public string Type { get; set; }
    }
}