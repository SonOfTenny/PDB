using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace IdentityTutorial.Models
{
    public class Plant
    {
        [DisplayName("Plant ID")]
        public int PlantID { get; set; }
        [DisplayName("Plant Name")]
        public string Name { get; set; }
        [DisplayName("Mix Rate Per Hour")]
        public double? MixRatePerHour { get; set; }
    }
}