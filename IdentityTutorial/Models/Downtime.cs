using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityTutorial.Models
{
    public class Downtime
    {
        public int DowntimeID { get; set; }
        public string UserID { get; set; }
        public int ShiftID { get; set; }
        //public int PlantID { get; set; }
        public int DowntimeTypeID { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        // all the fancy foreign keys
        public virtual User User { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual Plant Plant { get; set; }
        public virtual DowntimeType DowntimeType { get; set; }
    }
}